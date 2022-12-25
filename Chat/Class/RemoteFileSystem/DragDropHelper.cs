// Most of the code in this helper class was found here:
// https://www.codeproject.com/Articles/23207/Drag-and-Drop-to-Windows-Folder-C
// I took Mr. Joy's example project, distilled it into this helper class and 
// edited it to suit my needs. I also added the Explorer class, so I could quickly
// refresh explorer windows and windows desktop - making Mr. Joy's dropped file 
// invisible even when the desktop is the target.

using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Chat
{
    public static class Explorer
    {
        [DllImport("Shell32.dll")]
        private static extern int SHChangeNotify(int eventId, int flags, IntPtr item1, IntPtr item2);

        public static void Refresh(bool changeNotifyDesktop = false)
        {
            Guid CLSID_ShellApplication = new Guid("13709620-C279-11CE-A49E-444553540000");
            Type shellApplicationType = Type.GetTypeFromCLSID(CLSID_ShellApplication, true);

            object shellApplication = Activator.CreateInstance(shellApplicationType);
            object windows = shellApplicationType.InvokeMember("Windows", BindingFlags.InvokeMethod, null, shellApplication, new object[] { });

            Type windowsType = windows.GetType();
            object count = windowsType.InvokeMember("Count", BindingFlags.GetProperty, null, windows, null);
            for (int i = 0; i < (int)count; i++)
            {
                object item = windowsType.InvokeMember("Item", BindingFlags.InvokeMethod, null, windows, new object[] { i });
                Type itemType = item.GetType();

                // only refresh windows explorers
                string itemName = (string)itemType.InvokeMember("Name", BindingFlags.GetProperty, null, item, null);
                if (itemName == "Windows Explorer")
                {
                    itemType.InvokeMember("Refresh", BindingFlags.InvokeMethod, null, item, null);
                }
            }

            if(changeNotifyDesktop) SHChangeNotify(0x8000000, 0x1000, IntPtr.Zero, IntPtr.Zero);
        }
    }

    internal static class Util
    {
        public static Hashtable StatusForms = new Hashtable();

        public static Hashtable PropertyForms = new Hashtable();

        public static Hashtable ChatForms = new Hashtable();

        public static Hashtable ChatBottomForms = new Hashtable();

        public static Hashtable GroupChatForms = new Hashtable();

        public static Hashtable MailForms = new Hashtable();

        public static Hashtable AnnouncementForms = new Hashtable();

        public static Hashtable ReminderForms = new Hashtable();

        public static Hashtable NotesForms = new Hashtable();

        public static Hashtable LanguageText = new Hashtable();

        public static Hashtable FileWorkers = new Hashtable();

        public static Hashtable PluginForms = new Hashtable();

        public static Hashtable DeskForms = new Hashtable();
        internal static void CreateDragItemTempFile(string dragItemTempFileName)
        {
            FileStream fsDropFile = null;

            try
            {
                fsDropFile = new FileStream(dragItemTempFileName, FileMode.Create);
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "DragNDrop Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (fsDropFile != null)
                {
                    fsDropFile.Flush();
                    fsDropFile.Close();
                    fsDropFile.Dispose();
                }
            }
        }
    }

    public class DragDropHelper
    {
        #region Member Variables
        string dragItemTempFileName = string.Empty;
        private bool itemDragStart = false;
        #endregion

        #region Variables
        internal const string DRAG_SOURCE_PREFIX = "__RFS-DRAGTODESKTOP-HELPER__Temp__";
        public String[] draggedItems;
        private static FileSystemWatcher tempDirectoryWatcher;
        public static Hashtable watchers = null;
        #endregion

        public delegate void FilesDropped(String targetPath);
        public FilesDropped filesDropped;

        public DragDropHelper(FilesDropped filesDropped)
        {
            this.filesDropped                           = filesDropped;
            tempDirectoryWatcher                        = new FileSystemWatcher();
            tempDirectoryWatcher.Path                   = Path.GetTempPath();
            tempDirectoryWatcher.Filter                 = string.Format("{0}*.tmp", DRAG_SOURCE_PREFIX);
            tempDirectoryWatcher.NotifyFilter           = NotifyFilters.FileName;
            tempDirectoryWatcher.IncludeSubdirectories  = false;
            tempDirectoryWatcher.EnableRaisingEvents    = true;
            tempDirectoryWatcher.Created               += new FileSystemEventHandler(TempDirectoryWatcherCreated);
        }

        #region FileSystemWatcher Methods
        /// <summary>
        /// A temp file is created in the temp folder with the prefix wen a drag is initiated
        /// At that point we will add a filesystem watch to all the Logical Drives present.
        /// And will clear the watchers when the drag is completed or canceled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TempDirectoryWatcherCreated(object sender, FileSystemEventArgs e)
        {
            try
            {
                CreateFileWatchers();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// This Event is triggered when the temp file created is Dropped into the target folder.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileWatcherCreated(object sender, FileSystemEventArgs e)
        {
            try
            {
                OnFileDropPathFound(e.FullPath);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Methodd Called when the Dropped Path is found
        /// </summary>
        /// <param name="dropedFilePath"></param>
        private void OnFileDropPathFound(string dropedFilePath)
        {
            try
            {
                if (dropedFilePath.Trim() != string.Empty && draggedItems != null)
                {
                    String dropPath = dropedFilePath.Substring(0, dropedFilePath.LastIndexOf('\\'));
                    
                    if (File.Exists(dropedFilePath))
                        File.Delete(dropedFilePath);

                    // Remove the visible file from the desktop 
                    // if the drop happend to be to the desktop:
                        Explorer.Refresh(dropPath.ToLower().Contains("desktop"));

                        filesDropped(dropPath);                  
                }
                draggedItems = null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Creating File Watchers for all Logical Drives in the System
        /// </summary>
        public void CreateFileWatchers()
        {
            try
            {
                if (watchers == null)
                {
                    int i = 0;
                    Hashtable tempWatchers = new Hashtable();
                    FileSystemWatcher watcher;
                    //Adding FileSystemWatchers and adding Created event to it 
                    foreach (string driveName in Directory.GetLogicalDrives())
                    {
                        //this checking may sound absurd to you.
                        //but in OS like Windows 2000,
                        //even if there is no floppy drive present
                        //An "A:/" will be shown in My Computer.
                        //To avoid exceptions like this I've added this check.
                        if (Directory.Exists(driveName))
                        {
                            watcher = new FileSystemWatcher();
                            watcher.Filter = string.Format("{0}*.tmp", DRAG_SOURCE_PREFIX);
                            watcher.NotifyFilter = NotifyFilters.FileName;
                            watcher.Created += new FileSystemEventHandler(FileWatcherCreated);
                            watcher.IncludeSubdirectories = true;
                            watcher.Path = driveName;
                            watcher.EnableRaisingEvents = true;
                            tempWatchers.Add("file_watcher" + i.ToString(), watcher);
                            i = i + 1;
                        }
                    }
                    watchers = tempWatchers;
                    tempWatchers = null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Removes the FileSystemWatchers watching the Logical Drives
        /// </summary>
        public static void ClearFileWatchers()
        {
            try
            {
                if (watchers != null && watchers.Count > 0)
                {
                    for (int i = 0; i < watchers.Count; i++)
                    {
                        ((FileSystemWatcher)watchers["file_watcher" + i.ToString()]).Dispose();
                    }
                    watchers.Clear();
                    watchers = null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region DragMethods
        public void ClearDragData()
        {
            try
            {
                if (File.Exists(dragItemTempFileName)) { File.Delete(dragItemTempFileName); }
                draggedItems            = null;
                dragItemTempFileName    = string.Empty;
                itemDragStart           = false;
                ClearFileWatchers();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        public delegate void DragItemsSelector();
        public void MouseDownHandler(MouseEventArgs e, DragItemsSelector objDragItemsSelector)
        {
            ClearDragData();

            if (e.Button == MouseButtons.Left && e.Clicks == 1) // && ItemsListView.SelectedItems.Count > 0)
            {
                objDragItemsSelector();
                if(draggedItems != null) itemDragStart = true;
            }
        }

        public void MouseMoveHandler(MouseEventArgs e, Control control)
        {
            if (e.Button == MouseButtons.None)
                return;
            if (itemDragStart && draggedItems != null)
            {
                dragItemTempFileName = string.Format("{0}{1}{2}.tmp", Path.GetTempPath(), DRAG_SOURCE_PREFIX, "");
                try
                {
                    Util.CreateDragItemTempFile(dragItemTempFileName);

                    string[] fileList               = new string[] { dragItemTempFileName };
                    DataObject fileDragData         = new DataObject(DataFormats.FileDrop, fileList);
                    control.DoDragDrop(fileDragData, DragDropEffects.Move);

                    ClearDragData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "DragNDrop Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
    public interface IPluginHost
    {
        void SetDetailActiveWindow(string key);

        void SetAlertIcon(string pluginName, bool saveNotificationCount = true);

        void RemoveAlertIcon(string pluginName, bool saveNotificationCount = true);

        void SetSystemTrayIcon(Icon img);

        void AddAnnouncementToRecentGrid(string msgid);

        void ShowReminderNotification(string chatkey, string msgg);

        void ActivateMain();

        void SetActiveWindowKey(string key);

        void RemoveSystemTrayIcon(Icon img = null);

        void CloseTab(string key);

        Image GetMobileStatusImagePlugin();

        void OpenListForm(string listformFullClassName);

        void OpenChatForm(string toUserKey, string filename, bool send);

        void ShowChatForm(string toUserKey, string message);

        void ShowGroupChatForm(string[] toUserKeys, string message);

        void FlashWindowHandle();

        void ShowSearchBox(string searchText);

        void HideSearchBox();

        Hashtable NotesCollection();

        Hashtable DeskCollection();

        Hashtable LanguageText();

        Hashtable ReminderCollection();

        Hashtable AnnouncementCollection();

        Hashtable GetLanguageList();

        Image GetUsersPhoto(int userID);

        bool IsFileBlock();

        string SearchText();

        string GetFilterUsersList();

        bool GetSpellCheck();

        Color GetLeftPanelBgColor();
    }

}
