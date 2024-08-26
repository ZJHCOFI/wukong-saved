namespace WuKong_Saved_Backup_Recover
{
    partial class Saved_Backup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Saved_Backup));
            this.label_title = new System.Windows.Forms.Label();
            this.textBox_keyword = new System.Windows.Forms.TextBox();
            this.label_info_SavedKeyword = new System.Windows.Forms.Label();
            this.button_ok = new System.Windows.Forms.Button();
            this.label_info_SavedName = new System.Windows.Forms.Label();
            this.label_SavedName = new System.Windows.Forms.Label();
            this.label_info_User = new System.Windows.Forms.Label();
            this.label_User = new System.Windows.Forms.Label();
            this.groupBox_SavedBackup = new System.Windows.Forms.GroupBox();
            this.label_Explanation = new System.Windows.Forms.Label();
            this.groupBox_SavedBackup.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_title
            // 
            this.label_title.AutoSize = true;
            this.label_title.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_title.Location = new System.Drawing.Point(53, 16);
            this.label_title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(289, 27);
            this.label_title.TabIndex = 2;
            this.label_title.Text = "存档快速备份(Saved Backup)";
            // 
            // textBox_keyword
            // 
            this.textBox_keyword.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.textBox_keyword.Location = new System.Drawing.Point(137, 31);
            this.textBox_keyword.Name = "textBox_keyword";
            this.textBox_keyword.Size = new System.Drawing.Size(206, 25);
            this.textBox_keyword.TabIndex = 0;
            this.textBox_keyword.TextChanged += new System.EventHandler(this.textBox_keyword_TextChanged);
            // 
            // label_info_SavedKeyword
            // 
            this.label_info_SavedKeyword.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.label_info_SavedKeyword.Location = new System.Drawing.Point(6, 23);
            this.label_info_SavedKeyword.Name = "label_info_SavedKeyword";
            this.label_info_SavedKeyword.Size = new System.Drawing.Size(126, 43);
            this.label_info_SavedKeyword.TabIndex = 4;
            this.label_info_SavedKeyword.Text = "存档备注信息：\r\nSaved Keyword:";
            this.label_info_SavedKeyword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_ok
            // 
            this.button_ok.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_ok.Location = new System.Drawing.Point(136, 306);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(132, 32);
            this.button_ok.TabIndex = 1;
            this.button_ok.Text = "确认(Confirm)";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // label_info_SavedName
            // 
            this.label_info_SavedName.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.label_info_SavedName.Location = new System.Drawing.Point(6, 74);
            this.label_info_SavedName.Name = "label_info_SavedName";
            this.label_info_SavedName.Size = new System.Drawing.Size(126, 43);
            this.label_info_SavedName.TabIndex = 6;
            this.label_info_SavedName.Text = "存档名称：\r\nSaved Name:";
            this.label_info_SavedName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_SavedName
            // 
            this.label_SavedName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_SavedName.Location = new System.Drawing.Point(134, 74);
            this.label_SavedName.Name = "label_SavedName";
            this.label_SavedName.Size = new System.Drawing.Size(209, 43);
            this.label_SavedName.TabIndex = 7;
            this.label_SavedName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_info_User
            // 
            this.label_info_User.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.label_info_User.Location = new System.Drawing.Point(6, 125);
            this.label_info_User.Name = "label_info_User";
            this.label_info_User.Size = new System.Drawing.Size(126, 43);
            this.label_info_User.TabIndex = 8;
            this.label_info_User.Text = "涉及用户：\r\nUsers:";
            this.label_info_User.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_User
            // 
            this.label_User.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.label_User.Location = new System.Drawing.Point(134, 125);
            this.label_User.Name = "label_User";
            this.label_User.Size = new System.Drawing.Size(209, 43);
            this.label_User.TabIndex = 9;
            this.label_User.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox_SavedBackup
            // 
            this.groupBox_SavedBackup.Controls.Add(this.label_info_SavedName);
            this.groupBox_SavedBackup.Controls.Add(this.label_User);
            this.groupBox_SavedBackup.Controls.Add(this.label_info_SavedKeyword);
            this.groupBox_SavedBackup.Controls.Add(this.label_info_User);
            this.groupBox_SavedBackup.Controls.Add(this.textBox_keyword);
            this.groupBox_SavedBackup.Controls.Add(this.label_SavedName);
            this.groupBox_SavedBackup.Location = new System.Drawing.Point(21, 92);
            this.groupBox_SavedBackup.Name = "groupBox_SavedBackup";
            this.groupBox_SavedBackup.Size = new System.Drawing.Size(360, 199);
            this.groupBox_SavedBackup.TabIndex = 10;
            this.groupBox_SavedBackup.TabStop = false;
            // 
            // label_Explanation
            // 
            this.label_Explanation.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label_Explanation.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label_Explanation.Location = new System.Drawing.Point(40, 53);
            this.label_Explanation.Name = "label_Explanation";
            this.label_Explanation.Size = new System.Drawing.Size(319, 37);
            this.label_Explanation.TabIndex = 13;
            this.label_Explanation.Text = "存档备份说明：备份的是【当前进度】中【最后一次上香】或【最后一次游戏自动保存】时的存档";
            // 
            // Saved_Backup
            // 
            this.AcceptButton = this.button_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 350);
            this.Controls.Add(this.label_Explanation);
            this.Controls.Add(this.groupBox_SavedBackup);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.label_title);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Saved_Backup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "存档快速备份(Saved Backup)";
            this.Load += new System.EventHandler(this.Saved_Backup_Load);
            this.groupBox_SavedBackup.ResumeLayout(false);
            this.groupBox_SavedBackup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.TextBox textBox_keyword;
        private System.Windows.Forms.Label label_info_SavedKeyword;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Label label_info_SavedName;
        private System.Windows.Forms.Label label_SavedName;
        private System.Windows.Forms.Label label_info_User;
        private System.Windows.Forms.Label label_User;
        private System.Windows.Forms.GroupBox groupBox_SavedBackup;
        private System.Windows.Forms.Label label_Explanation;
    }
}