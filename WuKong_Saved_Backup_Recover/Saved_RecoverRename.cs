using Microsoft.VisualBasic.FileIO;
using System;
using System.IO;
using System.Windows.Forms;
using static WuKong_Saved_Backup_Recover.Main;

namespace WuKong_Saved_Backup_Recover
{
    public partial class Saved_RecoverRename : Form
    {
        public Saved_RecoverRename()
        {
            InitializeComponent();
        }

        //存档时间声明
        string str_SavedNameDateTime;

        //方法：去除非法字符
        private string ReplaceIllegalChar(string fileName)
        {
            string str = fileName;
            str = str.Replace("\\", string.Empty);
            str = str.Replace("/", string.Empty);
            str = str.Replace(":", string.Empty);
            str = str.Replace("*", string.Empty);
            str = str.Replace("?", string.Empty);
            str = str.Replace("\"", string.Empty);
            str = str.Replace("<", string.Empty);
            str = str.Replace(">", string.Empty);
            str = str.Replace("|", string.Empty);
            str = str.Replace(" ", string.Empty);
            return str;
        }

        //事件：窗体加载
        private void Saved_RecoverRename_Load(object sender, EventArgs e)
        {
            if(GlobalValue.str_ChooseSavedPath.Length >= 20)
            {
                str_SavedNameDateTime = GlobalValue.str_ChooseSavedPath.Substring(GlobalValue.str_ChooseSavedPath.Length - 19);
                label_SavedName.Text = textBox_keyword.Text.ToString() + "_" + str_SavedNameDateTime;
                textBox_keyword.Text = GlobalValue.str_ChooseSavedPath.Remove(GlobalValue.str_ChooseSavedPath.Length - 20);
            }
            else
            {
                MessageBox.Show("该存档命名有误！\nThe game save is named incorrectly!", "错误 ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        //事件：点击“确认”按钮
        private void button_ok_Click(object sender, EventArgs e)
        {
            string str_LegalName = ReplaceIllegalChar(textBox_keyword.Text.ToString());
            label_SavedName.Text = str_LegalName + "_" + str_SavedNameDateTime;
            string str_SBRSavedName_Before = Path.Combine(GlobalValue.str_GlobalSavedPath, "SBR_SaveGamesBackup" + "\\" + GlobalValue.str_ChooseSavedPath);
            string str_SBRSavedName_Alter = Path.Combine(GlobalValue.str_GlobalSavedPath, "SBR_SaveGamesBackup" + "\\" + label_SavedName.Text.ToString());
            if(!Directory.Exists(str_SBRSavedName_Before)) //如果原存档文件夹不存在
            {
                MessageBox.Show("原存档不存在！\nThe original saved does not exist!", "错误 ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Directory.Exists(str_SBRSavedName_Alter)) //如果新的存档文件夹名字被占用
            {
                MessageBox.Show("存档名已被占用！\nSaved name already exist!", "错误 ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FileSystem.RenameDirectory(str_SBRSavedName_Before, label_SavedName.Text.ToString());
                if (!Directory.Exists(str_SBRSavedName_Before) && Directory.Exists(str_SBRSavedName_Alter))
                {
                    MessageBox.Show("存档重命名成功！\nSaved renaming successful!", "提示 Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("存档重命名失败！\nSaved renaming failed!", "错误 ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }    
            }
        }

        //事件：textBox文字变化
        private void textBox_keyword_TextChanged(object sender, EventArgs e)
        {
            string str_LegalName = ReplaceIllegalChar(textBox_keyword.Text.ToString());
            label_SavedName.Text = str_LegalName + "_" + str_SavedNameDateTime;
        }
    }
}
