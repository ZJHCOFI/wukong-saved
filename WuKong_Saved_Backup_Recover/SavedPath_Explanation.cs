using System.Diagnostics;
using System.Windows.Forms;

namespace WuKong_Saved_Backup_Recover
{
    public partial class SavedPath_Explanation : Form
    {
        public SavedPath_Explanation()
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
