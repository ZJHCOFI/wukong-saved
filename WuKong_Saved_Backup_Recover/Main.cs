using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using WuKong_Saved_Backup_Recover.Properties;
using Gma.System.MouseKeyHook;
using System.IO;
using System.Collections.Generic;
using System.Xml.Linq;

namespace WuKong_Saved_Backup_Recover
{
    public partial class Main : Form
    {
        // 编写时间：2024.08.25
        // 更新时间：2024.08.25 10:00
        // Edit by ZJHCOFI
        // 博客Blog：https://zjhcofi.com
        // Github：https://github.com/zjhcofi
        // 功能：《黑神话：悟空》存档快速备份及还原工具
        // 外置插件：MouseKeyHook 5.6.0（下载方法：“Visual Studio”-“项目”-“管理NuGet程序包”）
        // 开源协议：BSD 3-Clause “New” or “Revised” License (https://choosealicense.com/licenses/bsd-3-clause/)
        // 后续更新或漏洞修补通告页面：https://github.com/zjhcofi
        // =====更新日志=====
        // 2024.08.25 10:00
        // 第一个版本发布
        // ==================

        public Main()
        {
            InitializeComponent();
        }

        //全局变量
        public class GlobalValue
        {
            public static string str_GlobalSavedPath;
            public static string[] str_GlobalUserName;
        }

        //窗体移动相关的变量声明及赋值
        private bool bool_Moving = false;
        private Point oldMousePosition;

        //判断软件配置文件是否存在
        private bool bool_ConfigStatus = false;

        //键盘监听变量声明
        private IKeyboardMouseEvents m_GlobalHook;

        //事件：窗体加载
        private void Main_Load(object sender, EventArgs e)
        {
            //事件委托
            pictureBox_Btn_Quit.MouseMove += new MouseEventHandler(pictrueBox_MouseMove);
            pictureBox_Btn_Minimized.MouseMove += new MouseEventHandler(pictrueBox_MouseMove);
            pictureBox_WuKong_Monkey.MouseMove += new MouseEventHandler(pictrueBox_MouseMove);
            pictureBox_WuKong_Text.MouseMove += new MouseEventHandler(pictrueBox_MouseMove);
            pictureBox_SBR_Logo.MouseMove += new MouseEventHandler(pictrueBox_MouseMove);
            label_SBR_creditor.MouseMove += new MouseEventHandler(label_MouseMove);
            label_SBR_version.MouseMove += new MouseEventHandler(label_MouseMove);
            //图片加载相关
            pictureBox_WuKong_bg.Controls.Add(label_SBR_title_GameName);
            pictureBox_WuKong_bg.Controls.Add(label_SBR_title_SBRName);
            pictureBox_WuKong_bg.Controls.Add(label_SplitLine_1);
            pictureBox_WuKong_bg.Controls.Add(label_SBR_list_KuaiJieJian);
            pictureBox_WuKong_bg.Controls.Add(label_SBR_list_GongNengLieBiao);
            pictureBox_WuKong_bg.Controls.Add(label_SBR_list_F11);
            pictureBox_WuKong_bg.Controls.Add(label_SBR_list_F11_Info);
            pictureBox_WuKong_bg.Controls.Add(label_SBR_list_F12);
            pictureBox_WuKong_bg.Controls.Add(label_SBR_list_F12_Info);
            pictureBox_WuKong_bg.Controls.Add(pictureBox_WuKong_Monkey);
            pictureBox_WuKong_bg.Controls.Add(pictureBox_WuKong_HeiShenHua);
            pictureBox_WuKong_bg.Controls.Add(pictureBox_WuKong_Text);
            pictureBox_WuKong_bg.Controls.Add(pictureBox_SBR_Logo);
            pictureBox_WuKong_bg.Controls.Add(button_SBR_switch_F11);
            pictureBox_WuKong_bg.Controls.Add(button_SBR_switch_F12);
            pictureBox_Btn_Quit.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_Btn_Minimized.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_WuKong_bg.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_WuKong_Monkey.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_WuKong_Text.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_WuKong_HeiShenHua.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_SBR_Logo.SizeMode = PictureBoxSizeMode.StretchImage;
            //鼠标停留初始提示
            toolTip_info.SetToolTip(pictureBox_Btn_Quit, "退出");
            toolTip_info.SetToolTip(pictureBox_Btn_Minimized, "最小化");
            //键盘HOOK事件创建
            m_GlobalHook = Hook.GlobalEvents();
            m_GlobalHook.KeyDown += M_GlobalHook_KeyDown;
            //检查配置是否正常
            Saved_Check();
        }

        //事件：监测键盘按下
        private void M_GlobalHook_KeyDown(object sender, KeyEventArgs e)
        {
            //Ctrl+F* 热键事件
            if (e.Modifiers.CompareTo(Keys.Control) == 0 && e.KeyCode == Keys.F11)
            {
                F11_PressDownOrClick();
            }
            else if (e.Modifiers.CompareTo(Keys.Control) == 0 && e.KeyCode == Keys.F12)
            {
                F12_PressDownOrClick();
            }
        }

        //方法：检查软件配置文件、游戏路径等
        private void Saved_Check()
        {
            checkedListBox_SBR_Default_SaveUser.Items.Clear();
            string str_ConfigFile = Path.Combine(Environment.CurrentDirectory, "SBR.xml");
            if (!File.Exists(str_ConfigFile)) //如果工具配置文件SBR.xml不存在
            {
                label_SBR_Default_info.Visible = true;
                button_SBR_switch_F11.Enabled = false;
                button_SBR_switch_F12.Enabled = false;
                if(radioButton_cn.Checked == true || radioButton_tc.Checked == true)
                {
                    button_SBR_switch_F11.Text = "不可用";
                    button_SBR_switch_F12.Text = "不可用";
                }
                else
                {
                    button_SBR_switch_F11.Text = "N/A";
                    button_SBR_switch_F12.Text = "N/A";
                }
            }
            else //如果工具配置文件SBR.xml存在
            {
                //读取XML文件内容
                XDocument xml_Document = XDocument.Load(str_ConfigFile);
                //获取XML的游戏存档路径
                XElement xml_Root = xml_Document.Root;
                XElement xml_DefaultPath = xml_Root.Element("Path");
                //检测游戏存档路径是否正确
                string str_SavedPath = Path.Combine(xml_DefaultPath.Value, "SaveGames");
                if (Directory.Exists(str_SavedPath)) //如果游戏文件夹正确
                {
                    bool_ConfigStatus = true;
                    label_SBR_Default_info.Visible = false;
                    button_SBR_switch_F11.Enabled = true;
                    button_SBR_switch_F12.Enabled = true;
                    if (radioButton_cn.Checked == true)
                    {
                        button_SBR_switch_F11.Text = "应用";
                        button_SBR_switch_F12.Text = "应用";
                    }
                    else if(radioButton_tc.Checked == true)
                    {
                        button_SBR_switch_F11.Text = "應用";
                        button_SBR_switch_F12.Text = "應用";
                    }
                    else
                    {
                        button_SBR_switch_F11.Text = "APPLY";
                        button_SBR_switch_F12.Text = "APPLY";
                    }
                    textBox_SBR_Default_SavePath.Text = xml_DefaultPath.Value;
                    string[] str_GameUsers = Directory.GetDirectories(str_SavedPath);
                    for (int i = 0; i < str_GameUsers.Length; i++)
                    {
                        checkedListBox_SBR_Default_SaveUser.Items.Add(str_GameUsers[i].Replace(xml_DefaultPath.Value + "\\SaveGames\\", ""));
                    }
                    //获取XML的已勾选用户
                    XElement xml_DefaultUser = xml_Root.Element("Users");
                    IEnumerable<XElement> xml_DefaultUserName = xml_DefaultUser.Elements();
                    foreach (XElement item in xml_DefaultUserName)
                    {
                        for (int i = 0; i <= (checkedListBox_SBR_Default_SaveUser.Items.Count - 1); i++)
                        {
                            if (checkedListBox_SBR_Default_SaveUser.Items[i].ToString() == item.Value)
                            {
                                checkedListBox_SBR_Default_SaveUser.SetItemChecked(i, true);
                            }
                        }
                    }
                }
                else //如果游戏文件夹不正确
                {
                    bool_ConfigStatus = false;
                    label_SBR_Default_info.Visible = true;
                    button_SBR_switch_F11.Enabled = false;
                    button_SBR_switch_F12.Enabled = false;
                    if (radioButton_cn.Checked == true || radioButton_tc.Checked == true)
                    {
                        button_SBR_switch_F11.Text = "不可用";
                        button_SBR_switch_F12.Text = "不可用";
                    }
                    else
                    {
                        button_SBR_switch_F11.Text = "N/A";
                        button_SBR_switch_F12.Text = "N/A";
                    }
                    textBox_SBR_Default_SavePath.Clear();
                    textBox_SBR_Default_SavePath.Focus();
                    MessageBox.Show("游戏存档路径有误，请重新在工具左下角填写并点击\"应用\"\nThe game save path is incorrect,please fill it out again \nin the bottom left corner of the tool and click \"APPLY\"", "错误 ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //方法：创建XML工具配置文件
        private void XML_Creat(string str_ConfigFile)
        {
            XDocument xml_Document = new XDocument();
            XElement xml_Root = new XElement("SBR_Default");
            xml_Root.SetElementValue("Path", textBox_SBR_Default_SavePath.Text.ToString());
            XElement xml_Users = new XElement("Users");
            for (int i = 0; i <= (checkedListBox_SBR_Default_SaveUser.Items.Count - 1); i++)
            {
                if (checkedListBox_SBR_Default_SaveUser.GetItemChecked(i))
                {
                    xml_Users.SetElementValue("name" + i, checkedListBox_SBR_Default_SaveUser.Items[i].ToString());
                }
            }
            xml_Root.Add(xml_Users);
            xml_Document.Add(xml_Root);
            xml_Document.Save(str_ConfigFile);
        }

        //事件：点击“选择路径”按钮
        private void button_SBR_Default_SavePath_Click(object sender, EventArgs e)
        {
            //打开文件夹选择框
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择游戏存档所在文件夹\nPlease choose the folder where the game save is located";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(dialog.SelectedPath))
                {
                    MessageBox.Show("文件夹路径不能为空！\nThe game path cannot be empty!", "错误 ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else 
                {
                    textBox_SBR_Default_SavePath.Text = dialog.SelectedPath;
                }
            }
            //判断文件夹是否正确
            checkedListBox_SBR_Default_SaveUser.Items.Clear();
            string str_SavedPath = Path.Combine(textBox_SBR_Default_SavePath.Text.ToString(), "SaveGames");
            if (Directory.Exists(str_SavedPath))  //如果游戏文件夹正确
            {
                bool_ConfigStatus = true;
                string[] str_GameUsers = Directory.GetDirectories(str_SavedPath);
                for (int i = 0; i < str_GameUsers.Length; i++)
                {
                    checkedListBox_SBR_Default_SaveUser.Items.Add(str_GameUsers[i].Replace(str_SavedPath + "\\", ""));
                }
                //重新创建XML工具配置文件
                string str_ConfigFile = Path.Combine(Environment.CurrentDirectory, "SBR.xml");
                if (File.Exists(str_ConfigFile)) //如果工具配置文件SBR.xml存在
                {
                    //删除原来的工具配置文件SBR.xml
                    File.Delete(str_ConfigFile);
                    //创建工具配置文件SBR.xml
                    XML_Creat(str_ConfigFile);
                    bool_ConfigStatus = true;
                    label_SBR_Default_info.Visible = false;
                    button_SBR_switch_F11.Enabled = true;
                    button_SBR_switch_F12.Enabled = true;
                    if (radioButton_cn.Checked == true)
                    {
                        button_SBR_switch_F11.Text = "应用";
                        button_SBR_switch_F12.Text = "应用";
                    }
                    else if (radioButton_tc.Checked == true)
                    {
                        button_SBR_switch_F11.Text = "應用";
                        button_SBR_switch_F12.Text = "應用";
                    }
                    else
                    {
                        button_SBR_switch_F11.Text = "APPLY";
                        button_SBR_switch_F12.Text = "APPLY";
                    }
                    MessageBox.Show("游戏存档识别成功！\nGame save recognition successful!", "提示 Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else //如果工具配置文件SBR.xml不存在
                {
                    //创建工具配置文件SBR.xml
                    XML_Creat(str_ConfigFile);
                    bool_ConfigStatus = true;
                    label_SBR_Default_info.Visible = false;
                    button_SBR_switch_F11.Enabled = true;
                    button_SBR_switch_F12.Enabled = true;
                    if (radioButton_cn.Checked == true)
                    {
                        button_SBR_switch_F11.Text = "应用";
                        button_SBR_switch_F12.Text = "应用";
                    }
                    else if (radioButton_tc.Checked == true)
                    {
                        button_SBR_switch_F11.Text = "應用";
                        button_SBR_switch_F12.Text = "應用";
                    }
                    else
                    {
                        button_SBR_switch_F11.Text = "APPLY";
                        button_SBR_switch_F12.Text = "APPLY";
                    }
                    MessageBox.Show("游戏存档识别成功！\nGame save recognition successful!", "提示 Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else //如果游戏文件夹不正确
            {
                bool_ConfigStatus = false;
                label_SBR_Default_info.Visible = true;
                button_SBR_switch_F11.Enabled = false;
                button_SBR_switch_F12.Enabled = false;
                if (radioButton_cn.Checked == true || radioButton_tc.Checked == true)
                {
                    button_SBR_switch_F11.Text = "不可用";
                    button_SBR_switch_F12.Text = "不可用";
                }
                else
                {
                    button_SBR_switch_F11.Text = "N/A";
                    button_SBR_switch_F12.Text = "N/A";
                }
                textBox_SBR_Default_SavePath.Clear();
                textBox_SBR_Default_SavePath.Focus();
                MessageBox.Show("游戏存档路径有误，请重新\"选择路径\"\nThe game save path is incorrect,please \"Choose Path\" again", "错误 ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //事件：当勾选的用户发生变化
        private void checkedListBox_SBR_Default_SaveUser_SelectedValueChanged(object sender, EventArgs e)
        {
            string str_SavedPath = Path.Combine(textBox_SBR_Default_SavePath.Text.ToString(), "SaveGames");
            if (Directory.Exists(str_SavedPath))  //如果游戏文件夹正确
            {
                //重新创建XML工具配置文件
                string str_ConfigFile = Path.Combine(Environment.CurrentDirectory, "SBR.xml");
                if (File.Exists(str_ConfigFile)) //如果工具配置文件SBR.xml存在
                {
                    //删除原来的工具配置文件SBR.xml
                    File.Delete(str_ConfigFile);
                    //创建工具配置文件SBR.xml
                    XML_Creat(str_ConfigFile);
                }
                else //如果工具配置文件SBR.xml不存在
                {
                    //创建工具配置文件SBR.xml
                    XML_Creat(str_ConfigFile);
                }
            }
            else //如果游戏文件夹不正确
            {
                bool_ConfigStatus = false;
                label_SBR_Default_info.Visible = true;
                button_SBR_switch_F11.Enabled = false;
                button_SBR_switch_F12.Enabled = false;
                if (radioButton_cn.Checked == true || radioButton_tc.Checked == true)
                {
                    button_SBR_switch_F11.Text = "不可用";
                    button_SBR_switch_F12.Text = "不可用";
                }
                else
                {
                    button_SBR_switch_F11.Text = "N/A";
                    button_SBR_switch_F12.Text = "N/A";
                }
                textBox_SBR_Default_SavePath.Clear();
                textBox_SBR_Default_SavePath.Focus();
                MessageBox.Show("游戏存档路径有误，请重新\"选择路径\"\nThe game save path is incorrect,please \"Choose Path\" again", "错误 ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //事件：Ctrl+F11 快捷键按下 及 Ctrl+F11按钮点击
        private void F11_PressDownOrClick()
        {
            Saved_Check();
            if (bool_ConfigStatus == true)
            {
                //判断是否有选中的用户
                int int_CheckedUser = 0;
                List<string> list_UserName = new List<string>();
                for (int i = 0; i <= (checkedListBox_SBR_Default_SaveUser.Items.Count - 1); i++)
                {
                    if (checkedListBox_SBR_Default_SaveUser.GetItemChecked(i))
                    {
                        int_CheckedUser += 1;
                        list_UserName.Add(checkedListBox_SBR_Default_SaveUser.Items[i].ToString());
                    }
                }
                GlobalValue.str_GlobalUserName = list_UserName.ToArray();
                if (int_CheckedUser == 0) //如果没选中
                {
                    checkedListBox_SBR_Default_SaveUser.Focus();
                    MessageBox.Show("请至少选择一个用户！\nPlease select at least one user!", "错误 ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else //如果有选中
                {
                    GlobalValue.str_GlobalSavedPath = textBox_SBR_Default_SavePath.Text.ToString();
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(Resources.open);
                    player.Play();
                    Saved_Backup saved_Backup = new Saved_Backup();
                    saved_Backup.ShowDialog();
                }
            }
            else
            {
                checkedListBox_SBR_Default_SaveUser.Items.Clear();
                textBox_SBR_Default_SavePath.Clear();
                textBox_SBR_Default_SavePath.Focus();
                MessageBox.Show("游戏存档识别失败，请在工具左下角重新\"选择路径\"\nGame save recognition fail,please \"Choose Path\" again \nin the bottom left corner of the tool", "错误 ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //事件：Ctrl+F12 快捷键按下 及 Ctrl+F12按钮点击
        private void F12_PressDownOrClick()
        {
            Saved_Check();
            if (bool_ConfigStatus == true)
            {
                //判断是否有选中的用户
                int int_CheckedUser = 0;
                List<string> list_UserName = new List<string>();
                for (int i = 0; i <= (checkedListBox_SBR_Default_SaveUser.Items.Count - 1); i++)
                {
                    if (checkedListBox_SBR_Default_SaveUser.GetItemChecked(i))
                    {
                        int_CheckedUser += 1;
                        list_UserName.Add(checkedListBox_SBR_Default_SaveUser.Items[i].ToString());
                    }
                }
                GlobalValue.str_GlobalUserName = list_UserName.ToArray();
                if (int_CheckedUser == 0) //如果没选中
                {
                    checkedListBox_SBR_Default_SaveUser.Focus();
                    MessageBox.Show("请至少选择一个用户！\nPlease select at least one user!", "错误 ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else //如果有选中
                {
                    GlobalValue.str_GlobalSavedPath = textBox_SBR_Default_SavePath.Text.ToString();
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(Resources.open);
                    player.Play();
                    Saved_Recover saved_Recover = new Saved_Recover();
                    saved_Recover.ShowDialog();
                }
            }
            else
            {
                checkedListBox_SBR_Default_SaveUser.Items.Clear();
                textBox_SBR_Default_SavePath.Clear();
                textBox_SBR_Default_SavePath.Focus();
                MessageBox.Show("游戏存档识别失败，请在工具左下角重新\"选择路径\"\nGame save recognition fail,please \"Choose Path\" again \nin the bottom left corner of the tool", "错误 ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //事件： Ctrl+F11按钮点击
        private void button_SBR_switch_F11_Click(object sender, EventArgs e)
        {
            F11_PressDownOrClick();
        }

        //事件： Ctrl+F12按钮点击
        private void button_SBR_switch_F12_Click(object sender, EventArgs e)
        {
            F12_PressDownOrClick();
        }

        //事件：PictureBox点击事件
        private void pictrueBox_Click(object sender, EventArgs e)
        {
            switch (((PictureBox)sender).Name.ToString())
            {
                case "pictureBox_Btn_Quit":
                    Close();
                    break;
                case "pictureBox_Btn_Minimized":
                    if (WindowState != FormWindowState.Minimized)
                    {
                        WindowState = FormWindowState.Minimized;
                    }
                    break;
                case "pictureBox_WuKong_Monkey":
                    F11_PressDownOrClick();
                    break;
                case "pictureBox_SBR_Logo":
                    About_Software about_Software = new About_Software();
                    about_Software.ShowDialog();
                    break;
                case "pictureBox_WuKong_Text":
                    Process.Start("https://heishenhua.com");
                    break;
                default:
                    break;
            }
        }

        //事件：PictureBox鼠标经过事件
        private void pictrueBox_MouseMove(object sender, EventArgs e)
        {
            switch (((PictureBox)sender).Name.ToString())
            {
                case "pictureBox_Btn_Quit":
                    pictureBox_Btn_Quit.Image = Resources.quit_btn_light;
                    pictureBox_Btn_Quit.Cursor = Cursors.Hand;
                    break;
                case "pictureBox_Btn_Minimized":
                    pictureBox_Btn_Minimized.Image = Resources.minimized_btn_light;
                    pictureBox_Btn_Minimized.Cursor = Cursors.Hand;
                    break;
                case "pictureBox_WuKong_Monkey":
                    pictureBox_WuKong_Monkey.Image = Resources.wukong_monkey_light;
                    label_info_SavedBackup.Visible = true;
                    pictureBox_WuKong_Monkey.Cursor = Cursors.Hand;
                    break;
                case "pictureBox_SBR_Logo":
                    pictureBox_SBR_Logo.Image = Resources.logo_2_light;
                    label_info_SBR.Visible = true;
                    pictureBox_SBR_Logo.Cursor = Cursors.Hand;
                    break;
                case "pictureBox_WuKong_Text":
                    if (radioButton_en.Checked == true)
                    {
                        pictureBox_WuKong_Text.Image = Resources.wukong_title_light_en;
                        label_info_WuKongWebsite.Visible = true;
                        pictureBox_WuKong_Text.Cursor = Cursors.Hand;
                    }
                    else
                    {
                        pictureBox_WuKong_Text.Image = Resources.wukong_title_light;
                        label_info_WuKongWebsite.Visible = true;
                        pictureBox_WuKong_Text.Cursor = Cursors.Hand;
                    }
                    break;
                default:
                    break;
            }
        }

        //事件：PictureBox鼠标离开事件
        private void pictrueBox_MouseLeave(object sender, EventArgs e)
        {
            switch (((PictureBox)sender).Name.ToString())
            {
                case "pictureBox_Btn_Quit":
                    pictureBox_Btn_Quit.Image = Resources.quit_btn;
                    pictureBox_Btn_Quit.Cursor = Cursors.Default;
                    break;
                case "pictureBox_Btn_Minimized":
                    pictureBox_Btn_Minimized.Image = Resources.minimized_btn;
                    pictureBox_Btn_Minimized.Cursor = Cursors.Default;
                    break;
                case "pictureBox_WuKong_Monkey":
                    pictureBox_WuKong_Monkey.Image = Resources.wukong_monkey;
                    label_info_SavedBackup.Visible = false;
                    pictureBox_WuKong_Monkey.Cursor = Cursors.Default;
                    break;
                case "pictureBox_SBR_Logo":
                    pictureBox_SBR_Logo.Image = Resources.logo_2;
                    label_info_SBR.Visible = false;
                    pictureBox_SBR_Logo.Cursor = Cursors.Default;
                    break;
                case "pictureBox_WuKong_Text":
                    if (radioButton_en.Checked == true)
                    {
                        pictureBox_WuKong_Text.Image = Resources.wukong_title_en;
                        label_info_WuKongWebsite.Visible = false;
                        pictureBox_WuKong_Text.Cursor = Cursors.Default;
                    }
                    else
                    {
                        pictureBox_WuKong_Text.Image = Resources.wukong_title;
                        label_info_WuKongWebsite.Visible = false;
                        pictureBox_WuKong_Text.Cursor = Cursors.Default;
                    }
                    break;
                default:
                    break;
            }
        }

        //事件：界面语言单选按钮选中事件
        private void radioBtn_CheckedChange(object sender, EventArgs e)
        {
            if (!((RadioButton)sender).Checked)
            {
                return;
            }
            switch (((RadioButton)sender).Text.ToString())
            {
                case "简体":
                    //控件变化
                    radioButton_cn.ForeColor = Color.FromArgb(255, 128, 0);
                    radioButton_tc.ForeColor = Color.White;
                    radioButton_en.ForeColor = Color.White;
                    button_SBR_switch_F11.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point);
                    button_SBR_switch_F12.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point);
                    button_SBR_Default_SavePath.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point);
                    label_SBR_Default_info.Font = new Font("微软雅黑", 11F, FontStyle.Bold, GraphicsUnit.Point);
                    label_SBR_Default_SavePath.Font = new Font("微软雅黑", 11F, FontStyle.Bold, GraphicsUnit.Point);
                    label_SBR_Default_SaveUser.Font = new Font("微软雅黑", 11F, FontStyle.Bold, GraphicsUnit.Point);
                    if(bool_ConfigStatus == false)
                    {
                        button_SBR_switch_F11.Text = "不可用";
                        button_SBR_switch_F12.Text = "不可用";
                    }
                    else
                    {
                        button_SBR_switch_F11.Text = "应用";
                        button_SBR_switch_F12.Text = "应用";
                    }
                    button_SBR_Default_SavePath.Text = "选择路径";
                    label_SBR_Default_info.Text = "          工具配置文件缺失或错误，请选择存档路径";
                    label_SBR_Default_SavePath.Text = "游戏存档路径：";
                    label_SBR_Default_SaveUser.Text = "需要备份或还原存档的用户（请勾选）：";
                    linkLabel_SBR_Default_SavePath.Text = "点击此处查看游戏路径说明";
                    toolTip_info.SetToolTip(pictureBox_Btn_Quit, "退出");
                    toolTip_info.SetToolTip(pictureBox_Btn_Minimized, "最小化");
                    label_info_SavedBackup.Font = new Font("微软雅黑", 36F, FontStyle.Bold, GraphicsUnit.Point);
                    label_info_SavedBackup.Text = "备份存档";
                    label_info_WuKongWebsite.Font = new Font("微软雅黑", 36F, FontStyle.Bold, GraphicsUnit.Point);
                    label_info_WuKongWebsite.Text = "游戏官网";
                    label_info_SBR.Font = new Font("微软雅黑", 36F, FontStyle.Bold, GraphicsUnit.Point);
                    label_info_SBR.Text = "关于工具";
                    label_SBR_title_GameName.Text = "《黑神话：悟空》";
                    label_SBR_title_SBRName.Text = "存档快速备份及还原工具";
                    pictureBox_WuKong_HeiShenHua.Visible = true;
                    pictureBox_WuKong_Text.Image = Resources.wukong_title;
                    //工具功能文字变化
                    label_SBR_list_KuaiJieJian.Text = "快捷键";
                    label_SBR_list_GongNengLieBiao.Text = "功能列表";
                    label_SBR_list_F11_Info.Text = "备份存档";
                    label_SBR_list_F12_Info.Text = "还原存档";
                    //工具信息文字变化
                    label_SBR_creditor.Text = "作者：ZJHCOFI | zjhcofi.com";
                    label_SBR_version.Text = "工具版本：Build.2024.08.25";
                    break;
                case "繁體":
                    //控件变化
                    radioButton_cn.ForeColor = Color.White;
                    radioButton_tc.ForeColor = Color.FromArgb(255, 128, 0);
                    radioButton_en.ForeColor = Color.White;
                    button_SBR_switch_F11.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point);
                    button_SBR_switch_F12.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point);
                    button_SBR_Default_SavePath.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point);
                    label_SBR_Default_info.Font = new Font("微软雅黑", 11F, FontStyle.Bold, GraphicsUnit.Point);
                    label_SBR_Default_SavePath.Font = new Font("微软雅黑", 11F, FontStyle.Bold, GraphicsUnit.Point);
                    label_SBR_Default_SaveUser.Font = new Font("微软雅黑", 11F, FontStyle.Bold, GraphicsUnit.Point);
                    if (bool_ConfigStatus == false)
                    {
                        button_SBR_switch_F11.Text = "不可用";
                        button_SBR_switch_F12.Text = "不可用";
                    }
                    else
                    {
                        button_SBR_switch_F11.Text = "應用";
                        button_SBR_switch_F12.Text = "應用";
                    }
                    button_SBR_Default_SavePath.Text = "選擇路徑";
                    label_SBR_Default_info.Text = "          工具配置文件缺失或錯誤，請選擇存檔路徑";
                    label_SBR_Default_SavePath.Text = "遊戲存檔路徑：";
                    label_SBR_Default_SaveUser.Text = "需要備份或還原存檔的用戶（請勾選）：";
                    linkLabel_SBR_Default_SavePath.Text = "點擊此處查看遊戲路徑說明";
                    toolTip_info.SetToolTip(pictureBox_Btn_Quit, "關閉");
                    toolTip_info.SetToolTip(pictureBox_Btn_Minimized, "最小化");
                    label_info_SavedBackup.Font = new Font("微软雅黑", 36F, FontStyle.Bold, GraphicsUnit.Point);
                    label_info_SavedBackup.Text = "備份存檔";
                    label_info_WuKongWebsite.Font = new Font("微软雅黑", 36F, FontStyle.Bold, GraphicsUnit.Point);
                    label_info_WuKongWebsite.Text = "游戲官網";
                    label_info_SBR.Font = new Font("微软雅黑", 36F, FontStyle.Bold, GraphicsUnit.Point);
                    label_info_SBR.Text = "關於軟體";
                    label_SBR_title_GameName.Text = "《黑神話：悟空》";
                    label_SBR_title_SBRName.Text = "存檔快速備份及還原工具";
                    pictureBox_WuKong_HeiShenHua.Visible = true;
                    pictureBox_WuKong_Text.Image = Resources.wukong_title;
                    //工具功能文字变化
                    label_SBR_list_KuaiJieJian.Text = "快捷鍵";
                    label_SBR_list_GongNengLieBiao.Text = "功能列表";
                    label_SBR_list_F11_Info.Text = "備份存檔";
                    label_SBR_list_F12_Info.Text = "還原存檔";
                    //工具信息文字变化
                    label_SBR_creditor.Text = "作者：ZJHCOFI | zjhcofi.com";
                    label_SBR_version.Text = "軟體版本：Build.2024.08.25";
                    break;
                case "English":
                    //控件变化
                    radioButton_cn.ForeColor = Color.White;
                    radioButton_tc.ForeColor = Color.White;
                    radioButton_en.ForeColor = Color.FromArgb(255, 128, 0);
                    button_SBR_switch_F11.Font = new Font("微软雅黑", 7.5F, FontStyle.Bold, GraphicsUnit.Point);
                    button_SBR_switch_F12.Font = new Font("微软雅黑", 7.5F, FontStyle.Bold, GraphicsUnit.Point);
                    button_SBR_Default_SavePath.Font = new Font("微软雅黑", 7.5F, FontStyle.Bold, GraphicsUnit.Point);
                    label_SBR_Default_info.Font = new Font("微软雅黑", 8F, FontStyle.Bold, GraphicsUnit.Point);
                    label_SBR_Default_SavePath.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point);
                    label_SBR_Default_SaveUser.Font = new Font("微软雅黑", 8F, FontStyle.Bold, GraphicsUnit.Point);
                    if (bool_ConfigStatus == false)
                    {
                        button_SBR_switch_F11.Text = "N/A";
                        button_SBR_switch_F12.Text = "N/A";
                    }
                    else
                    {
                        button_SBR_switch_F11.Text = "APPLY";
                        button_SBR_switch_F12.Text = "APPLY";
                    }
                    button_SBR_Default_SavePath.Text = "Choose Path";
                    label_SBR_Default_info.Text = "      Missing or incorrect tool configuration file, please \"Choose Path\"";
                    label_SBR_Default_SavePath.Text = "Game save path:";
                    label_SBR_Default_SaveUser.Text = "Please select the user who needs to backup or recover the saved:";
                    linkLabel_SBR_Default_SavePath.Text = "Game save path explanation";
                    toolTip_info.SetToolTip(pictureBox_Btn_Quit, "Quit");
                    toolTip_info.SetToolTip(pictureBox_Btn_Minimized, "Minimized");
                    label_info_SavedBackup.Font = new Font("微软雅黑", 24F, FontStyle.Bold, GraphicsUnit.Point);
                    label_info_SavedBackup.Text = "Saved Backup";
                    label_info_WuKongWebsite.Font = new Font("微软雅黑", 15F, FontStyle.Bold, GraphicsUnit.Point);
                    label_info_WuKongWebsite.Text = "About\nBLACK MYTH WUKONG";
                    label_info_SBR.Font = new Font("微软雅黑", 20F, FontStyle.Bold, GraphicsUnit.Point);
                    label_info_SBR.Text = "About Software";
                    label_SBR_title_GameName.Text = " BLACK MYTH WUKONG";
                    label_SBR_title_SBRName.Text = "Saved Backup And Recover Tool";
                    pictureBox_WuKong_HeiShenHua.Visible = false;
                    pictureBox_WuKong_Text.Image = Resources.wukong_title_en;
                    //工具功能文字变化
                    label_SBR_list_KuaiJieJian.Text = "Hotkeys";
                    label_SBR_list_GongNengLieBiao.Text = "Options";
                    label_SBR_list_F11_Info.Text = "Saved Backup";
                    label_SBR_list_F12_Info.Text = "Saved Recover";
                    //工具信息文字变化
                    label_SBR_creditor.Text = "Credit: ZJHCOFI | zjhcofi.com";
                    label_SBR_version.Text = "Software Version: Build.2024.08.25";
                    break;
                default:
                    break;
            }
        }

        //事件：点击“游戏路径说明”
        private void linkLabel_SBR_Default_SavePath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SavedPath_Explanation savedPath_Explanation = new SavedPath_Explanation();
            savedPath_Explanation.ShowDialog();
        }

        //事件：Label鼠标经过事件
        private void label_MouseMove(object sender, EventArgs e)
        {
            switch (((Label)sender).Name.ToString())
            {
                case "label_SBR_creditor":
                    label_SBR_creditor.ForeColor = Color.FromArgb(255, 128, 0);
                    label_SBR_creditor.Cursor = Cursors.Hand;
                    break;
                case "label_SBR_version":
                    label_SBR_version.ForeColor = Color.FromArgb(255, 128, 0);
                    label_SBR_version.Cursor = Cursors.Hand;
                    break;
                default:
                    break;
            }
        }

        //事件：Label鼠标离开事件
        private void label_MouseLeave(object sender, EventArgs e)
        {
            switch (((Label)sender).Name.ToString())
            {
                case "label_SBR_creditor":
                    label_SBR_creditor.ForeColor = Color.DarkGray;
                    label_SBR_creditor.Cursor = Cursors.Default;
                    break;
                case "label_SBR_version":
                    label_SBR_version.ForeColor = Color.DarkGray;
                    label_SBR_version.Cursor = Cursors.Default;
                    break;
                default:
                    break;
            }
        }

        //事件：Label鼠标点击事件
        private void label_Click(object sender, EventArgs e)
        {
            switch (((Label)sender).Name.ToString())
            {
                case "label_SBR_creditor":
                    Process.Start("https://zjhcofi.com");
                    break;
                case "label_SBR_version":
                    Process.Start("https://github.com/zjhcofi");
                    break;
                default:
                    break;
            }
        }

        //事件：鼠标左键按住窗口上方
        private void panel_head_MouseDown(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                return;
            }
            panel_head.Cursor = Cursors.NoMove2D;
            oldMousePosition = e.Location;
            bool_Moving = true;
        }

        //事件：鼠标松开窗口上方
        private void panel_head_MouseUp(object sender, MouseEventArgs e)
        {
            panel_head.Cursor = Cursors.Default;
            bool_Moving = false;
        }

        //事件：鼠标左键拖动窗口上方
        private void panel_head_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && bool_Moving)
            {
                Point newPosition = new Point(e.Location.X - oldMousePosition.X, e.Location.Y - oldMousePosition.Y);
                Location += new Size(newPosition);
            }
        }

        //事件：窗口关闭前的确认
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("您确认退出吗？\nAre you sure to quit?", "温馨提示 Tips", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Dispose();
                //强制退出（含线程）
                Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
