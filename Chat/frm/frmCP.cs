using System;
using System.Collections;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using mshtml;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;
using Chat.Properties;

namespace Chat //En OM.Client aparece FileListener
{
    public partial class frmCP : frmResize
    {
        //Settings
        public static frmCP frm;
        private bool mouseDown;     //Mover ventana
        private Point lastLocation; //Mover ventana
        public string To; //Mover ventana

        /////////////////////////////////////////////////////////////////////////

        public IEnumerator enumerator;
        public bool _SExit;
        public bool _Exit;
        public bool deactivatemain;
        public bool _isSplitterMoving;
        public string _searchPluginName;
        public bool _hidesearch;
        public static FlowLayoutPanel pnlAnnouncement = new FlowLayoutPanel();
        //private UserHost _userHost;
        private string[] _args;
        public Panel pnlChatDetail;
        public string Selrowkey;
        public MessengerColumn Dc;
        public static Image picfrom;
        public static Image picto;
        //Chat
        public static Form SettingsForm = null;
        public bool saveOnExit;
        public bool Muted;
        public bool alive = true;
        public RegistryKey Chat;

        //Servidor Ficheros
        public bool topNivel;
        public string _activePluginName { get; set; }
        public string ChatID { get; internal set; }
        public frmCP(string ChatId)
        {
            InitializeComponent();
            frmMain.frm.Transmit("FormStatus", "true");
            CheckForIllegalCrossThreadCalls = false;  //Para permitir acceso a los subprocesos
            frm = this;
            ChatID = ChatId;
            webChat.AllowWebBrowserDrop = true; //Picha pero me carga lo que suelto
            webChat.Navigate("about:blank");
            while (webChat.Document == null || webChat.Document.Body == null)
                Application.DoEvents();

            webChat.Document.OpenNew(true).Write($"<html><body style='background-color: rgb(26,32,47)'></body><head>" +
                                           $"{HtmlHelper.GetHtmlIEVersion()}" +
                                           $"<title name = 'head'>KosmoChat</title>" +
                                           $"</head><body class='body'><br>");
            //webChat.Navigating += new WebBrowserNavigatingEventHandler(webChat_Navigating);
            //webChat.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(OnDocumentCompleted);

            //MasterInitiate();
            AssignStyleSheet(webChat);


            string[] users = ChatId.Split('◄');

            if (users[0] != frmMain.NickName)
                picfrom = LetterImage.GetUserImage(users[0]);
            else
                picfrom = LetterImage.GetUserImage(users[1]);

            picFrom.Image = Modcommon.CropToCircle(picfrom);


            lblWelcomeUserPanel.Text = "Conversación privada entre " + Environment.NewLine + Modcommon.GetNamefromID(users[0]) + " y " + Modcommon.GetNamefromID(users[1]);


            Tag = ChatID;
            txtSend.Focus();
        }

        public void AssignStyleSheet(WebBrowser wBrowser)
        {
            string name = webChat.Name;
            IHTMLStyleSheet2 instance = (IHTMLStyleSheet2)((IHTMLDocument2)webChat.Document.DomDocument).createStyleSheet("", 0);

            NewLateBinding.LateSet(instance, null, "cssText", new object[1]
            {
                HtmlHelper.GetStyles() + "\r\n" + css.GetMyCSS()
            }, null, null);

            HtmlElement htmlElement = webChat.Document.GetElementsByTagName("head")[0];
            HtmlElement htmlElement2 = webChat.Document.CreateElement("script");
            IHTMLScriptElement iHTMLScriptElement = (IHTMLScriptElement)htmlElement2.DomElement;

            iHTMLScriptElement.text = HtmlHelper.GetJavascript();

            htmlElement.AppendChild(htmlElement2);
        }

        public void WireUpButtonEvents()
        {
            HtmlElementCollection elements = webChat.Document.GetElementsByTagName("IMG");
            for (int i = 0; i < elements.Count; i++)
            {
                HtmlElement el = elements[i];
                el.AttachEventHandler("ondblclick", (sender, args) => OnElementClicked(el, EventArgs.Empty));
            }
            HtmlElementCollection body = webChat.Document.GetElementsByTagName("BODY");
            for (int i = 0; i < body.Count; i++)
            {
                HtmlElement el = body[i];
                el.AttachEventHandler("onclick", (sender, args) => OnElementSelect(el, EventArgs.Empty));
            }
        }

        protected void OnElementSelect(object sender, EventArgs args)
        {
            //Hecho por mi
            string selection = webChat.Document.InvokeScript("getSelectionText").ToString();
            if (!string.IsNullOrEmpty(selection))
            {
                Clipboard.Clear();
                Clipboard.SetText(selection, TextDataFormat.UnicodeText);
            }
        }

        protected void OnElementClicked(object sender, EventArgs args)
        {
            HtmlElement el = sender as HtmlElement;
            string elType = el.GetAttribute("type");
            string elName = el.GetAttribute("name");
            string elValue = el.GetAttribute("value");

            HtmlHelper.OpenFile(Modcommon.convertURI(el.Id));
        }


        private void MP_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void MP_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            Opacity = 100;
        }

        private void MP_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Location = new Point((Location.X - lastLocation.X) + e.X, (Location.Y - lastLocation.Y) + e.Y);
                Update();
                Opacity = 0.93;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            txtSend.Focus();

        }

        private void ChangeActiveColor()
        {
            this.ChangeControlBGColor(Color.FromArgb(49, 140, 231));
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            try
            {
                txtSend.Focus();
                if (this.Location.X < 0 || this.Location.Y < 0)
                    this.BringToFront();
                this.ChangeActiveColor();
                this.deactivatemain = false;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                WriteLog.Save(ex);
                ProjectData.ClearProjectError();
            }


        }

        private void frmMain_Deactivate(object sender, EventArgs e)
        {
            try
            {
                this.ChangeDeActiveColor();
                this.deactivatemain = true;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                WriteLog.Save(ex);
                ProjectData.ClearProjectError();
            }

        }

        private void ChangeDeActiveColor()
        {
            this.ChangeControlBGColor(ColorTranslator.FromHtml("#AAAAAA"));
        }

        private void ChangeControlBGColor(Color clr)
        {
            try
            {
                this.SuspendLayout();
                this.BackColor = clr;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                WriteLog.Save(ex);
                ProjectData.ClearProjectError();
            }
            this.ResumeLayout();
        }
        private void frmMain_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Rectangle rect = new Rectangle(1, 1, checked(this.Width - 2), checked(this.Height - 2));
                using (SolidBrush solidBrush = new SolidBrush(Color.White))
                    e.Graphics.FillRectangle((Brush)solidBrush, rect);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
            }
        }

        private void ChangeCloseMinMaxBg(Label lbl)
        {
            try
            {
                Color color = Template.RIGHT_HEADER_COLOR;
                lbl.BackColor = color;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                WriteLog.Save(ex);
                ProjectData.ClearProjectError();
            }
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            if (!Modcommon.DEFAULTVIEW)
                Modcommon.MAIN_CLOSE = true;
            this.Close();
        }
        private void lblClose_MouseEnter(object sender, EventArgs e)
        {
            this.lblClose.BackColor = Color.Red;
        }

        private void lblClose_MouseLeave(object sender, EventArgs e)
        {
            this.ChangeCloseMinMaxBg(this.lblClose);
        }
        
        public void Crearlog(Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            WriteLog.Save(ex2);
            ProjectData.ClearProjectError();

        }



        private void txtSend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                //Con esto se arregla
                if (!string.IsNullOrEmpty(txtSend.Text) && txtSend.Text != "")
                {
                    string message = txtSend.Text;

                    CP ChatPricado = new CP();
                    ChatPricado.From = frmMain.NickName;
                    ChatPricado.To = To;
                    ChatPricado.Content = txtSend.Text;
                    if (string.IsNullOrEmpty(ChatID))
                    {
                        ChatID = Modcommon.GetChatId(frmMain.NickName, To);
                        Tag = ChatID;
                    }
                    ChatPricado.ChatID = ChatID;

                    frmMain.frm.Transmit("cp", ChatPricado.ToJson());
                }
                txtSend.Text = string.Empty;
                e.SuppressKeyPress = true;

                txtSend.Controls.Clear();
                return;
            }

            Modcommon.ProcessKey(e);
        }
        public void WriteMessage(string Mensage, string ID, string Nick, int actionColor)
        {
            try
            {
                Application.DoEvents();

                //Bubble Message 
                WriteChat(HtmlHelper.GetNameHtml(ID, DateTime.Now) + HtmlHelper.GetMessage(ID, Modcommon.ProcessMessageLength(Mensage), actionColor.ToString()));

                SoundPlayer beep = new SoundPlayer(Resources.beep1);
                if (!frmMain.Muted)
                    beep.Play();
            }
            catch { }
        }
        public void WriteChat(string content)
        {
            webChat.Document.Write(content);
            webChat.Document.Window.ScrollTo(0, webChat.Document.Body.ScrollRectangle.Height);
            WireUpButtonEvents();
        }









        /*
        .
        .
        .
        */
    }
}
