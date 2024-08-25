namespace WuKong_Saved_Backup_Recover
{
    partial class Saved_Recover
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Saved_Recover));
            this.label_title = new System.Windows.Forms.Label();
            this.label_info_SavedRecover = new System.Windows.Forms.Label();
            this.button_ok = new System.Windows.Forms.Button();
            this.listBox_SavedRecover = new System.Windows.Forms.ListBox();
            this.label_User = new System.Windows.Forms.Label();
            this.label_info_User = new System.Windows.Forms.Label();
            this.label_Explanation = new System.Windows.Forms.Label();
            this.groupBox_SavedPath = new System.Windows.Forms.GroupBox();
            this.groupBox_SavedPath.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_title
            // 
            this.label_title.AutoSize = true;
            this.label_title.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_title.Location = new System.Drawing.Point(59, 14);
            this.label_title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(256, 27);
            this.label_title.TabIndex = 2;
            this.label_title.Text = "存档还原(Saved Recover)";
            // 
            // label_info_SavedRecover
            // 
            this.label_info_SavedRecover.AutoSize = true;
            this.label_info_SavedRecover.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.label_info_SavedRecover.Location = new System.Drawing.Point(14, 15);
            this.label_info_SavedRecover.Name = "label_info_SavedRecover";
            this.label_info_SavedRecover.Size = new System.Drawing.Size(323, 19);
            this.label_info_SavedRecover.TabIndex = 4;
            this.label_info_SavedRecover.Text = "请选择还原的存档(Choose the recover saved)：";
            this.label_info_SavedRecover.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_ok
            // 
            this.button_ok.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_ok.Location = new System.Drawing.Point(132, 393);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(136, 32);
            this.button_ok.TabIndex = 1;
            this.button_ok.Text = "确认(Confirm)";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // listBox_SavedRecover
            // 
            this.listBox_SavedRecover.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox_SavedRecover.FormattingEnabled = true;
            this.listBox_SavedRecover.HorizontalScrollbar = true;
            this.listBox_SavedRecover.ItemHeight = 17;
            this.listBox_SavedRecover.Location = new System.Drawing.Point(10, 40);
            this.listBox_SavedRecover.Name = "listBox_SavedRecover";
            this.listBox_SavedRecover.Size = new System.Drawing.Size(329, 191);
            this.listBox_SavedRecover.TabIndex = 0;
            this.listBox_SavedRecover.SelectedValueChanged += new System.EventHandler(this.listBox_SavedRecover_SelectedValueChanged);
            // 
            // label_User
            // 
            this.label_User.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.label_User.Location = new System.Drawing.Point(88, 239);
            this.label_User.Name = "label_User";
            this.label_User.Size = new System.Drawing.Size(249, 43);
            this.label_User.TabIndex = 11;
            this.label_User.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_info_User
            // 
            this.label_info_User.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.label_info_User.Location = new System.Drawing.Point(8, 239);
            this.label_info_User.Name = "label_info_User";
            this.label_info_User.Size = new System.Drawing.Size(83, 43);
            this.label_info_User.TabIndex = 10;
            this.label_info_User.Text = "涉及用户：\r\nUsers:";
            this.label_info_User.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Explanation
            // 
            this.label_Explanation.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label_Explanation.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label_Explanation.Location = new System.Drawing.Point(39, 45);
            this.label_Explanation.Name = "label_Explanation";
            this.label_Explanation.Size = new System.Drawing.Size(319, 37);
            this.label_Explanation.TabIndex = 12;
            this.label_Explanation.Text = "存档还原说明：将还原【所选中的存档】【最后一次上香】或【最后一次游戏自动保存】时的进度";
            // 
            // groupBox_SavedPath
            // 
            this.groupBox_SavedPath.Controls.Add(this.listBox_SavedRecover);
            this.groupBox_SavedPath.Controls.Add(this.label_info_SavedRecover);
            this.groupBox_SavedPath.Controls.Add(this.label_User);
            this.groupBox_SavedPath.Controls.Add(this.label_info_User);
            this.groupBox_SavedPath.Location = new System.Drawing.Point(24, 83);
            this.groupBox_SavedPath.Name = "groupBox_SavedPath";
            this.groupBox_SavedPath.Size = new System.Drawing.Size(351, 295);
            this.groupBox_SavedPath.TabIndex = 13;
            this.groupBox_SavedPath.TabStop = false;
            // 
            // Saved_Recover
            // 
            this.AcceptButton = this.button_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 438);
            this.Controls.Add(this.groupBox_SavedPath);
            this.Controls.Add(this.label_Explanation);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.label_title);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Saved_Recover";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "存档还原(Saved Recover)";
            this.Load += new System.EventHandler(this.Saved_Recover_Load);
            this.groupBox_SavedPath.ResumeLayout(false);
            this.groupBox_SavedPath.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Label label_info_SavedRecover;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.ListBox listBox_SavedRecover;
        private System.Windows.Forms.Label label_User;
        private System.Windows.Forms.Label label_info_User;
        private System.Windows.Forms.Label label_Explanation;
        private System.Windows.Forms.GroupBox groupBox_SavedPath;
    }
}