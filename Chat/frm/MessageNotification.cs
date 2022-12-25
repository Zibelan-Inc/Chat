using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Chat.Properties;

namespace Chat
{
    public partial class MessageNotification : Notification
    {
        public string kkey;
        public string acount;
        private string _chan;
        private bool _video;
        private string _sname;
        private string _title;
        private Message _defaultMessage;
        public delegate void MessageClickedEventHandler(string chatKey);
        private MessageClickedEventHandler MessageClickedEvent;
        private acceptEventHandler acceptEvent;

        public event cancelEventHandler cancel
        {
            [CompilerGenerated]
            add
            {
                cancelEventHandler cancelEventHandler = cancelEvent;
                cancelEventHandler cancelEventHandler2;
                do
                {
                    cancelEventHandler2 = cancelEventHandler;
                    cancelEventHandler value2 = (cancelEventHandler)Delegate.Combine(cancelEventHandler2, value);
                    cancelEventHandler = Interlocked.CompareExchange(ref cancelEvent, value2, cancelEventHandler2);
                }
                while ((object)cancelEventHandler != cancelEventHandler2);
            }
            [CompilerGenerated]
            remove
            {
                cancelEventHandler cancelEventHandler = cancelEvent;
                cancelEventHandler cancelEventHandler2;
                do
                {
                    cancelEventHandler2 = cancelEventHandler;
                    cancelEventHandler value2 = (cancelEventHandler)Delegate.Remove(cancelEventHandler2, value);
                    cancelEventHandler = Interlocked.CompareExchange(ref cancelEvent, value2, cancelEventHandler2);
                }
                while ((object)cancelEventHandler != cancelEventHandler2);
            }
        }
        private cancelEventHandler cancelEvent;
        public delegate void cancelEventHandler(string str, string sname);





        public delegate void acceptEventHandler(string str, string chan, string sname);

        public event acceptEventHandler accept
        {
            [CompilerGenerated]
            add
            {
                acceptEventHandler acceptEventHandler = acceptEvent;
                acceptEventHandler acceptEventHandler2;
                do
                {
                    acceptEventHandler2 = acceptEventHandler;
                    acceptEventHandler value2 = (acceptEventHandler)Delegate.Combine(acceptEventHandler2, value);
                    acceptEventHandler = Interlocked.CompareExchange(ref acceptEvent, value2, acceptEventHandler2);
                }
                while ((object)acceptEventHandler != acceptEventHandler2);
            }
            [CompilerGenerated]
            remove
            {
                acceptEventHandler acceptEventHandler = acceptEvent;
                acceptEventHandler acceptEventHandler2;
                do
                {
                    acceptEventHandler2 = acceptEventHandler;
                    acceptEventHandler value2 = (acceptEventHandler)Delegate.Remove(acceptEventHandler2, value);
                    acceptEventHandler = Interlocked.CompareExchange(ref acceptEvent, value2, acceptEventHandler2);
                }
                while ((object)acceptEventHandler != acceptEventHandler2);
            }
        }
        public event MessageClickedEventHandler MessageClicked
        {
            [CompilerGenerated]
            add
            {
                MessageClickedEventHandler messageClickedEventHandler = MessageClickedEvent;
                MessageClickedEventHandler messageClickedEventHandler2;
                do
                {
                    messageClickedEventHandler2 = messageClickedEventHandler;
                    MessageClickedEventHandler value2 = (MessageClickedEventHandler)Delegate.Combine(messageClickedEventHandler2, value);
                    messageClickedEventHandler = Interlocked.CompareExchange(ref MessageClickedEvent, value2, messageClickedEventHandler2);
                }
                while ((object)messageClickedEventHandler != messageClickedEventHandler2);
            }
            [CompilerGenerated]
            remove
            {
                MessageClickedEventHandler messageClickedEventHandler = MessageClickedEvent;
                MessageClickedEventHandler messageClickedEventHandler2;
                do
                {
                    messageClickedEventHandler2 = messageClickedEventHandler;
                    MessageClickedEventHandler value2 = (MessageClickedEventHandler)Delegate.Remove(messageClickedEventHandler2, value);
                    messageClickedEventHandler = Interlocked.CompareExchange(ref MessageClickedEvent, value2, messageClickedEventHandler2);
                }
                while ((object)messageClickedEventHandler != messageClickedEventHandler2);
            }
        }
        public MessageNotification()
        {
            InitializeComponent();
        }
        public MessageNotification(string message, string ckey, string alertcount, Message defaultMessage = null, Image img = null, bool mail = false, bool unreadmail = false, bool note = false, bool callrequest = false, string sname = "", string chan = "", bool video = false, string title = "", string notifyKey = "")
    : base(message, 170)
        {
  //          base.FormClosed += MessageNotification_FormClosed;
 //           base.FormClosing += MessageNotification_FormClosing;
 //           base.Paint += MessageNotification_Paint;
            kkey = string.Empty;
            acount = string.Empty;
            _chan = "";
            _video = false;
            _sname = "";
            _title = "";
            DoubleBuffered = true;
            kkey = ckey;
            if (Conversions.ToInteger(alertcount) >= 0)
            {
                acount = Conversions.ToString(checked(Conversions.ToInteger(alertcount) + 1));
            }
            _defaultMessage = defaultMessage;
            Mmail = mail;
            Notes = note;
            UnReadmails = unreadmail;
            _video = video;
            _sname = sname;
            _chan = chan;
            _title = title;
            _callrequest = callrequest;
            if (_callrequest || _video)
            {
                img = null;
            }
            NotificationKey = notifyKey;
            InitializeComponent();
            lblPhoto.Image = img;
            lbltitle1.Text = Modcommon.PRODUCT_NAME;
            lblTest.Text = message;
            lblChat.Text = message;
            lblDisplayName.Visible = true;
            if (!Notes)
            {
                SplitMessageAndDisplayName(message);
            }
            if (Modcommon.IsRTL(message))
            {
                lblChat.RightToLeft = RightToLeft.Yes;
            }
            lblTitle.Text = "";
            if (!Mmail && !string.IsNullOrEmpty(lblDisplayName.Text))
            {
                lblTest.Tag = 70;
                lblPhoto.Visible = false;
            }
            else
            {
                if (img != null)
                {
                    AvailableImage = true;
                    lblPhoto.Visible = true;
                }
                pnlTop.Visible = false;
                pnlbot.Padding = new Padding(0);
                lblTest.Tag = 60;
            }
            if (mail)
            {
                lblpin.Visible = true;
                if (Modcommon.PIN_MSGWINDOW)
                {
                    lblpin.Image = Resources.pinleft;
                }
                else
                {
                    lblpin.Image = Resources.pinstraight;
                }
            }
            if (_callrequest)
            {
                pnlcall.Visible = true;
            }
            else
            {
                pnlcall.Visible = false;
            }
        }
        private string SplitMessageAndDisplayName(string msg)
        {
            string[] array = Strings.Split(msg, ":");
            if (array.Length > 1)
            {
                lblDisplayName.Text = array[0] + ":";
                lblChat.Text = string.Join(":", array, 1, checked(array.Length - 1)).Trim();
                Textt = lblChat.Text;
            }
            else
            {
                lblDisplayName.Visible = false;
            }
            string result = default(string);
            return result;
        }
        public void ChangeMessage(string message)
        {
            try
            {
                lblTest.Text = message;
                lblChat.Text = message;
                Textt = message;
                ResetTimer();
                Refresh();
                lblChat.Refresh();
                Invalidate();
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                WriteLog.Save(ex2);
                ProjectData.ClearProjectError();
            }
        }


    }
}
