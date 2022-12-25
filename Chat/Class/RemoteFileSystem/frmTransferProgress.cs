using System;
using System.Windows.Forms;

namespace RemoteFileSystemTester
{
    public partial class frmTransferProgress : Form
    {

        public void UI(Action uiCode)
        {
            try
            {
                if (this.InvokeRequired) { this.Invoke((MethodInvoker)(() => uiCode())); return; }
                uiCode();
            } catch (Exception) { }
        }

        public delegate void Cancel();
        private Cancel cancel;

        public delegate void OverAllProgress(String msg, int currentValue, int maxValue);
        public OverAllProgress overAllProgress;

        public delegate void SetMessage(String msg);
        public SetMessage setMessage;

        public delegate void SetCurrentFileName(String msg);
        public SetCurrentFileName setCurrentFileName;

        public delegate void SetCurrentFileProgress(int value);
        public SetCurrentFileProgress setCurrentFileProgress;

        public delegate void HideCancelButton();
        public HideCancelButton hideCancelButton;

        public delegate void FinishAndClose();
        public FinishAndClose finishAndClose;

        public frmTransferProgress(Cancel cancel)
        {
            try
            {
                this.cancel = cancel;
                this.overAllProgress = (String msg, int currentValue, int maxValue) =>
                {
                    UI(() =>
                    {
                        pbOverAll.Minimum       = 0;
                        pbOverAll.Maximum       = maxValue;
                        pbOverAll.Value         = currentValue;
                        lblOverAllMsg.Text      = msg;
                    });
                };
                this.setMessage             = (String msg)  => UI(() => lblMessage.Text     = msg);
                this.setCurrentFileName     = (String name) => UI(() => lblCurrentFile.Text = name);
                this.setCurrentFileProgress = (int value)   => UI(() => pbCurrentFile.Value = value);
                this.finishAndClose         = () => UI(()=> this.Close());
                this.hideCancelButton       = () =>
                {
                    UI(()=> btCancel.Visible = false);
                };
            } catch { }
            InitializeComponent();
        }

        private void frmTransferProgress_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            cancel();
        }
    }
}
