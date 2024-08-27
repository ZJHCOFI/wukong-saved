using System;
using System.IO;
using System.Windows.Forms;
using static WuKong_Saved_Backup_Recover.Main;

namespace WuKong_Saved_Backup_Recover
{
    public partial class Saved_Recover : Form
    {
        public Saved_Recover()
        {
            InitializeComponent();
        }

        //事件：窗体加载
        private void Saved_Recover_Load(object sender, EventArgs e)
        {
            string str_SBRSavedPath = Path.Combine(GlobalValue.str_GlobalSavedPath, "SBR_SaveGamesBackup");
            if (Directory.Exists(str_SBRSavedPath)) //如果工具存档文件夹正确
            {
                string[] str_SBRSaved = Directory.GetDirectories(str_SBRSavedPath);
                for (int i = 0; i < str_SBRSaved.Length; i++)
                {
                    listBox_SavedRecover.Items.Add(str_SBRSaved[i].Replace(str_SBRSavedPath + "\\", ""));
                }
            }
            else
            {
                MessageBox.Show("备份存档为空，请先备份存档！\nSaved backup is empty,please perform saved backup first!", "错误 ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        //方法：复制替换文件
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
                MessageBox.Show("游戏存档还原成功！\nGame save recover successful!", "提示 Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "错误 ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        //事件：选中了存档
        private void listBox_SavedRecover_SelectedValueChanged(object sender, EventArgs e)
        {
            //检查是否选中存档
            if (listBox_SavedRecover.SelectedIndex != -1)
            {
                label_User.Text = "";
                string str_SBRSaved = Path.Combine(GlobalValue.str_GlobalSavedPath, "SBR_SaveGamesBackup" + "\\" + listBox_SavedRecover.SelectedItem.ToString());
                if (Directory.Exists(str_SBRSaved))
                {
                    string[] str_GameUsers = Directory.GetDirectories(str_SBRSaved);
                    for (int i = 0; i < str_GameUsers.Length; i++)
                    {
                        label_User.Text += str_GameUsers[i].Replace(str_SBRSaved + "\\", "") + "，";
                    }
                }
                else
                {
                    MessageBox.Show("错误码：9527，请将此错误码提供给作者", "错误 ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //事件：点击“还原”按钮
        private void button_ok_Click(object sender, EventArgs e)
        {
            //检查是否选中存档
            if (listBox_SavedRecover.SelectedIndex == -1)
            {
                MessageBox.Show("请选择一个存档！\nPlease choose an saved!", "错误 ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //提醒将游戏退出到标题页面
                DialogResult MsgBoxResult;
                MsgBoxResult = MessageBox.Show("请确认已经将游戏【退出到标题页面】，游戏当前存档将被替换成：\n[" + listBox_SavedRecover.SelectedItem.ToString() + "]\n是否继续？\n\nPlease confirm that the game has been Return to Title Screen \nand the current game save will be replaced:\n[" + listBox_SavedRecover.SelectedItem.ToString() + "]\nDo you want to continue?", "提示 Info", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (MsgBoxResult == DialogResult.Yes)
                {
                    for (int i = 0; i < GlobalValue.str_GlobalUserName.Length; i++)
                    {
                        string str_sourceFolder = Path.Combine(GlobalValue.str_GlobalSavedPath, "SBR_SaveGamesBackup" + "\\" + listBox_SavedRecover.SelectedItem.ToString() + "\\" + GlobalValue.str_GlobalUserName[i]);
                        string str_destFolder = Path.Combine(GlobalValue.str_GlobalSavedPath, "SaveGames" + "\\" + GlobalValue.str_GlobalUserName[i]);
                        if (Directory.Exists(str_sourceFolder)) //如果游戏当前存档文件夹正确
                        {
                            //删除游戏当前存档文件
                            DirectoryInfo DeleteFile = new DirectoryInfo(str_destFolder);
                            foreach (FileInfo file in DeleteFile.EnumerateFiles())
                            {
                                file.Delete();
                            }
                            foreach (DirectoryInfo subDirectory in DeleteFile.EnumerateDirectories())
                            {
                                subDirectory.Delete(true);
                            }
                            //还原存档
                            CopyFolder(str_sourceFolder, str_destFolder);
                        }
                        else
                        {
                            MessageBox.Show("此存档不涉及该用户： " + GlobalValue.str_GlobalUserName[i] + "\nThis archive does not involve this users: " + GlobalValue.str_GlobalUserName[i], "错误 ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    Close();
                }  
            } 
        }

        //事件：点击“重命名”按钮
        private void button_Rename_Click(object sender, EventArgs e)
        {
            //检查是否选中存档
            if (listBox_SavedRecover.SelectedIndex == -1)
            {
                MessageBox.Show("请选择一个存档！\nPlease choose an saved!", "错误 ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                GlobalValue.str_ChooseSavedPath = listBox_SavedRecover.SelectedItem.ToString();
                Saved_RecoverRename saved_RecoverRename = new Saved_RecoverRename();
                saved_RecoverRename.ShowDialog();
                string str_SBRSavedPath = Path.Combine(GlobalValue.str_GlobalSavedPath, "SBR_SaveGamesBackup");
                //更新listbox中的内容
                listBox_SavedRecover.Items.Clear();
                if (Directory.Exists(str_SBRSavedPath)) //如果工具存档文件夹正确
                {
                    string[] str_SBRSaved = Directory.GetDirectories(str_SBRSavedPath);
                    for (int i = 0; i < str_SBRSaved.Length; i++)
                    {
                        listBox_SavedRecover.Items.Add(str_SBRSaved[i].Replace(str_SBRSavedPath + "\\", ""));
                    }
                }
            }
        }

        //事件：点击“删除”按钮
        private void button_del_Click(object sender, EventArgs e)
        {
            //检查是否选中存档
            if (listBox_SavedRecover.SelectedIndex == -1)
            {
                MessageBox.Show("请选择一个存档！\nPlease choose an saved!", "错误 ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string str_SBRSavedPath = Path.Combine(GlobalValue.str_GlobalSavedPath, "SBR_SaveGamesBackup");
                string str_DelSBRSaved = str_SBRSavedPath + "\\" + listBox_SavedRecover.SelectedItem.ToString();
                //提醒删除工具备份的存档
                DialogResult MsgBoxResult;
                MsgBoxResult = MessageBox.Show("是否删除存档：" + listBox_SavedRecover.SelectedItem.ToString() + " ？\nPlease confirm whether to delete the saved: " + listBox_SavedRecover.SelectedItem.ToString() + " ?", "提示 Info", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (MsgBoxResult == DialogResult.Yes)
                {
                    if (Directory.Exists(str_DelSBRSaved)) //如果备份存档文件夹正确
                    {
                        //删除所选中的工具备份的存档
                        DirectoryInfo DeleteFile = new DirectoryInfo(str_DelSBRSaved);
                        DeleteFile.Delete(true);
                        if (!Directory.Exists(str_DelSBRSaved))
                        {
                            //更新listbox中的内容
                            listBox_SavedRecover.Items.Clear();
                            if (Directory.Exists(str_SBRSavedPath)) //如果工具存档文件夹正确
                            {
                                string[] str_SBRSaved = Directory.GetDirectories(str_SBRSavedPath);
                                for (int i = 0; i < str_SBRSaved.Length; i++)
                                {
                                    listBox_SavedRecover.Items.Add(str_SBRSaved[i].Replace(str_SBRSavedPath + "\\", ""));
                                }
                            }
                            MessageBox.Show("所选中的存档删除成功！\nThe selected saved has been successfully deleted!", "提示 Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("存档删除失败！\nSaved deletion failed!", "错误 ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("此存档不存在！\nThis saved does not exist!", "错误 ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
