using System;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using Chat.Properties;

namespace Chat
{
    public partial class frmLoadingScreen : Form
    {
        public frmLoadingScreen()
        {
            base.Load += LoadingScreen_Load;
            InitializeComponent();
            picLoading.Image = Resources.load_40;
        }

        private void LoadingScreen_Load(object sender, EventArgs e)
        {
            SetTemplateColor();
        }

        private void SetTemplateColor()
        {
            SuspendLayout();
            try
            {
                BackColor = Template.LEFT_BG_COLOR;
                picLoading.BackColor = Template.LEFT_BG_COLOR;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                WriteLog.Save(ex2);
                ProjectData.ClearProjectError();
            }
            ResumeLayout();
        }
    }
}
