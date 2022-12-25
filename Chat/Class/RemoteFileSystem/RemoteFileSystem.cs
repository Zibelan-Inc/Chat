using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace Tools
{
    public class FolderCopyData
    {
        public class File
        {
            public String name;
            public ulong size;
        }

        public String folder        = "";
        public List<File> files     = new List<File>();
        public bool loaded          = false;
        public bool complete        = false;
        public long size            = 0;
    }

    public class RemoteFileSystem
    {
        public class Server
        {
            public delegate void SendResponse(String response);
            public SendResponse sendResponse;

            public delegate void SetFileInFolder(String path);
            public SetFileInFolder setFileInFolder;

            private String sig = "RFSResponse";

            public Server(SendResponse sendResponse, SetFileInFolder setFileInFolder)
            {
                this.sendResponse       = sendResponse;
                this.setFileInFolder    = setFileInFolder;
            }

            public Server(SendResponse sendResponse)
            {
                this.sendResponse = sendResponse;
            }

            public void RequestHandler(String request)
            {
                ThreadPool.QueueUserWorkItem(HandleRequest, request);
            }

            private XmlObject GetResponseObject()
            {
                XmlObject newCom    = new XmlObject();
                newCom              = new XmlObject();
                newCom.Name         = sig;
                return newCom;
            }

            private void HandleRequest(Object o)
            {
                String request = (String)o;

                // We only accept <RFSRequest>s here:
                if (!request.Trim().StartsWith("<RFSRequest>")) return;

                // Get this command:
                XmlObject xmlReq = XmlParser.Parse(request)[0];
                xmlReq.GetXmlObject(@"RFSRequest/cmd", ref xmlReq);
                xmlReq.GetTextContent("", ref request);

                if (request.ToLower().Trim().Equals("getdrives"))
                {
                    DriveInfo[] allDrives = DriveInfo.GetDrives();
                    XmlObject comm = GetResponseObject();
                    comm.AddAttribute("type", "getdrives");

                    foreach (DriveInfo d in allDrives)
                    {
                        if (d.IsReady == true)
                        {
                            comm = comm.CreateChildElement("Drive_" + Regex.Split(d.Name, ":")[0]);
                            comm.AddAttribute("rootdir", Regex.Split(d.RootDirectory.Name, ":")[0]);
                            comm.AddAttribute("volumelabel", d.VolumeLabel);
                            comm.AddAttribute("availablespace", d.AvailableFreeSpace.ToString());
                            comm.AddAttribute("totalsize", d.TotalSize.ToString());
                            comm = comm.parent;
                        }
                    }
                    sendResponse(comm.ToString());
                }

                if (request.ToLower().Trim().Equals("getcontents"))
                {
                    String path = "";
                    FileInfo info;
                    xmlReq      = xmlReq.GetRootElement();
                    xmlReq.GetTextContent(@"RFSRequest/path", ref path);

                    if(path != "")
                    {
                        XmlObject comm  = GetResponseObject();
                        comm.AddAttribute("type", "getcontents");
                        bool accessError    = false;
                        String errMsg       = "";

                        try
                        {
                            String[] content = Directory.GetDirectories(path);

                            foreach(String directory in content)
                            {
                                if(!directory.Contains("$"))
                                {
                                    comm = comm.CreateChildElement("directory");
                                    comm.AddTextContent(directory);
                                    comm = comm.parent;
                                }
                            }

                            content = Directory.GetFiles(path);

                            foreach(String file in content)
                            {
                                comm = comm.CreateChildElement("file");
                                comm.AddTextContent(file);

                                try
                                {
                                    info = new FileInfo(file);
                                    comm.AddAttribute("size", info.Length.ToString());
                                    comm.AddAttribute("lastmodified", info.LastWriteTime.ToString());
                                } catch (Exception) { }

                                comm = comm.parent;
                            }
                        }  catch (Exception ex) { errMsg = ex.Message; accessError = true; }

                        if(accessError)
                        {
                            comm = comm.GetRootElement();
                            comm.AddAttribute("error", errMsg);
                        }

                        sendResponse(comm.ToString());
                    }
                }

                if (request.ToLower().Trim().Equals("setfileinfolder"))
                {
                    XmlObject comm = GetResponseObject();
                    comm.AddAttribute("type", "setfileinfolder");

                    if (setFileInFolder != null)
                    {
                        String path     = "";
                        xmlReq          = xmlReq.GetRootElement();
                        xmlReq.GetXmlObject(@"RFSRequest/path", ref xmlReq);
                        xmlReq.GetTextContent("", ref path);

                        if(Directory.Exists(path))
                        {
                            setFileInFolder(path);
                        } else
                        {
                            try
                            {
                                Directory.CreateDirectory(path);
                            } catch (Exception ex)
                            {
                                comm.AddAttribute("status", "failed");
                                comm.AddAttribute("errormessage", "The RFS Server could not create the new target folder. The error received is: " + ex.Message);
                                sendResponse(comm.ToString());
                                return;
                            }
                            setFileInFolder(path);
                        }

                        comm.AddAttribute("status", "complete");
                        sendResponse(comm.ToString());
                    } else
                    {

                        comm.AddAttribute("status", "failed");
                        comm.AddAttribute("errormessage", "The RFS server is not handling setfileinfolder requests.");
                        sendResponse(comm.ToString());
                    }
                }

                if (request.ToLower().Trim().Equals("getfilesin"))
                {
                    String path     = "";
                    String errMsg   = "";
                    bool recurse    = false;
                    xmlReq          = xmlReq.GetRootElement();
                    xmlReq.GetXmlObject(@"RFSRequest/path", ref xmlReq); //recurse
                    path = xmlReq.GetAttribute("", "recurse");

                    try
                    {
                        recurse = bool.Parse(path);
                    } catch (Exception ex) { errMsg = ex.Message; }
                    
                    path = "";
                    xmlReq.GetTextContent("", ref path);

                    if(path.Equals("")) { errMsg = "No path sent. getfilesin aborted."; }

                    XmlObject comm = GetResponseObject();
                    comm.AddAttribute("type", "getfilesin");

                    if(!errMsg.Equals(""))
                    {
                        comm.AddAttribute("error", errMsg);
                        sendResponse(comm.ToString());
                        return;
                    }

                    if(!Directory.Exists(path))
                    {
                        comm.AddAttribute("error", "The requested directory does not exist. getfilesin aborted.");
                        sendResponse(comm.ToString());
                        return;
                    }

                    // We have a valid getfilesin command. Fire up a new thread and handle it:
                    new Thread(() =>
                    {
                        FileInfo info;
                        List<String> allFiles                               = new List<String>();
                        Action<List<String>, String, bool> fileCollector    = null;
                        long totalFileBytes                                 = 0;

                        comm = GetResponseObject();
                        comm.AddAttribute("type", "getfilesin");

                        comm = comm.CreateChildElement("path");
                        comm.AddTextContent(path);

                        comm = comm.parent;

                        fileCollector = (List<String> collectedfiles, String currentPath, bool recurseSubdirectories) =>
                        {
                            String[] directories    = new String[] { "" };
                            String[] newFiles       = new String[] { "" };

                            try
                            {   // We will not have access to every directory.
                                // Get what we can:
                                directories = Directory.GetDirectories(currentPath);
                            } catch (Exception) { }

                            try
                            {   // We won't have access to every file either.
                                // Get what we can:
                                newFiles = Directory.GetFiles(currentPath);
                            }
                            catch (Exception) { }

                            // If we've been instructed to get files in subdirectories, get em':
                            if(recurseSubdirectories)
                            {
                                foreach (String directory in directories)
                                {
                                    fileCollector(collectedfiles, directory, recurseSubdirectories);
                                }
                            }
                            
                            // Dump all the collected files into the collectedFiles list:
                            foreach(String file in newFiles)
                            {
                                collectedfiles.Add(file);
                            }
                        };

                        // Start collecting the files here:
                        fileCollector(allFiles, path, recurse);

                        // Go through the files and get their sizes,
                        // and add them to the response xml:
                        foreach(String file in allFiles)
                        {
                            try
                            {
                                info = new FileInfo(file);
                                totalFileBytes += info.Length;

                                comm = comm.CreateChildElement("file");
                                comm.AddTextContent(file);
                                comm.AddAttribute("size", info.Length.ToString());
                                comm = comm.parent;

                            } catch (Exception) { }
                        }

                        comm.GetXmlObject(@"RFSResponse/path", ref comm);
                        comm.AddAttribute("totalsize", totalFileBytes.ToString());
                        comm = comm.GetRootElement();
                       
                        sendResponse(comm.ToString());
                    }).Start();
                }
            }
        }

        public class Client
        {
            public delegate void SendData(String data);
            public SendData sendData;

            public class RemoteFileinfo
            {
                public String path;
                public String name;
                public String completePath;
                public UInt64 size;
                public DateTime lastModified;
            }

            public class ServerReplyData
            {
                public List<String> directories;
                public List<RemoteFileinfo> files;
                public String errorInfo;
                public String type;
                public String path;
                public long size;
            }

            private class SetRemoteFilereceivedFolder
            {
                public enum Status
                {
                    Pending     = 0,
                    Complete    = 1,
                    Failed      = 2
                }
                public String errMsg = "";
                public Status status = Status.Pending;
            }

            public delegate void ServerReplyHandler(ServerReplyData data);
            public ServerReplyHandler serverReplyHandler;

            private XmlObject comm;
            private String sig = "RFSRequest";

            private SetRemoteFilereceivedFolder setRemoteFileReceivedFolder = new SetRemoteFilereceivedFolder() { status = SetRemoteFilereceivedFolder.Status.Complete };

            public Client(SendData sendData, ServerReplyHandler serverReplyHandler)
            {
                this.sendData           = sendData;
                this.serverReplyHandler = serverReplyHandler;

                GetDrives();
            }

            private XmlObject GetCmdObject(String cmd)
            {
                XmlObject newCom    = new XmlObject();
                newCom              = new XmlObject();
                newCom.Name         = sig;
                newCom              = newCom.CreateChildElement("cmd");
                newCom.AddTextContent(cmd);
                return newCom.parent;
            }

            /// <summary>
            /// Use this to get a list of all "ready" drives available on the remote machine.
            /// </summary>
            public void GetDrives()
            {
                ThreadPool.QueueUserWorkItem((o) =>
                {
                    comm = GetCmdObject("getdrives");
                    sendData(comm.ToString());
                });
            }

            /// <summary>
            /// TcpComm doesn't allow the client to set the remote file receive folder via the client, so this needed to be done
            /// another way. This function triggers a delegate in the RFS server. You can use it to change the received files folder
            /// of the server is you like, and anything else you need to do at that time.
            /// </summary>
            /// <param name="path">The path of the new received files folder.</param>
            /// <param name="errMsg">The error message returned from the server on failure.</param>
            /// <returns></returns>
            public bool SetRemoteFileReceiveFolder(String path, ref String errMsg)
            {
                if(setRemoteFileReceivedFolder.status == SetRemoteFilereceivedFolder.Status.Pending)
                {
                    errMsg = "There is already a pending setRemoteFileReceiveFolder rerquest. This one can no be processed until the last one completes.";
                    return false;
                }

                setRemoteFileReceivedFolder.status = SetRemoteFilereceivedFolder.Status.Pending;

                ThreadPool.QueueUserWorkItem((o) =>
                {
                    comm = GetCmdObject("setfileinfolder");
                    comm = comm.CreateChildElement("path");
                    comm.AddTextContent(path);

                    comm = comm.GetRootElement();
                    sendData(comm.ToString());
                });

                while(setRemoteFileReceivedFolder.status == SetRemoteFilereceivedFolder.Status.Pending)
                {
                    Thread.Sleep(1);
                }

                if(setRemoteFileReceivedFolder.status == SetRemoteFilereceivedFolder.Status.Failed)
                {
                    errMsg = setRemoteFileReceivedFolder.errMsg;
                    setRemoteFileReceivedFolder.status = SetRemoteFilereceivedFolder.Status.Complete;
                    return false;
                }

                setRemoteFileReceivedFolder.status = SetRemoteFilereceivedFolder.Status.Complete;
                return true;
            }

            /// <summary>
            /// Get the files and folders within the folder path you send.
            /// </summary>
            /// <param name="path"></param>
            public void GetContents(String path)
            {
                XmlObject tCom = GetCmdObject("getcontents");
                tCom = tCom.CreateChildElement("path");
                tCom.AddTextContent(path);
                tCom = tCom.GetRootElement();
                ThreadPool.QueueUserWorkItem((o) => sendData(tCom.ToString()));
            }

            /// <summary>
            /// Get the FILES in the folder you specify, and all the files in subdirectories also
            /// if you choose.
            /// </summary>
            /// <param name="folderPath">The folder path you are inquiring about.</param>
            /// <param name="recurseSubdirs">Include files in subdirectories or not.</param>
            public void GetFilesIn(String folderPath, bool recurseSubdirs = false)
            {
                XmlObject tCom = GetCmdObject("getfilesin");
                tCom = tCom.CreateChildElement("path");
                tCom.AddTextContent(folderPath);
                tCom.AddAttribute("recurse", recurseSubdirs.ToString().ToLower());
                tCom = tCom.GetRootElement();
                ThreadPool.QueueUserWorkItem((o) => sendData(tCom.ToString()));
            }

            /// <summary>
            /// A helper function to get the all the files in a LOCAL folder, and possibly it's subfolders also.
            /// </summary>
            /// <param name="folder">The folder path you're inquiring about.</param>
            /// <param name="recurse">Include subdirectories or not.</param>
            /// <param name="errMsg">The error message returned on failure.</param>
            /// <returns></returns>
            public bool GetLocalFilesIn(ref FolderCopyData folder, bool recurse, ref String errMsg)
            {
                if (folder.folder.Equals("")) { errMsg = "No path specified in RemoteFileSystem.GetLocalFilesIn call."; return false; }

                if (!Directory.Exists(folder.folder))
                {
                    errMsg = "The requested directory does not exist in RemoteFileSystem.GetLocalFilesIn call.";
                    return false;
                }

                FileInfo info;
                List<String> allFiles                               = new List<String>();
                Action<List<String>, String, bool> fileCollector    = null;

                fileCollector = (List<String> collectedfiles, String currentPath, bool recurseSubdirectories) =>
                {
                    String[] directories    = new String[] { "" };
                    String[] newFiles       = new String[] { "" };

                    try
                    {   // We will not have access to every directory.
                        // Get what we can:
                        directories = Directory.GetDirectories(currentPath);
                    }
                    catch (Exception) { }

                    try
                    {   // We won't have access to every file either.
                        // Get what we can:
                        newFiles = Directory.GetFiles(currentPath);
                    }
                    catch (Exception) { }

                    // If we've been instructed to get files in subdirectories, get em':
                    if (recurseSubdirectories)
                    {
                        foreach (String directory in directories)
                        {
                            fileCollector(collectedfiles, directory, recurseSubdirectories);
                        }
                    }

                    // Dump all the collected files into the collectedFiles list:
                    foreach (String file in newFiles)
                    {
                        collectedfiles.Add(file);
                    }
                };

                // Start collecting the files here:
                fileCollector(allFiles, folder.folder, recurse);

                foreach(String file in allFiles)
                {
                    info = new FileInfo(file);
                    folder.files.Add(new FolderCopyData.File() { name = file, size = (ulong)info.Length });
                }

                folder.loaded = true;
                return true;
            }

            /// <summary>
            /// Pass the server's replies to this function when they are received. They must be converted to a string first.
            /// </summary>
            /// <param name="response">The text sent from the server.</param>
            public void ResponseHandler(String response)
            {
                // We only accept <RFSResponse>s here:
                if (!response.Trim().StartsWith("<RFSResponse")) return;
                comm = XmlParser.Parse(response)[0];

                String type = comm.GetAttribute("", "type");

                if(type.Equals("getdrives"))
                {
                    ServerReplyData data = new ServerReplyData() { directories = new List<String>(), type = type };

                    foreach (KeyValuePair<XmlObjectType, Object> item in comm.content)
                    {
                        if (item.Key == XmlObjectType.Element)
                        {
                            data.directories.Add(((XmlObject)item.Value).GetAttribute("", "rootdir") + @":");
                        }
                    }

                    serverReplyHandler(data);
                    return;
                }

                if(type.Equals("setfileinfolder"))
                {
                    String status = comm.GetAttribute("", "status");
                    String errMsg = comm.GetAttribute("", "errormessage");

                    if(status == "complete")
                    {
                        setRemoteFileReceivedFolder.status = SetRemoteFilereceivedFolder.Status.Complete;
                    } else
                    {
                        setRemoteFileReceivedFolder.errMsg = errMsg;
                        setRemoteFileReceivedFolder.status = SetRemoteFilereceivedFolder.Status.Failed;
                    }
                }

                if(type.Equals("getcontents"))
                {
                    String[] parts;
                    String path             = "";
                    UInt64 size;
                    DateTime lastMod;

                    ServerReplyData data    = new ServerReplyData() { type = type };
                    comm                    = comm.GetRootElement();
                    path                    = comm.GetAttribute("", "error");

                    if (!path.Equals(""))
                    {
                        data.errorInfo = path;
                    }

                    List<String> directories    = new List<String>();
                    List<RemoteFileinfo> files  = new List<RemoteFileinfo>();

                    foreach (KeyValuePair<XmlObjectType, Object> item in comm.content)
                    {
                        if (item.Key == XmlObjectType.Element)
                        {
                            if (((XmlObject)item.Value).Name.Equals("directory"))
                            {

                                ((XmlObject)item.Value).GetTextContent("", ref path);
                                parts = Regex.Split(path, @"\\");
                                directories.Add(parts[parts.Length - 1]);
                            }
                            if (((XmlObject)item.Value).Name.Equals("file"))
                            {
                                ((XmlObject)item.Value).GetTextContent("", ref path);
                                parts = Regex.Split(path, @"\\");

                                try
                                { // Get the file size...
                                    size = UInt64.Parse(((XmlObject)item.Value).GetAttribute("", "size"));
                                } catch(Exception) { size = 0; }

                                try
                                { // Get the last modified date...
                                    lastMod = DateTime.Parse(((XmlObject)item.Value).GetAttribute("", "lastmodified"));
                                } catch (Exception) { lastMod = DateTime.Now; }

                                files.Add(new RemoteFileinfo()
                                {
                                    name            = parts[parts.Length - 1],
                                    completePath    = path,
                                    path            = Path.GetDirectoryName(path),
                                    size            = size,
                                    lastModified    = lastMod
                                });
                            }
                        }
                    }

                    data.directories    = directories;
                    data.files          = files;
                    serverReplyHandler(data);
                }

                if (type.Equals("getfilesin"))
                {
                    XmlObject file              = null;
                    RemoteFileinfo thisFile     = null;
                    String tmp                  = "";
                    ServerReplyData data        = new ServerReplyData() { type = type };

                    // Get the path object, and read the totalsize attribute:
                    comm = comm.GetRootElement();
                    comm.GetXmlObject(@"RFSResponse/path", ref comm);

                    try
                    {   // Get the total size:
                        tmp         = comm.GetAttribute("", "totalsize");
                        data.size   = long.Parse(tmp);
                    } catch (Exception) { data.size = 0; }

                    // Get the search path:
                    comm.GetTextContent("", ref data.path);

                    // Initialize the remotefileinfo list:
                    data.files = new List<RemoteFileinfo>();

                    comm = comm.GetRootElement();

                    // Enumerate the files, and add them to the RemoteFileInfo list:
                    foreach(KeyValuePair<XmlObjectType, object> item in comm.content)
                    {
                        // There are text items and XmlObjects in this list.
                        // We're only interested in XmlObjects:
                        if (item.Key.Equals(XmlObjectType.Element))
                        {
                            // And only XmlObjects with the name "file":
                            file = (XmlObject)item.Value;
                            if(file.Name.Equals("file"))
                            {
                                // Get the file path:
                                thisFile = new RemoteFileinfo();
                                file.GetTextContent("", ref thisFile.name);

                                // Get the file size string:
                                tmp = "";
                                tmp = file.GetAttribute("", "size");
                                
                                try
                                {   // Parse it to the ulong:
                                    thisFile.size = ulong.Parse(tmp);
                                } catch (Exception) { }

                                // Add this one to the list:
                                data.files.Add(thisFile);
                            }
                        }
                    }

                    // Pass the data to the end user:
                    serverReplyHandler(data);
                }
            }
        }
    }
}
