using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Chat.Chat
{
    public class HttpServer
    {
        static private HttpListener listener;

        static private int listenerPort;

        static private Thread listenerThread;

        static public bool PlatformNotSupported => listener == null;

        public int ListenerPort
        {
            get
            {
                return listenerPort;
            }
            set
            {
                listenerPort = value;
            }
        }

        public HttpServer(int port)
        {
            listenerPort = port;
            try
            {
                listener = new HttpListener();
                listener.IgnoreWriteExceptions = true;
            }
            catch (PlatformNotSupportedException ex)
            {
                listener = null;
                WriteLog.Save(ex);
            }
        }

        public bool StartHTTPListener()
        {
            if (PlatformNotSupported)
            {
                return false;
            }
            try
            {
                if (listener.IsListening)
                {
                    return true;
                }
                string uriPrefix = "http://+:" + listenerPort + "/";
                listener.Prefixes.Clear();
                listener.Prefixes.Add(uriPrefix);
                listener.Start();
                if (listenerThread == null)
                {
                    listenerThread = new Thread(HandleRequests);
                    listenerThread.Start();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static bool StopHTTPListener()
        {
            if (PlatformNotSupported)
            {
                return false;
            }
            try
            {
                listenerThread.Abort();
                listener.Stop();
                listenerThread = null;
            }
            catch (HttpListenerException)
            {
            }
            catch (ThreadAbortException)
            {
            }
            catch (NullReferenceException)
            {
            }
            catch (Exception)
            {
            }
            return true;
        }

        private void HandleRequests()
        {
            while (listener.IsListening)
            {
                IAsyncResult asyncResult = listener.BeginGetContext(ListenerCallback, listener);
                asyncResult.AsyncWaitHandle.WaitOne();
            }
        }
        HttpListenerContext httpListenerContext;

        private void ListenerCallback(IAsyncResult result)
        {
            HttpListener httpListener = (HttpListener)result.AsyncState;
            if (httpListener != null && httpListener.IsListening)
            {
                try
                {
                    httpListenerContext = httpListener.EndGetContext(result);
                }
                catch (Exception ex)
                {
                    WriteLog.Save(ex);
                    return;
                }
                HttpListenerRequest request = httpListenerContext.Request;

                //MessageBox.Show(request.RawUrl.Substring(1));
                //SendJSON(httpListenerContext.Response);

                string text = request.RawUrl.Substring(1);
                if (text == "data.json")
                {
                    SendJSON(httpListenerContext.Response);
                }
                else if (text.Contains("images_icon"))
                {
                    ServeResourceImage(httpListenerContext.Response, text.Replace("images_icon/", ""));
                }
                else
                {
                    SendHTML(httpListenerContext.Response);
                }
            }
        }
        private void SendHTML(HttpListenerResponse response)
        {

            string Chat = @"
                <!DOCTYPE html>
                    <html>
                        <head>
	                    <title>KosmoChat</title>
                        "+ HtmlHelper.GetHtmlIEVersion() + @"
                           
                        <title name = 'head'>KosmoChat</title>
                        <link rel='" + Modcommon.GetPatch() + @"' />

                        <style type='text/css'>
                        " + css.GetMyCSS() + @"
                        </style>
                        <style type='text/css'>
                        " + css.GetHTMLCSS() + @"
                        </style>

	
</head>
<body class='header-fixed page-sidebar-close page-sidebar-fixed page-sidebar-right' data-bind='css: {'page-sidebar-close': my()==null}'>
	<div id='container'>
		<!-- header -->
		<div class='header navbar navbar-inverse navbar-fixed-top'>
			<div class='container'>
				<div class='navbar-header'>
					<a class='navbar-brand' href='javascript:;'><span class='logo go-home'></span><span class='name'>KosmoChat</span></a>
					<!-- ko if: my -->
					<div class='header-nav' style='display: none' data-bind='visible: my()!=null'>
						<ul class='nav icon-nav'>
							<li><a class='dropdown-toggle' data-toggle='dropdown' href='javascript:;'>
								<img class='my-user-photo' alt='photo' data-bind='photoLoad' /><span data-bind='text:my().detail().display_name()'></span><span class='caret'></span></a>
								<div class='dropdown-menu dropdown-menu-right user-detail-menu hold-on-click' role='menu'>
									<form role='form' onsubmit='return false' data-bind='userDetailMenu'>
									<div class='form-group'>
										<button type='button' class='btn btn-primary' data-bind='click:logout'>
											Logout</button>
									</div>
									</form>
								</div>
							</li>
						</ul>
					</div>
					<!-- /ko -->
				</div>
			</div>
		</div>

				<!-- Login -->
				<!-- ko ifnot: my -->
				<div >
				<table Align='center' border='0' >
                           <tr><td width=60%>

            
					<div >
						<div >
							<!-- ko if: error_message()!='' -->
							<div class='alert alert-danger' data-bind='text:error_message,visible: my()==null' style='display: none'>
							</div>
							<!-- /ko -->
							<div class='panel panel-default' width=100%>
								<div class='panel-heading'>
									<h3 class='panel-title'>
										Conversación en el Chat</h3>
								</div>
								<div class='panel-body'>
									<form class='form-validate' onsubmit='return false' data-bind='loginForm'>
									<div class='form-group'>
                                        <table border='0' width=100%>
                                            <tr><td width=100%>
										        " + frmMain.frm.HtmlString.ToString() + @"
										    </tr></td>
                                        </table>
									</div>
									
									</form>
								</div>
								
							</div>
						</div>
					</div>
					</td>
					<td width=30%>

            
					<div align='top' height=100% width=30%>
						<div >
							<!-- ko if: error_message()!='' -->
							<div class='alert alert-danger' data-bind='text:error_message,visible: my()==null' style='display: none' height=100%>
							</div>
							<!-- /ko -->
							<div class='panel panel-default'  height=100%>
								<div class='panel-heading'>
									<h3 class='panel-title'>
										Usuarios online</h3>
								</div>
								<div class='panel-body'  height=100%>
									<form class='form-validate' onsubmit='return false' data-bind='loginForm'>
									<div class='form-group'>
                                    " +

                                    GetUsers()

                                    + @"
									</div>
									
									</form>
								</div>
								
							</div>
						</div>
					</div>
				</td>
				</tr></table></body></head></html>
				</div>
				
				<!-- /ko -->
				<!-- End Login -->
			</div>
		</div>
	</div>

	<!--[if !IE]> -->

</body>
</html>

            ";


            byte[] bytes = Encoding.UTF8.GetBytes(Chat);
            response.AddHeader("Cache-Control", "no-cache");
            response.ContentLength64 = bytes.Length;
            response.ContentType = "text/html";
            try
            {
                Stream outputStream = response.OutputStream;
                outputStream.Write(bytes, 0, bytes.Length);
                outputStream.Close();
            }
            catch (HttpListenerException)
            {
            }
            response.Close();
        }
        private string GetUsers()
        {
            StringBuilder users = new StringBuilder();
            int rowCount = frmMain.frm.UserList.RowCount;
            int num = checked(rowCount - 1);
            for (int i = 0; i <= num; i = checked(i + 1))
            {
                MessengerCell textAndImageCell = (MessengerCell)frmMain.frm.UserList[0, i];
                users.Append("<table border='0' width=100%>");
                users.Append("<tr><td style='background: #f5f5f5'>");


                users.Append("<span Class='message-data-name' align='left'>");
                users.Append("&nbsp;" + textAndImageCell.UserName);
                users.Append("</span>");

                users.Append($"<span Class='message-data-time' align='right'>{textAndImageCell.Status}</span>");


                //users.Append("</tr><td style='background: #f5f5f5; font-size: 0.7em'>");
                //users.Append(textAndImageCell.status);
                users.Append("</td></tr>");
                users.Append("</table>");
            }

            return users.ToString();
        }
        private void ServeResourceFile(HttpListenerResponse response, string name, string ext)
        {
            name = "OpenHardwareMonitor.Resources." + name.Replace("custom-theme", "custom_theme");
            string[] manifestResourceNames = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            for (int i = 0; i < manifestResourceNames.Length; i++)
            {
                if (manifestResourceNames[i].Replace('\\', '.') == name)
                {
                    using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(manifestResourceNames[i]))
                    {
                        response.ContentType = GetcontentType("." + ext);
                        response.ContentLength64 = stream.Length;
                        byte[] array = new byte[524288];
                        try
                        {
                            Stream outputStream = response.OutputStream;
                            int count;
                            while ((count = stream.Read(array, 0, array.Length)) > 0)
                            {
                                outputStream.Write(array, 0, count);
                            }
                            outputStream.Flush();
                            outputStream.Close();
                            response.Close();
                        }
                        catch (HttpListenerException)
                        {
                        }
                        catch (InvalidOperationException)
                        {
                        }
                    }
                    return;
                }
            }
            response.StatusCode = 404;
            response.Close();
        }

        private void ServeResourceImage(HttpListenerResponse response, string name)
        {
            name = "OpenHardwareMonitor.Resources." + name;
            string[] manifestResourceNames = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            for (int i = 0; i < manifestResourceNames.Length; i++)
            {
                if (manifestResourceNames[i].Replace('\\', '.') == name)
                {
                    using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(manifestResourceNames[i]))
                    {
                        Image image = Image.FromStream(stream);
                        response.ContentType = "image/png";
                        try
                        {
                            Stream outputStream = response.OutputStream;
                            using (MemoryStream memoryStream = new MemoryStream())
                            {
                                image.Save(memoryStream, ImageFormat.Png);
                                memoryStream.WriteTo(outputStream);
                            }
                            outputStream.Close();
                        }
                        catch (HttpListenerException)
                        {
                        }
                        image.Dispose();
                        response.Close();
                    }
                    return;
                }
            }
            response.StatusCode = 404;
            response.Close();
        }

        private void SendJSON(HttpListenerResponse response)
        {
            string s = frmMain.frm.HtmlString.ToString();
            byte[] bytes = Encoding.UTF8.GetBytes(s);
            response.AddHeader("Cache-Control", "no-cache");
            response.ContentLength64 = bytes.Length;
            response.ContentType = "text/html";
            try
            {
                Stream outputStream = response.OutputStream;
                outputStream.Write(bytes, 0, bytes.Length);
                outputStream.Close();
            }
            catch (HttpListenerException)
            {
            }
            response.Close();
        }


        private static void ReturnFile(HttpListenerContext context, string filePath)
        {
            context.Response.ContentType = GetcontentType(Path.GetExtension(filePath));
            byte[] array = new byte[524288];
            using (FileStream fileStream = File.OpenRead(filePath))
            {
                context.Response.ContentLength64 = fileStream.Length;
                int count;
                while ((count = fileStream.Read(array, 0, array.Length)) > 0)
                {
                    context.Response.OutputStream.Write(array, 0, count);
                }
            }
            context.Response.OutputStream.Close();
        }

        private static string GetcontentType(string extension)
        {
            switch (extension)
            {
                case ".avi":
                    return "video/x-msvideo";
                case ".css":
                    return "text/css";
                case ".doc":
                    return "application/msword";
                case ".gif":
                    return "image/gif";
                case ".htm":
                case ".html":
                    return "text/html";
                case ".jpg":
                case ".jpeg":
                    return "image/jpeg";
                case ".js":
                    return "application/x-javascript";
                case ".mp3":
                    return "audio/mpeg";
                case ".png":
                    return "image/png";
                case ".pdf":
                    return "application/pdf";
                case ".ppt":
                    return "application/vnd.ms-powerpoint";
                case ".zip":
                    return "application/zip";
                case ".txt":
                    return "text/plain";
                default:
                    return "application/octet-stream";
            }
        }


        ~HttpServer()
        {
            if (!PlatformNotSupported)
            {
                //StopHTTPListener();
                //listener.Abort();
            }
        }

        public void Quit()
        {
            if (!PlatformNotSupported)
            {
                StopHTTPListener();
                listener.Abort();
            }
        }

        internal static void Stop()
        {
            throw new NotImplementedException();
        }
    }


    public class Node
    {
        public delegate void NodeEventHandler(Node node);

        private class NodeCollection : Collection<Node>
        {
            private Node owner;

            public NodeCollection(Node owner)
            {
                this.owner = owner;
            }

            protected override void ClearItems()
            {
                while (base.Count != 0)
                {
                    RemoveAt(base.Count - 1);
                }
            }

            protected override void InsertItem(int index, Node item)
            {
                if (item == null)
                {
                    throw new ArgumentNullException("item");
                }
                if (item.parent != owner)
                {
                    if (item.parent != null)
                    {
                        item.parent.nodes.Remove(item);
                    }
                    item.parent = owner;
                    base.InsertItem(index, item);
                    if (owner.NodeAdded != null)
                    {
                        owner.NodeAdded(item);
                    }
                }
            }

            protected override void RemoveItem(int index)
            {
                Node node = base[index];
                node.parent = null;
                base.RemoveItem(index);
                if (owner.NodeRemoved != null)
                {
                    owner.NodeRemoved(node);
                }
            }

            protected override void SetItem(int index, Node item)
            {
                if (item == null)
                {
                    throw new ArgumentNullException("item");
                }
                RemoveAt(index);
                InsertItem(index, item);
            }
        }

        private TreeModel treeModel;

        private Node parent;

        private NodeCollection nodes;

        private string text;

        private Image image;

        private bool visible;

        public TreeModel Model
        {
            get
            {
                return treeModel;
            }
            set
            {
                treeModel = value;
            }
        }

        public Node Parent
        {
            get
            {
                return parent;
            }
            set
            {
                if (value != parent)
                {
                    if (parent != null)
                    {
                        parent.nodes.Remove(this);
                    }
                    value?.nodes.Add(this);
                }
            }
        }

        public Collection<Node> Nodes => nodes;

        public virtual string Text
        {
            get
            {
                return text;
            }
            set
            {
                if (text != value)
                {
                    text = value;
                }
            }
        }

        public Image Image
        {
            get
            {
                return image;
            }
            set
            {
                if (image != value)
                {
                    image = value;
                }
            }
        }

        public virtual bool IsVisible
        {
            get
            {
                return visible;
            }
            set
            {
                if (value != visible)
                {
                    visible = value;
                    TreeModel treeModel = RootTreeModel();
                    if (treeModel != null && parent != null)
                    {
                        int num = 0;
                        for (int i = 0; i < parent.nodes.Count; i++)
                        {
                            Node node = parent.nodes[i];
                            if (node == this)
                            {
                                break;
                            }
                            if (node.IsVisible || treeModel.ForceVisible)
                            {
                                num++;
                            }
                        }
                        if (treeModel.ForceVisible)
                        {
                            treeModel.OnNodeChanged(parent, num, this);
                        }
                        else if (value)
                        {
                            treeModel.OnNodeInserted(parent, num, this);
                        }
                        else
                        {
                            treeModel.OnNodeRemoved(parent, num, this);
                        }
                    }
                    if (this.IsVisibleChanged != null)
                    {
                        this.IsVisibleChanged(this);
                    }
                }
            }
        }

        public event NodeEventHandler IsVisibleChanged;

        public event NodeEventHandler NodeAdded;

        public event NodeEventHandler NodeRemoved;

        private TreeModel RootTreeModel()
        {
            for (Node node = this; node != null; node = node.parent)
            {
                if (node.Model != null)
                {
                    return node.Model;
                }
            }
            return null;
        }

        public Node()
            : this(string.Empty)
        {
        }

        public Node(string text)
        {
            this.text = text;
            nodes = new NodeCollection(this);
            visible = true;
        }
    }

    public class TreeModel
    {
        public bool ForceVisible { get; internal set; }

        internal void OnNodeChanged(Node parent, int num, Node node)
        {
            throw new NotImplementedException();
        }

        internal void OnNodeInserted(Node parent, int num, Node node)
        {
            throw new NotImplementedException();
        }

        internal void OnNodeRemoved(Node parent, int num, Node node)
        {
            throw new NotImplementedException();
        }
    }
}
