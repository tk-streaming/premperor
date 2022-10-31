
namespace premperor
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtRanking = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.SettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyURLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslObservationType = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslNumOfQueue = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtRanking
            // 
            this.txtRanking.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtRanking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRanking.Location = new System.Drawing.Point(0, 33);
            this.txtRanking.Multiline = true;
            this.txtRanking.Name = "txtRanking";
            this.txtRanking.ReadOnly = true;
            this.txtRanking.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRanking.Size = new System.Drawing.Size(814, 307);
            this.txtRanking.TabIndex = 3;
            this.txtRanking.TextChanged += new System.EventHandler(this.txtRanking_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingsToolStripMenuItem,
            this.CopyURLToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(814, 33);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // SettingsToolStripMenuItem
            // 
            this.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem";
            this.SettingsToolStripMenuItem.Size = new System.Drawing.Size(64, 29);
            this.SettingsToolStripMenuItem.Text = "設定";
            this.SettingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // CopyURLToolStripMenuItem
            // 
            this.CopyURLToolStripMenuItem.Name = "CopyURLToolStripMenuItem";
            this.CopyURLToolStripMenuItem.Size = new System.Drawing.Size(147, 29);
            this.CopyURLToolStripMenuItem.Text = "表示URLをコピー";
            this.CopyURLToolStripMenuItem.Click += new System.EventHandler(this.CopyURLToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslObservationType,
            this.tsslNumOfQueue});
            this.statusStrip1.Location = new System.Drawing.Point(0, 308);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(814, 32);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslObservationType
            // 
            this.tsslObservationType.Name = "tsslObservationType";
            this.tsslObservationType.Size = new System.Drawing.Size(181, 25);
            this.tsslObservationType.Text = "toolStripStatusLabel1";
            // 
            // tsslNumOfQueue
            // 
            this.tsslNumOfQueue.Name = "tsslNumOfQueue";
            this.tsslNumOfQueue.Size = new System.Drawing.Size(0, 25);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 340);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txtRanking);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "PREmperor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtUserList;
        private System.Windows.Forms.TextBox txtRanking;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem SettingsToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslNumOfQueue;
        private System.Windows.Forms.ToolStripMenuItem CopyURLToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel tsslObservationType;
    }
}

