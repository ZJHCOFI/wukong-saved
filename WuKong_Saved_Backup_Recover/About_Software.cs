using System.Diagnostics;
using System.Windows.Forms;

namespace WuKong_Saved_Backup_Recover
{
    public partial class About_Software : Form
    {
        public About_Software()
        {
            InitializeComponent();
        }

        //点击文本框里的链接
        private void richTextBox_about_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }
    }
}
