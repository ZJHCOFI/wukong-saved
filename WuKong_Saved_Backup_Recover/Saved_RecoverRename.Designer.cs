namespace WuKong_Saved_Backup_Recover
{
    partial class Saved_RecoverRename
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Saved_RecoverRename));
            this.label_title = new System.Windows.Forms.Label();
            this.textBox_keyword = new System.Windows.Forms.TextBox();
            this.label_info_SavedKeyword = new System.Windows.Forms.Label();
            this.button_ok = new System.Windows.Forms.Button();
            this.label_info_SavedName = new System.Windows.Forms.Label();
            this.label_SavedName = new System.Windows.Forms.Label();
            this.groupBox_SavedBackup = new System.Windows.Forms.GroupBox();
            this.label_illegal = new System.Windows.Forms.Label();
            this.groupBox_SavedBackup.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_title
            // 
            this.label_title.AutoSize = true;
            this.label_title.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_title.Location = new System.Drawing.Point(60, 16);
            this.label_title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(278, 27);
            this.label_title.TabIndex = 2;
            this.label_title.Text = "存档重命名(Saved Rename)";
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
            this.button_ok.Location = new System.Drawing.Point(136, 249);
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
            // groupBox_SavedBackup
            // 
            this.groupBox_SavedBackup.Controls.Add(this.label_info_SavedName);
            this.groupBox_SavedBackup.Controls.Add(this.label_info_SavedKeyword);
            this.groupBox_SavedBackup.Controls.Add(this.textBox_keyword);
            this.groupBox_SavedBackup.Controls.Add(this.label_SavedName);
            this.groupBox_SavedBackup.Controls.Add(this.label_illegal);
            this.groupBox_SavedBackup.Location = new System.Drawing.Point(21, 46);
            this.groupBox_SavedBackup.Name = "groupBox_SavedBackup";
            this.groupBox_SavedBackup.Size = new System.Drawing.Size(360, 186);
            this.groupBox_SavedBackup.TabIndex = 10;
            this.groupBox_SavedBackup.TabStop = false;
            // 
            // label_illegal
            // 
            this.label_illegal.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label_illegal.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label_illegal.Location = new System.Drawing.Point(7, 119);
            this.label_illegal.Name = "label_illegal";
            this.label_illegal.Size = new System.Drawing.Size(343, 59);
            this.label_illegal.TabIndex = 13;
            this.label_illegal.Text = "注意：存档名称已自动去除非法字符\r\nAttention: The save name has automatically removed illegal char" +
    "acters";
            this.label_illegal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Saved_RecoverRename
            // 
            this.AcceptButton = this.button_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 305);
            this.Controls.Add(this.groupBox_SavedBackup);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.label_title);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Saved_RecoverRename";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "存档重命名(Saved Rename)";
            this.Load += new System.EventHandler(this.Saved_RecoverRename_Load);
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
        private System.Windows.Forms.GroupBox groupBox_SavedBackup;
        private System.Windows.Forms.Label label_illegal;
    }
}