using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using TcpComm;
using Tools;

namespace RemoteFileSystemTester
{
    public class CopyFiles
    {
        private frmRfs frm;
        private RemoteFileSystem.Client rfsClient;
        private Client tcpClient;

        public delegate void StatusUpdate(String msg);
        public StatusUpdate statusUpdate;

        public CopyFiles(frmRfs frm, ref RemoteFileSystem.Client rfsClient, ref Client tcpClient, StatusUpdate statusUpdate)
        {
            this.frm            = frm;
            this.rfsClient      = rfsClient;
            this.tcpClient      = tcpClient;
            this.statusUpdate   = statusUpdate;
        }

        private void UI(Action uiCode)
        {
            if(frm.InvokeRequired) { frm.Invoke((MethodInvoker)delegate () { uiCode(); }); return; }
            uiCode();
        }

        public bool doTransfer              = false;
        public String receivedFilesLocation = "";

        public class FileTransferError
        {
            public bool receivedError = false;
            public String errorMessage = "";
        }

        public FileTransferError transferError  = new FileTransferError();
        public List<FolderCopyData> folders     = new List<FolderCopyData>();
        
        /// <summary>
        /// Copy files from the remote machine to the local machine using the RemoteFileSystem class over tcp using the TcpComm library.
        /// This function diaplays transfer of selected files and folders using the modal frmTransferProgress dialog window.
        /// </summary>
        /// <param name="selectedItems">The names of files and folders selected in a listview control.</param>
        /// <param name="currentPath">The currently selected path within the viewer.</param>
        public void ToLocalMachine(ListViewItem[] selectedItems, String currentPath, String receivedFilesLocation)
        {
            var transfer                = new frmTransferProgress(() => { doTransfer = false; });
            var setOverAllProgress      = transfer.overAllProgress;
            var setTransferDlgMsg       = transfer.setMessage;
            var currentFileName         = transfer.setCurrentFileName;
            var setCurrentFileProgress  = transfer.setCurrentFileProgress;
            var hideCancelButton        = transfer.hideCancelButton;
            var finishAndClose          = transfer.finishAndClose;

            this.receivedFilesLocation  = receivedFilesLocation;

            transferError.receivedError = false;
            transferError.errorMessage  = "";

            folders.Clear();

            new Thread(() =>
            {
                List<String> remoteFiles                = new List<String>();
                String targetFolder                     = "";
                String thisFolderName                   = "";
                String errMsg                           = "";
                int completeNumberOfFilesBeingCopied    = 0;
                int filesTransferred                    = 0;
                bool complete                           = false;
                doTransfer                              = true;

                statusUpdate("Transfering files...");

                foreach (ListViewItem file in selectedItems)
                {
                    if (file.SubItems[2].Text.Contains("Folder"))
                    {
                        // Handle folders here:
                        folders.Add(new FolderCopyData() { folder = Path.Combine(currentPath, file.Text) });
                    }
                    else
                    {
                        // Handle individually selected files here:
                        remoteFiles.Add(Path.Combine(currentPath, file.Text));
                    }

                }

                setOverAllProgress("Compiling the list of files in the folders you selected...", 0, 100);
                completeNumberOfFilesBeingCopied += remoteFiles.Count;

                // Send requests for files in the directories:
                setTransferDlgMsg("Requesting detailed folder contents from the server...");
                foreach (FolderCopyData folder in folders)
                {
                    this.rfsClient.GetFilesIn(folder.folder, true);
                }

                // Wait for the server to get back to us on all the folders we sent:
                setTransferDlgMsg("Waiting for detailed folder contents from the server...");
                while (!complete && doTransfer)
                {
                    Thread.Sleep(10);

                    complete = true;
                    foreach (FolderCopyData folder in folders)
                    {
                        if (folder.loaded == false) { complete = false; break; }
                    }
                }

                // Get the number of files in the selected folders:
                foreach (FolderCopyData folder in folders)
                {
                    completeNumberOfFilesBeingCopied += folder.files.Count;
                }

                setTransferDlgMsg("Beginning file transfer...");

                // Copy our individually selected files:
                tcpClient.SetReceivedFilesFolder(receivedFilesLocation);

                // Track the progress:
                tcpClient.incomingFileProgress = (UInt16 percentComplete) =>
                {
                    setCurrentFileProgress(percentComplete);
                    setOverAllProgress("Overall Progress (" + filesTransferred.ToString() + " of " + completeNumberOfFilesBeingCopied.ToString() + " complete):",
                        (filesTransferred * 100) + tcpClient.GetPercentOfFileReceived(), completeNumberOfFilesBeingCopied * 100);
                };

                // Make sure we know when the file finishes:
                tcpClient.incomingFileComplete = ()=> complete = true;

                setTransferDlgMsg("Transfering individually selected files...");

                foreach (String file in remoteFiles)
                {
                    currentFileName(@"Transfering file: ..\" + Path.GetFileName(file));
                    complete = false;

                    // Request the file:
                    if (!tcpClient.GetFile(file, true, ref errMsg))
                    {
                        setTransferDlgMsg(errMsg);
                        transferError.receivedError = true;
                        transferError.errorMessage  = errMsg;
                        doTransfer                  = false;
                    }

                    // Wait for this transfer to complete:
                    while(!complete && doTransfer) { Thread.Sleep(1); }

                    Thread.Sleep(100);

                    // Update the files transfered counter, and then update the prog bars:
                    filesTransferred += 1;

                    if (!doTransfer) { tcpClient.CancelIncomingFileTransfer(); break; }
                    if (transferError.receivedError)
                    {
                        doTransfer = false;
                        setTransferDlgMsg(transferError.errorMessage);
                        break;
                    }
                }

                if(!doTransfer) { tcpClient.CancelIncomingFileTransfer(); }
                if (transferError.receivedError)
                {
                    doTransfer = false;
                    setTransferDlgMsg(transferError.errorMessage);
                }

                // Copy our folders:
                foreach (FolderCopyData folder in folders)
                {
                    foreach (FolderCopyData.File file in folder.files)
                    {
                        // Display which folder we're copying files from:
                        thisFolderName = folder.folder.Contains("\\") ? Regex.Split(folder.folder, @"\\")[Regex.Split(folder.folder, @"\\").Length - 1].Trim() : "";
                        setTransferDlgMsg("Transfering files from \"" + thisFolderName + "\"");

                        try
                        {
                            // Get the name of the folder that is being transferred:
                            targetFolder = thisFolderName;
                            // Get the file path without it's source folder:
                            targetFolder += file.name.Replace(folder.folder, "");
                            // Add the partial file path and the target folder together
                            targetFolder = Path.Combine(receivedFilesLocation, targetFolder.StartsWith("\\") ? targetFolder.Substring(1, targetFolder.Length - 1) : targetFolder);
                            // Get the final target folder without the filename:
                            targetFolder = Path.GetDirectoryName(targetFolder);
                            // Set the target folder in tcpClient:
                            tcpClient.SetReceivedFilesFolder(targetFolder);
                        }
                        catch (Exception ex)
                        {
                            doTransfer = false;
                            // Catch the "path too long" error that may happen here:
                            folders.Clear();
                            MessageBox.Show(ex.Message, "Couldn't create path.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        complete = false;

                        // Request the file:
                        currentFileName(@"Transfering file: ..\" + Path.GetFileName(file.name));
                        if (!tcpClient.GetFile(file.name, true, ref errMsg))
                        {
                            setTransferDlgMsg(errMsg);
                            transferError.receivedError = true;
                            transferError.errorMessage  = errMsg;
                            doTransfer                  = false;
                        }

                        // Wait for this transfer to complete:
                        while (!complete && doTransfer) { Thread.Sleep(1); }

                        // Update the files transfered counter, and then update the prog bars:
                        filesTransferred += 1;

                        if (!doTransfer) { tcpClient.CancelIncomingFileTransfer(); break; }
                        if (transferError.receivedError)
                        {
                            doTransfer = false;
                            setTransferDlgMsg(transferError.errorMessage);
                            break;
                        }
                    }
                }

                if (transferError.receivedError)
                {
                    doTransfer = false;
                    setTransferDlgMsg(transferError.errorMessage);
                }

                UI(() =>
                {
                    String msg;
                    if (doTransfer)
                    {
                        msg                 = "Transfer Complete!";
                        statusUpdate(msg);

                        setTransferDlgMsg(msg);
                        hideCancelButton();
                    }
                    else
                    {
                        msg                 = "Transfer Aborted.";
                        statusUpdate(msg);

                        setTransferDlgMsg(msg);
                        setOverAllProgress(msg, 0, 100);
                        setCurrentFileProgress(0);
                        hideCancelButton();
                    }
                });

                // Give the end user a cuple of seconds 
                // to see the complete / cancelled message:
                Thread.Sleep(2000);

                finishAndClose();

                UI(() =>
                {
                    // Clean up:
                    //transfer.Close();
                    folders.Clear();

                    if (transferError.receivedError)
                    {
                        MessageBox.Show(transferError.errorMessage, "File Transfer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                });

            }).Start();
            
            transfer.ShowDialog(frm);
        }

        /// <summary>
        /// Copy files to the remote machine using the RemoteFileSystem class over tcp using the TcpComm library.
        /// This function diaplays transfer of selected files and folders using the modal frmTransferProgress dialog window.
        /// </summary>
        /// <param name="selectedItems">A list of files and folders that need to me copied to the fromte folder.</param>
        /// <param name="remoteTargetFolder">The remote folder where these files and folders will be written.</param>
        public void ToRemoteMachine(String[] selectedItems, String remoteTargetFolder)
        {
            // To begin with, we prepare our progress form by initializing it and subscribing to the
            // available delegates. We will update the progress form's UI from a background thread
            // using these delegates.
            var transfer                = new frmTransferProgress(() => { doTransfer = false; });
            var setOverAllProgress      = transfer.overAllProgress;
            var setTransferDlgMsg       = transfer.setMessage;
            var currentFileName         = transfer.setCurrentFileName;
            var setCurrentFileProgress  = transfer.setCurrentFileProgress;
            var hideCancelButton        = transfer.hideCancelButton;
            var finishAndClose          = transfer.finishAndClose;

            transferError.receivedError = false;
            transferError.errorMessage  = "";

            folders.Clear();
            receivedFilesLocation       = remoteTargetFolder;

            new Thread(() =>
            {
                List<String> localFiles                 = new List<String>();
                String targetFolder                     = "";
                String thisFolderName                   = "";
                String errMsg                           = "";
                int completeNumberOfFilesBeingCopied    = 0;
                int filesTransferred                    = 0;
                int currentFileNum                     = 0;
                doTransfer                              = true;

                // We need to know which of the entries is a file, and which is a folder.
                // They will be handled differently:
                statusUpdate("Transfering files...");
                foreach (String item in selectedItems)
                {
                    if(Directory.Exists(item))
                    {
                        folders.Add(new FolderCopyData() { folder = item });

                    }
                    else
                    {
                        localFiles.Add(item);
                    }
                }

                setOverAllProgress("Compiling the list of files in the folders you selected...", 0, 100);
                completeNumberOfFilesBeingCopied += localFiles.Count;

                // Get lists of the files in the directories. We use the FolderCopyData class
                // so we can record not only the files, but files sizes and the source folder also.
                if(folders.Count > 0)
                {
                    FolderCopyData thisOne;
                    foreach (FolderCopyData folder in folders)
                    {
                        thisOne = folder;
                        rfsClient.GetLocalFilesIn(ref thisOne, true, ref errMsg);
                    }
                }

                // Get the number of files in the selected folders. We need the total number of files so we can
                // display an overall progress.
                foreach (FolderCopyData folder in folders)
                {
                    completeNumberOfFilesBeingCopied += folder.files.Count;
                }

                setTransferDlgMsg("Beginning file transfer...");

                // There may be folders and individually selected files. We will handle our individually selected files here, 
                // beginning by telling the server to set it's received files folder to the one we need to write these files to:
                if(!rfsClient.SetRemoteFileReceiveFolder(receivedFilesLocation, ref errMsg))
                {
                    MessageBox.Show("Could not set the remote machine's received files folder. The error returned is: " + errMsg);
                    return;
                }

                setTransferDlgMsg("Transfering individually selected files...");

                // Handle progress updates here:
                tcpClient.outgoingFileProgress = (ushort percentComplete) =>
                {
                    setCurrentFileProgress(tcpClient.GetPercentOfFileSent());
                    setOverAllProgress("Overall Progress (" + filesTransferred.ToString() + " of " + completeNumberOfFilesBeingCopied.ToString() + " complete):",
                        (filesTransferred * 100) + tcpClient.GetPercentOfFileSent(), completeNumberOfFilesBeingCopied * 100);
                };

                // Handle transfer complete events here:
                tcpClient.outgoingFileComplete = () =>
                {
                    filesTransferred += 1;
                    currentFileNum += 1;
                    setCurrentFileProgress(100);
                    setOverAllProgress("Overall Progress (" + filesTransferred.ToString() + " of " + completeNumberOfFilesBeingCopied.ToString() + " complete):",
                            (filesTransferred * 100), completeNumberOfFilesBeingCopied * 100);

                    if (currentFileNum < localFiles.Count)
                    {
                        currentFileName(@"Transfering file: ..\" + Path.GetFileName(localFiles[currentFileNum]));
                        if (!tcpClient.SendFile(localFiles[currentFileNum], ref errMsg))
                        {
                            setTransferDlgMsg(errMsg);
                            transferError.receivedError = true;
                            transferError.errorMessage  = errMsg;
                            doTransfer                  = false;
                        }
                    }
                };

                // Send the first one here:
                if(localFiles.Count > 0)
                {
                    currentFileName(@"Transfering file: ..\" + Path.GetFileName(localFiles[currentFileNum]));
                    if (!tcpClient.SendFile(localFiles[currentFileNum], ref errMsg))
                    {
                        setTransferDlgMsg(errMsg);
                        transferError.receivedError = true;
                        transferError.errorMessage = errMsg;
                        doTransfer = false;
                    }

                    // We need to wait here for the files to complete and check for errors:
                    while (currentFileNum < localFiles.Count)
                    {
                        if (!doTransfer) { tcpClient.CancelOutgoingFileTransfer(); break; }
                        if (transferError.receivedError)
                        {
                            doTransfer = false;
                            setTransferDlgMsg(transferError.errorMessage);
                            break;
                        }
                    }
                }
                
                // Handle any errors here...
                if (!doTransfer) { tcpClient.CancelOutgoingFileTransfer(); }
                if (transferError.receivedError)
                {
                    doTransfer = false;
                    setTransferDlgMsg(transferError.errorMessage);
                }

                currentFileNum                  = 0;
                tcpClient.outgoingFileComplete  = null;

                // Copy our folders:
                foreach (FolderCopyData folder in folders)
                {
                    foreach (FolderCopyData.File file in folder.files)
                    {
                        // Display which folder we're copying files from:
                        thisFolderName = folder.folder.Contains("\\") ? Regex.Split(folder.folder, @"\\")[Regex.Split(folder.folder, @"\\").Length - 1].Trim() : "";
                        setTransferDlgMsg("Transfering files from \"" + thisFolderName + "\"");

                        try
                        {
                            // Get the name of the folder that is being transferred:
                            targetFolder = thisFolderName;
                            // Get the file path without it's source folder:
                            targetFolder += file.name.Replace(folder.folder, "");
                            // Add the partial file path and the target folder together
                            targetFolder = Path.Combine(receivedFilesLocation, targetFolder.StartsWith("\\") ? targetFolder.Substring(1, targetFolder.Length - 1) : targetFolder);
                            // Get the final target folder without the filename:
                            targetFolder = Path.GetDirectoryName(targetFolder);
                            // Set the target folder in tcpClient:
                            //tcpClient.SetReceivedFilesFolder(targetFolder);
                            if (!rfsClient.SetRemoteFileReceiveFolder(targetFolder, ref errMsg))
                            {
                                MessageBox.Show("Could not set the remote machine's received files folder. The error returned is: " + errMsg);
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            doTransfer = false;
                            // Catch the "path too long" error that may happen here:
                            folders.Clear();
                            MessageBox.Show(ex.Message, "Couldn't create path.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Send the file:
                        if (!tcpClient.SendFile(file.name, ref errMsg))
                        {
                            setTransferDlgMsg(errMsg);
                            transferError.receivedError = true;
                            transferError.errorMessage  = errMsg;
                            doTransfer                  = false;
                        }

                        currentFileName(@"Transfering file: ..\" + Path.GetFileName(file.name));

                        // Wait for the current transfer to complete before moving on...
                        while (tcpClient.SendingAFile() && doTransfer)
                        {
                            Thread.Sleep(1);
                        }

                        // Update the files transfered counter, and then update the prog bars:
                        filesTransferred += 1;
                        setCurrentFileProgress(100);
                        setOverAllProgress("Overall Progress (" + filesTransferred.ToString() + " of " + completeNumberOfFilesBeingCopied.ToString() + " complete):",
                                (filesTransferred * 100), completeNumberOfFilesBeingCopied * 100);

                        if (!doTransfer) { tcpClient.CancelOutgoingFileTransfer(); break; }
                        if (transferError.receivedError)
                        {
                            doTransfer = false;
                            setTransferDlgMsg(transferError.errorMessage);
                            break;
                        }
                    }
                }

                if (transferError.receivedError)
                {
                    doTransfer = false;
                    setTransferDlgMsg(transferError.errorMessage);
                }

                UI(() =>
                {
                    String msg;
                    if (doTransfer)
                    {
                        msg = "Transfer Complete!";
                        statusUpdate(msg);

                        setTransferDlgMsg(msg);
                        hideCancelButton();
                    }
                    else
                    {
                        msg = "Transfer Aborted.";
                        statusUpdate(msg);

                        setTransferDlgMsg(msg);
                        setOverAllProgress(msg, 0, 100);
                        setCurrentFileProgress(0);
                        hideCancelButton();
                    }
                });

                // Give the end user a cuple of seconds 
                // to see the complete / cancelled message:
                Thread.Sleep(2000);

                finishAndClose();

                UI(() =>
                {
                    // Clean up:
                    folders.Clear();

                    if (transferError.receivedError)
                    {
                        MessageBox.Show(transferError.errorMessage, "File Transfer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                });

            }).Start();
            
            transfer.ShowDialog(frm);
        }
    }
}
