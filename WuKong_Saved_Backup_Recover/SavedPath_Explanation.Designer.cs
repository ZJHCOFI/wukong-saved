namespace WuKong_Saved_Backup_Recover
{
    partial class SavedPath_Explanation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SavedPath_Explanation));
            this.label_title = new System.Windows.Forms.Label();
            this.richTextBox_SavePathExplanation = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label_title
            // 
            this.label_title.AutoSize = true;
            this.label_title.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_title.Location = new System.Drawing.Point(53, 14);
            this.label_title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(386, 27);
            this.label_title.TabIndex = 1;
            this.label_title.Text = "游戏路径说明(Saved Path Explanation)";
            // 
            // richTextBox_SavePathExplanation
            // 
            this.richTextBox_SavePathExplanation.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox_SavePathExplanation.Location = new System.Drawing.Point(24, 48);
            this.richTextBox_SavePathExplanation.Name = "richTextBox_SavePathExplanation";
            this.richTextBox_SavePathExplanation.Size = new System.Drawing.Size(438, 212);
            this.richTextBox_SavePathExplanation.TabIndex = 3;
            this.richTextBox_SavePathExplanation.Text = resources.GetString("richTextBox_SavePathExplanation.Text");
            this.richTextBox_SavePathExplanation.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBox_about_LinkClicked);
            // 
            // SavedPath_Explanation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 279);
            this.Controls.Add(this.richTextBox_SavePathExplanation);
            this.Controls.Add(this.label_title);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "SavedPath_Explanation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "游戏路径说明(Saved Path Explanation)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.RichTextBox richTextBox_SavePathExplanation;
    }
}