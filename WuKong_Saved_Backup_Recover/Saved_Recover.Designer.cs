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
            this.button_Recover = new System.Windows.Forms.Button();
            this.listBox_SavedRecover = new System.Windows.Forms.ListBox();
            this.label_User = new System.Windows.Forms.Label();
            this.label_info_User = new System.Windows.Forms.Label();
            this.label_Explanation = new System.Windows.Forms.Label();
            this.groupBox_SavedPath = new System.Windows.Forms.GroupBox();
            this.button_Delete = new System.Windows.Forms.Button();
            this.groupBox_Button = new System.Windows.Forms.GroupBox();
            this.button_Rename = new System.Windows.Forms.Button();
            this.groupBox_SavedPath.SuspendLayout();
            this.groupBox_Button.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_title
            // 
            this.label_title.AutoSize = true;
            this.label_title.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_title.Location = new System.Drawing.Point(38, 14);
            this.label_title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(502, 27);
            this.label_title.TabIndex = 2;
            this.label_title.Text = "存档还原和管理(Saved Recover and Management)";
            // 
            // label_info_SavedRecover
            // 
            this.label_info_SavedRecover.AutoSize = true;
            this.label_info_SavedRecover.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.label_info_SavedRecover.Location = new System.Drawing.Point(7, 15);
            this.label_info_SavedRecover.Name = "label_info_SavedRecover";
            this.label_info_SavedRecover.Size = new System.Drawing.Size(295, 19);
            this.label_info_SavedRecover.TabIndex = 4;
            this.label_info_SavedRecover.Text = "请选择需要操作的存档(Choose the saved)：";
            this.label_info_SavedRecover.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_Recover
            // 
            this.button_Recover.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Recover.Location = new System.Drawing.Point(12, 60);
            this.button_Recover.Name = "button_Recover";
            this.button_Recover.Size = new System.Drawing.Size(143, 32);
            this.button_Recover.TabIndex = 1;
            this.button_Recover.Text = "还原(Recover)";
            this.button_Recover.UseVisualStyleBackColor = true;
            this.button_Recover.Click += new System.EventHandler(this.button_ok_Click);
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
            this.label_Explanation.Location = new System.Drawing.Point(61, 47);
            this.label_Explanation.Name = "label_Explanation";
            this.label_Explanation.Size = new System.Drawing.Size(450, 37);
            this.label_Explanation.TabIndex = 12;
            this.label_Explanation.Text = "存档还原说明：还原的是【所选存档】里【最后一次上香】或【游戏最后一次自动保存】时的进度";
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
            // button_Delete
            // 
            this.button_Delete.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Delete.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_Delete.Location = new System.Drawing.Point(12, 180);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(143, 32);
            this.button_Delete.TabIndex = 3;
            this.button_Delete.Text = "删除(Delete)";
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.button_del_Click);
            // 
            // groupBox_Button
            // 
            this.groupBox_Button.Controls.Add(this.button_Rename);
            this.groupBox_Button.Controls.Add(this.button_Recover);
            this.groupBox_Button.Controls.Add(this.button_Delete);
            this.groupBox_Button.Location = new System.Drawing.Point(391, 83);
            this.groupBox_Button.Name = "groupBox_Button";
            this.groupBox_Button.Size = new System.Drawing.Size(170, 295);
            this.groupBox_Button.TabIndex = 14;
            this.groupBox_Button.TabStop = false;
            // 
            // button_Rename
            // 
            this.button_Rename.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Rename.Location = new System.Drawing.Point(12, 120);
            this.button_Rename.Name = "button_Rename";
            this.button_Rename.Size = new System.Drawing.Size(145, 32);
            this.button_Rename.TabIndex = 2;
            this.button_Rename.Text = "重命名(Rename)";
            this.button_Rename.UseVisualStyleBackColor = true;
            this.button_Rename.Click += new System.EventHandler(this.button_Rename_Click);
            // 
            // Saved_Recover
            // 
            this.AcceptButton = this.button_Recover;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 403);
            this.Controls.Add(this.groupBox_Button);
            this.Controls.Add(this.groupBox_SavedPath);
            this.Controls.Add(this.label_Explanation);
            this.Controls.Add(this.label_title);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Saved_Recover";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "存档还原和管理(Saved Recover and Management)";
            this.Load += new System.EventHandler(this.Saved_Recover_Load);
            this.groupBox_SavedPath.ResumeLayout(false);
            this.groupBox_SavedPath.PerformLayout();
            this.groupBox_Button.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Label label_info_SavedRecover;
        private System.Windows.Forms.Button button_Recover;
        private System.Windows.Forms.ListBox listBox_SavedRecover;
        private System.Windows.Forms.Label label_User;
        private System.Windows.Forms.Label label_info_User;
        private System.Windows.Forms.Label label_Explanation;
        private System.Windows.Forms.GroupBox groupBox_SavedPath;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.GroupBox groupBox_Button;
        private System.Windows.Forms.Button button_Rename;
    }
}