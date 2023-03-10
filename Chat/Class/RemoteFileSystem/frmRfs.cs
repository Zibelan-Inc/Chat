using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Chat;
using Chat.Properties;
using TcpComm;
using Tools;
using Client = TcpComm.Client;

namespace RemoteFileSystemTester
{
    public partial class frmRfs : Form
    {
        public frmRfs()
        {
            InitializeComponent();
        }

        [DllImport("User32.dll")]
        public static extern Int32 SetForegroundWindow(int hWnd);

        private static DialogResult ShowInputDialog(String messageText, String titleText, ref string inputText)
        {
            Size size = new Size(300, 150);
            Form inputBox = new Form();

            inputBox.FormBorderStyle = FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = titleText;
            inputBox.ControlBox = false;
            inputBox.StartPosition = FormStartPosition.CenterScreen;

            Label lblMessage = new Label();
            lblMessage.Size = new Size(size.Width - 10, 73);
            lblMessage.Location = new Point(5, 5);
            lblMessage.Text = messageText;
            inputBox.Controls.Add(lblMessage);

            TextBox textBox = new TextBox();
            textBox.Size = new Size(size.Width - 10, 103);
            textBox.Location = new Point(5, 85);
            textBox.Text = inputText;
            inputBox.Controls.Add(textBox);

            Button okButton = new Button();
            okButton.DialogResult = DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new Point(size.Width - 80 - 80, 119);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new Point(size.Width - 80, 119);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();
            inputText = textBox.Text;
            return result;
        }

        private RemoteFileSystem.Client rfsClient;
        private String remoteMachineName;
        private Client tcpClient;
        private Utilities.LargeArrayTransferHelper lat;
        private bool allowNodeToExpandOrCollapse    = false;
        private ushort remotePort                   = 22590;
        private String tmpFolder                    = Path.Combine(Path.GetTempPath(), "Transferred files");
        private String receivedFilesLocation        = "";
        private DragDropHelper dragDropHelper;
        private CopyFiles copy;

        private bool mouseDown;     //Mover ventana
        private Point lastLocation; //Mover ventana

        private void UI(Action code)
        {
            try
            {
                if (this.InvokeRequired) { this.Invoke((MethodInvoker)delegate () { code(); }); return; }
                code();
            } catch (Exception)
            {
                // We may catch an exception here while shutting down if something is attempting
                // to update the UI when you click the close buttion. These can be safely ignored.
            }
        }

        void lvFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        void lvFiles_DragDrop(object sender, DragEventArgs e)
        {
            String[] files  = (String[])e.Data.GetData(DataFormats.FileDrop);

            // Start a new thread so that lvFiles_DragDrop exits.
            // If we don't do this, the mouse retains the drag / drop cursor, and 
            // we loose right click functionality until the transfer is complete.
            new Thread(()=> 
            {
                UI(() =>
                {
                    copy.ToRemoteMachine(files, GetCurrentPath());
                    rfsClient.GetContents(GetCurrentPath());
                });
            }).Start();
        }
        public string IP { get; set; }
        public string Start(string ip)
        {
            IP = ip;
            return IP;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // This example project assumes that you will be transferring to and from the same machine.
            // So by default, the remote machine name is set to this machine.
            remoteMachineName = Environment.MachineName;

            // Thie DragDropHelper helper class makes it possible to get the drop target folder when dragging items to
            // Windows Explorer (or the desktop). It has only been tested in Windows 7. The supplied delegate
            // fires when files are dragged from the listview to an explorer window and a drop folder is captured:
            dragDropHelper = new DragDropHelper((String dropTargetPath)=>
            {
                // Shuffle this transfer off to a background thread immediately so the
                // DragDropHelper capture thread is released.
                ThreadPool.QueueUserWorkItem((o) =>
                {
                    // We're copying files from the remote machine. The selected files
                    // and folders are the the selected items in the lvFiles listview.
                    ListViewItem[] selectedItems    = null;
                    bool complete                   = false;
                    String currentPath              = "";
                    receivedFilesLocation           = dropTargetPath;

                    UI(()=>
                    {
                        // The explorer window we dropped items into is in the forground now.
                        // Let's bring this window back to the front before we start copying:
                        this.BringForward();

                        // While we're on the UI thread, let's get the currently selected path from 
                        // tvPaths. We'll need it for the transfer.
                        currentPath = GetCurrentPath();
                        complete    = true;
                    });

                    // The code above is running on the UI thread. We want to wait until it 
                    // completes before moving on, so:
                    while(!complete) { Thread.Sleep(1); }

                    UI(() =>
                    {
                        // We're only doing a file transfer if some files 
                        // and folders are actually selected...
                        if (lvFiles.SelectedItems.Count > 0)
                        {
                            // Get the selected items
                            selectedItems = new ListViewItem[lvFiles.SelectedItems.Count];
                            lvFiles.SelectedItems.CopyTo(selectedItems, 0);

                            // Supply all this data to the transfer function, and begin:
                            copy.ToLocalMachine(selectedItems, GetCurrentPath(), receivedFilesLocation);

                            // Finally, if we transfered the files and folders to the desktop, 
                            // Let windows know that it needs to refresh the desktop:
                            Explorer.Refresh(dropTargetPath.ToLower().Contains("desktop"));
                        }
                    });
                });
            });

            lvFiles.AllowDrop   = true;
            lvFiles.DragEnter  += new DragEventHandler(lvFiles_DragEnter);
            lvFiles.DragDrop   += new DragEventHandler(lvFiles_DragDrop);

            // We're using my tcp library to handle tcp ccommunications, which can be found here:
            // https://www.codeproject.com/articles/307315/reusable-multithreaded-tcp-client-and-server-class
            // Have a look at the article for details on ho to use Tcpcomm.
            tcpClient = new Client((Byte[] buffer, Byte dataChannel) =>
            {
                // We may be getting large chunks of data from the server: Let's have Lat handle that for us.
                if(lat != null && lat.HandleIncomingBytes(buffer, dataChannel, -1, new Byte[] { 100, 100})) { return; }

                // Everything's happening over channel 100:
                if(dataChannel == 100)
                {
                    // We pass anything on channel 100 to rfs:
                    rfsClient.ResponseHandler(Utilities.BytesToString(buffer));
                }

                if(dataChannel.Equals(255))
                {
                    String msg = Utilities.BytesToString(buffer);

                    // We need to know if there's an error...
                    if (msg.ToLower().StartsWith("err"))
                    {
                        copy.transferError.errorMessage  = msg;
                        copy.transferError.receivedError = true;
                    }

                    // And we need to know if we've been disconnected.
                    if(msg.ToLower().Equals("disconnected."))
                    {
                        UI(() =>
                        {
                            tvPaths.Nodes.Clear();
                            lvFiles.Items.Clear();
                            lblStatus.Text = "Disconnected.";
                        });
                    }
                }
            });

            // Initialize LAT (Large Array Transfer Helper):
            lat = new Utilities.LargeArrayTransferHelper(ref tcpClient);
            currentPath.Text = IP;
            btConnect.PerformClick();

        }

        /// <summary>
        /// This is the initialization code for the RemoteFileSystem class.
        /// The first delegate is called by FRS when it needs to send data to the server. This is not handled internally
        /// so that RFS is independant of my TcpComm library, and you can use it with whatever tcp library you're 
        /// comfortable with - or write your own. Data is returned to you via the second delegate, in a ServerData 
        /// object. See below to learn how to handle them. In this example, we're taking the data returned by the server
        /// and populating the treeview and listview on the form to make this file transfer utility.
        /// </summary>
        private void StartRFS()
        {
            rfsClient = new RemoteFileSystem.Client((String data) =>
            {
                // Requests are sent to the server here:
                String errMsg = "";
                if(!tcpClient.SendText(data, 100, ref errMsg))
                {
                    MessageBox.Show("Could not send data to the server!", "TCP Communications problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }, (RemoteFileSystem.Client.ServerReplyData serverData) =>
            {
                // Handle server replies here:
                if (serverData.type.Equals("getdrives"))
                {
                    // This code needs to be run on the UI thread:
                    UI(() =>
                    {
                        tvPaths.Nodes.Clear();
                        tvPaths.Nodes.Add("", remoteMachineName, 3);

                        TreeNode firstNode = tvPaths.Nodes[0];
                        firstNode.SelectedImageIndex = 3;

                        foreach (String drive in serverData.directories)
                        {
                            firstNode.Nodes.Add("", drive + "\\", 0);
                        }

                        allowNodeToExpandOrCollapse = true;
                        firstNode.Expand();

                        if(firstNode.Nodes.Count > 0) { tvPaths.SelectedNode = firstNode.Nodes[0]; }

                        lblStatus.Text = "Folders updated.";
                        ThreadPool.QueueUserWorkItem((o) =>
                        {
                            Thread.Sleep(3000);
                            UI(() => lblStatus.Text = "Idle.");
                        });
                    });
                }

                if (serverData.type.Equals("getcontents"))
                {
                    // This code needs to be run on the UI thread:
                    UI(() =>
                    {
                        lvFiles.Items.Clear();
                        ListViewItem lvi;
                        String[] parts;
                        String tmp = "";

                        // Was there an error?
                        if (serverData.errorInfo != null)
                        {
                            // If so, show it:
                            MessageBox.Show(serverData.errorInfo, "There was an error accessing the folder \"" + tvPaths.SelectedNode.Text + "\"", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        List<TreeNode> tvDirectories                        = new List<TreeNode>();
                        List<ListViewItem> lvDirectories                    = new List<ListViewItem>();
                        List<RemoteFileSystem.Client.RemoteFileinfo> files  = new List<RemoteFileSystem.Client.RemoteFileinfo>();

                            // Create Treenode objects for our directories:
                        foreach (String directory in serverData.directories)
                        {
                            parts = Regex.Split(directory, @"\\");
                            tvDirectories.Add(new TreeNode(parts[parts.Length - 1], 2, -1));

                            lvi = new ListViewItem(parts[parts.Length - 1]);
                            lvi.SubItems.Add("");
                            lvi.SubItems.Add("File Folder");
                            lvi.SubItems.Add("");
                            lvi.ImageIndex = 2;
                        
                            lvDirectories.Add(lvi);
                        }

                        // Add our files and folders to the listview:
                        if(lvDirectories.Count > 0) { lvFiles.Items.AddRange(lvDirectories.ToArray()); }
                        foreach (RemoteFileSystem.Client.RemoteFileinfo file in serverData.files)
                        {
                            lvi                 = new ListViewItem(file.name);
                            lvi.ImageIndex      = 1;
                            lvi.SubItems.Add(file.lastModified.ToShortDateString());

                            if(file.size <= 1024)
                            {
                                tmp = file.size.ToString();
                            } else if (file.size > 1024 && file.size <= 1024000)
                            {
                                tmp = (file.size / 1024) + " K";
                            } else
                            {
                                tmp = (file.size / 1024000) + " MB";
                            }

                            lvi.SubItems.Add("File");
                            lvi.SubItems.Add(tmp);
                            lvFiles.Items.Add(lvi);
                        }

                        // If directories were sent...
                        if (tvDirectories.Count > 0)
                        {
                            // And there are no child nodes under our selected node,
                            if (tvPaths.SelectedNode.Nodes.Count == 0)
                            {
                                // Add all the directories that were sent
                                tvPaths.SelectedNode.Nodes.AddRange(tvDirectories.ToArray());

                                lblStatus.Text = "Folders updated.";
                                ThreadPool.QueueUserWorkItem((o) =>
                                {
                                    Thread.Sleep(3000);
                                    UI(() => lblStatus.Text = "Idle.");
                                });

                                return;
                            }
                            else
                            {
                                // There ARE child nodes under this one, and the end user may have drilled down into
                                // some of the subdirectories, making them visible. So:

                                // Do we need to remove any of the existing nodes (Maybe they've been deleted since the last time this was refreshed)?
                                bool foundIt = false;
                                List<TreeNode> toBeRemoved = new List<TreeNode>();
                                // So we check each one of the existing nodes...
                                foreach (TreeNode existingNode in tvPaths.SelectedNode.Nodes)
                                {
                                    foundIt = false;
                                    // Against the new list, and
                                    foreach (TreeNode newNode in tvDirectories)
                                    {
                                        // If it is not found there,
                                        if (newNode.Text.Equals(existingNode.Text)) { foundIt = true; break; }
                                    }
                                    if (!foundIt)
                                    {
                                        // Add it to a list of directories to be removed.
                                        toBeRemoved.Add(existingNode);
                                    }
                                }

                                // Do we need to ADD any new nodes (Maybe they've been created since the last time this was refreshed)?
                                List<TreeNode> toBeAdded = new List<TreeNode>();
                                // We need to check each one of the new list's nodes...
                                foreach (TreeNode node in tvDirectories)
                                {
                                    foundIt = false;
                                    // Against the existing list of nodes, and 
                                    foreach (TreeNode existingNode in tvPaths.SelectedNode.Nodes)
                                    {
                                        // If a new list node doesn't exist among the existing ones,
                                        if (node.Text.Equals(existingNode.Text)) { foundIt = true; break; }
                                    }
                                    // Add it to a list of nodes to be added.
                                    if (!foundIt) { toBeAdded.Add(node); }
                                }

                                // Remove the nodes earmarked for removal, and
                                if (toBeRemoved.Count > 0)
                                {
                                    foreach (TreeNode node in toBeRemoved)
                                    {
                                        tvPaths.SelectedNode.Nodes.Remove(node);
                                    }
                                }

                                // Add the new ones.
                                if (toBeAdded.Count > 0)
                                {
                                    foreach (TreeNode node in toBeAdded)
                                    {
                                        tvPaths.SelectedNode.Nodes.Add(node);
                                    }
                                }
                            }
                        }

                        lblStatus.Text = "Folders updated.";
                        ThreadPool.QueueUserWorkItem((o) =>
                        {
                            Thread.Sleep(3000);
                            UI(() => lblStatus.Text = "Idle.");
                        });
                    });
                }

                // getfilesin server replies are lists of files and folders within a folder you inquired about.
                // This functionality exists so that you can ask transfer folders from the server to your local machine.
                if (serverData.type.Equals("getfilesin"))
                {
                    String sourcePath = serverData.path;
                    FolderCopyData thisFolderCopy = null;

                    foreach(FolderCopyData folder in copy.folders)
                    {
                        if(folder.folder.Equals(sourcePath))
                        {
                            thisFolderCopy = folder;
                            break;
                        }
                    }

                    if(thisFolderCopy.Equals(null))
                    {
                        MessageBox.Show("We just received folder info, but we don't have a folder copy in progress!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    thisFolderCopy.size = serverData.size;
                    
                    foreach(RemoteFileSystem.Client.RemoteFileinfo file in serverData.files)
                    {
                        thisFolderCopy.files.Add(new FolderCopyData.File() { name = file.name, size = file.size });
                    }

                    thisFolderCopy.loaded = true;
                }
            });

            // We initialize the CopyFiles helper class here because only at this point 
            // is the rfsClient object not null anymore.
            copy = new CopyFiles(this, ref rfsClient, ref tcpClient, (String msg) =>
            {
                UI(() => lblStatus.Text = msg);
            });
        }

        private void tvPaths_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lblStatus.Text = "Requesting folder contents from the server...";
            UpdateFolderContents();
        }

        private void tvPaths_AfterExpand(object sender, TreeViewEventArgs e)
        {
            lblStatus.Text = "Requesting folder contents from the server...";
            UpdateFolderContents();
        }
        
        /// <summary>
        /// Returns the currently selected path of the viewer - the currently selected path of the 
        /// remote machine.
        /// </summary>
        /// <returns></returns>
        public String GetCurrentPath()
        {
            String path = "";
            bool complete = false;

            UI(() =>
            {
                if (tvPaths.SelectedNode == null) { path = remoteMachineName; complete = true; return; }

                if(tvPaths.SelectedNode.Text.Equals(remoteMachineName))
                {
                    if(tvPaths.SelectedNode.Nodes.Count > 0) { tvPaths.SelectedNode = tvPaths.SelectedNode.Nodes[0]; }
                }

                TreeNode tn = tvPaths.SelectedNode;
                path = tn.Text;

                if (path.Equals(remoteMachineName)) { complete = true; return; }

                if (tn.Parent.Text == remoteMachineName)
                {
                    tn.SelectedImageIndex = 0;
                }
                else
                {
                    tn.SelectedImageIndex = 2;
                }

                while (tn.Parent.Text != remoteMachineName)
                {
                    path = (!tn.Parent.Text.EndsWith(@"\")) ? tn.Parent.Text + @"\" + path : tn.Parent.Text + path;
                    tn = tn.Parent;
                }

                currentPath.Text = path;
                complete = true;
            });

            // Wait for the code on the UI thread to complete. 
            // Only then will path contain the complete path:
            while (!complete)
            {
                // We need to either sleep or DoEvents(), 
                // depending on weather we're on the UI thread or not:
                if (tvPaths.InvokeRequired) { Thread.Sleep(1); } else { Application.DoEvents(); }
            }

            return path;
        }

        // Refresh the currently selected folder on the viewer.
        private void UpdateFolderContents()
        {
            String path = GetCurrentPath();
            if (path.Equals(remoteMachineName)) { return; }
            rfsClient.GetContents(GetCurrentPath());
        }

        private void lvFiles_DoubleClick(object sender, EventArgs e)
        {
            if(lvFiles.SelectedItems.Count > 0)
            {
                if(lvFiles.SelectedItems[0].SubItems[2].Text.Equals("File Folder"))
                {
                    String folderName = lvFiles.SelectedItems[0].Text;
                    TreeNode selectedNode = tvPaths.SelectedNode;

                    foreach(TreeNode node in selectedNode.Nodes)
                    {
                        if(node.Text.Equals(folderName))
                        {
                            allowNodeToExpandOrCollapse = false;
                            tvPaths.SelectedNode = node;
                            break;
                        }
                    }

                }
            }
        }

        private void tvPaths_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            if(!allowNodeToExpandOrCollapse) { e.Cancel = true; return; }
        }

        private void tvPaths_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if(!allowNodeToExpandOrCollapse) { e.Cancel = true; return; }
        }

        private void tvPaths_DoubleClick(object sender, EventArgs e)
        {
            allowNodeToExpandOrCollapse = true;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if(!(tvPaths.SelectedNode.Parent == null) && !tvPaths.SelectedNode.Parent.Text.Equals(remoteMachineName)) tvPaths.SelectedNode = tvPaths.SelectedNode.Parent;
            } catch (Exception) { /* This will catch null refrence exceptions fired if you click it while it's it the top node. */}
        }

        private void tvPaths_MouseDown(object sender, MouseEventArgs e)
        {
            //   check if clicked on node's plus/minus sign
            TreeViewHitTestInfo info = tvPaths.HitTest(e.X, e.Y);
            if (info != null && info.Location == TreeViewHitTestLocations.PlusMinus)
            {
                //   in that case, allow expand/collapse
                allowNodeToExpandOrCollapse = true;
            }
            else
            {
                //   otherwise don't allow expand/collapse
                allowNodeToExpandOrCollapse = false;
            }
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            colRemoteSystem.Width = lvRemoteSystemHeader.Width - 10;
        }

        // Connect to or disconnect from our remote machine.
        private void btConnect_Click(object sender, EventArgs e)
        {
            String errMsg = "";
            if(tcpClient.isClientRunning())
            {
                try
                {
                    tcpClient.Close();
                } catch (Exception) { }

                lblStatus.Text = "Disconnected.";
                lvFiles.Items.Clear();
                tvPaths.Nodes.Clear();
            } else
            {

                errMsg = IP + ":" + remotePort.ToString();
                remoteMachineName = Regex.Split(errMsg, ":")[0].Trim();
                    try
                    {
                        remotePort = UInt16.Parse(Regex.Split(errMsg, ":")[1].Trim());
                    }
                    catch (Exception) { return; }

                    if (!tcpClient.Connect(remoteMachineName, remotePort, "RFSClient", ref errMsg))
                    {
                        lblStatus.Text = "Failed to connect: " + errMsg;
                        MessageBox.Show("Couldn't connect to the server! The error returned is: " + errMsg, "Connection problems", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        lblStatus.Text = "Connected to: " + remotePort;
                        StartRFS();
                    }
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            tcpClient.Close();
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            tcpClient.CancelIncomingFileTransfer();
            copy.doTransfer = false;
        }

        public void BringForward()
        {
            SetForegroundWindow(Handle.ToInt32());
        }

        private void lvFiles_MouseDown(object sender, MouseEventArgs e)
        {
            dragDropHelper.MouseDownHandler(e, () =>
            {
                if (lvFiles.SelectedItems.Count > 0)
                {
                    dragDropHelper.draggedItems = new String[lvFiles.SelectedItems.Count];
                    for (int count = 0; count < lvFiles.SelectedItems.Count; count++)
                    {
                        dragDropHelper.draggedItems[count] = lvFiles.SelectedItems[count].Text;
                    }
                }
            });
        }

        private void lvFiles_MouseMove(object sender, MouseEventArgs e)
        {
            dragDropHelper.MouseMoveHandler(e, lvFiles);
        }

        private void lvFiles_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void CerrarBox_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MiniBox_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void SteamBox_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(tvPaths.SelectedNode.Parent == null) && !tvPaths.SelectedNode.Parent.Text.Equals(remoteMachineName)) tvPaths.SelectedNode = tvPaths.SelectedNode.Parent;
            }
            catch (Exception) { /* This will catch null refrence exceptions fired if you click it while it's it the top node. */}
        }

        private void frmRfs_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void frmRfs_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Location = new Point((Location.X - lastLocation.X) + e.X, (Location.Y - lastLocation.Y) + e.Y);
                Update();
                Opacity = 0.93;
            }
        }

        private void frmRfs_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            Opacity = 100;
        }

        private void CerrarBox_MouseMove(object sender, MouseEventArgs e)
        {
            CerrarBox.Image = Resources.CerrarNormal_2;
        }

        private void CerrarBox_MouseLeave(object sender, EventArgs e)
        {
            CerrarBox.Image = Resources.CerrarNormal_1;
        }

        private void MiniBox_MouseMove(object sender, MouseEventArgs e)
        {
            MiniBox.Image = Resources.MinimizeNormal_2;
        }

        private void MiniBox_MouseLeave(object sender, EventArgs e)
        {
            MiniBox.Image = Resources.MinimizeNormal_1;
        }

        private void frmRfs_DoubleClick(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                MiniBox.Hide();
                CerrarBox.Hide();
            }
            else
            {
                WindowState = FormWindowState.Normal;
                MiniBox.Show();
                CerrarBox.Show();
            }

        }
    }
}
