using System;
using System.IO;
using System.Windows.Forms;
using static WuKong_Saved_Backup_Recover.Main;

namespace WuKong_Saved_Backup_Recover
{
    public partial class Saved_Backup : Form
    {
        public Saved_Backup()
        {
            InitializeComponent();
        }

        //事件：窗体加载
        private void Saved_Backup_Load(object sender, EventArgs e)
        {
            label_SavedName.Text = textBox_keyword.Text.ToString() + "_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            for (int i = 0; i < GlobalValue.str_GlobalUserName.Length; i++)
            {
                label_User.Text += GlobalValue.str_GlobalUserName[i] + "，";
            }
        }

        //方法：复制文件
        public int CopyFolder(string sourceFolder, string destFolder)
        {
            try
            {
                //如果目标路径不存在,则创建目标路径
                if (!Directory.Exists(destFolder))
                {
                    Directory.CreateDirectory(destFolder);
                }
                //得到原文件根目录下的所有文件
                string[] files = Directory.GetFiles(sourceFolder);
                foreach (string file in files)
                {
                    string name = Path.GetFileName(file);
                    string dest = Path.Combine(destFolder, name);
                    File.Copy(file, dest);//复制文件
                }
                //得到原文件根目录下的所有文件夹
                string[] folders = Directory.GetDirectories(sourceFolder);
                foreach (string folder in folders)
                {
                    string name = Path.GetFileName(folder);
                    string dest = Path.Combine(destFolder, name);
                    CopyFolder(folder, dest);//构建目标路径,递归复制文件
                }
                MessageBox.Show("游戏存档备份成功！\nGame save backup successful!", "提示 Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "错误 ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

        }

        //事件：点击“确认”按钮
        private void button_ok_Click(object sender, EventArgs e)
        {
            label_SavedName.Text = textBox_keyword.Text.ToString() + "_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            string str_GameSavedPath = Path.Combine(GlobalValue.str_GlobalSavedPath, "SaveGames");
            string str_SBRSavedPath = Path.Combine(GlobalValue.str_GlobalSavedPath, "SBR_SaveGamesBackup");
            for (int i = 0; i < GlobalValue.str_GlobalUserName.Length; i++)
            {
                label_info_User.Text += GlobalValue.str_GlobalUserName[i] + ",";
                string str_sourceFolder = str_GameSavedPath + "\\" + GlobalValue.str_GlobalUserName[i];
                string str_destFolder = str_SBRSavedPath + "\\" + label_SavedName.Text.ToString() + "\\" + GlobalValue.str_GlobalUserName[i];
                CopyFolder(str_sourceFolder, str_destFolder);
            }
        }

        //事件：textBox文字变化
        private void textBox_keyword_TextChanged(object sender, EventArgs e)
        {
            label_SavedName.Text = textBox_keyword.Text.ToString() + "_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
        }
    }
}
