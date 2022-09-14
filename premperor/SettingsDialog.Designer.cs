
namespace premperor
{
    partial class SettingsDialog
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
            this.components = new System.ComponentModel.Container();
            this.numHttpPort = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numWsPort = new System.Windows.Forms.NumericUpDown();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnFindOneCommentDir = new System.Windows.Forms.Button();
            this.txtOneCommentDir = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDisplayPath = new System.Windows.Forms.TextBox();
            this.btnFindDisplay = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.numSendInterval = new System.Windows.Forms.NumericUpDown();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.numRankingLimit = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numPoolingInterval = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.rbPoolingType = new System.Windows.Forms.RadioButton();
            this.rbWatchingType = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.numHttpPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWsPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSendInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRankingLimit)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPoolingInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // numHttpPort
            // 
            this.numHttpPort.Location = new System.Drawing.Point(349, 180);
            this.numHttpPort.Maximum = new decimal(new int[] {
            3999,
            0,
            0,
            0});
            this.numHttpPort.Minimum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numHttpPort.Name = "numHttpPort";
            this.numHttpPort.Size = new System.Drawing.Size(109, 31);
            this.numHttpPort.TabIndex = 0;
            this.numHttpPort.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(142, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "HTTPサーバーのポート番号:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(249, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "WebScoketサーバーのポート番号:";
            // 
            // numWsPort
            // 
            this.numWsPort.Location = new System.Drawing.Point(349, 217);
            this.numWsPort.Maximum = new decimal(new int[] {
            3999,
            0,
            0,
            0});
            this.numWsPort.Minimum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numWsPort.Name = "numWsPort";
            this.numWsPort.Size = new System.Drawing.Size(109, 31);
            this.numWsPort.TabIndex = 2;
            this.numWsPort.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(836, 320);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(257, 44);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "保存してアプリを終了";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnFindOneCommentDir
            // 
            this.btnFindOneCommentDir.Location = new System.Drawing.Point(362, 51);
            this.btnFindOneCommentDir.Name = "btnFindOneCommentDir";
            this.btnFindOneCommentDir.Size = new System.Drawing.Size(96, 40);
            this.btnFindOneCommentDir.TabIndex = 5;
            this.btnFindOneCommentDir.Text = "参照";
            this.btnFindOneCommentDir.UseVisualStyleBackColor = true;
            this.btnFindOneCommentDir.Click += new System.EventHandler(this.btnFindOneCommentDir_Click);
            // 
            // txtOneCommentDir
            // 
            this.txtOneCommentDir.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtOneCommentDir.Location = new System.Drawing.Point(26, 56);
            this.txtOneCommentDir.Name = "txtOneCommentDir";
            this.txtOneCommentDir.ReadOnly = true;
            this.txtOneCommentDir.Size = new System.Drawing.Size(330, 31);
            this.txtOneCommentDir.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "わんコメのデータフォルダ:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(253, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "コメントポイント表示HTMLファイル:";
            // 
            // txtDisplayPath
            // 
            this.txtDisplayPath.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtDisplayPath.Location = new System.Drawing.Point(26, 124);
            this.txtDisplayPath.Name = "txtDisplayPath";
            this.txtDisplayPath.ReadOnly = true;
            this.txtDisplayPath.Size = new System.Drawing.Size(330, 31);
            this.txtDisplayPath.TabIndex = 9;
            // 
            // btnFindDisplay
            // 
            this.btnFindDisplay.Location = new System.Drawing.Point(362, 119);
            this.btnFindDisplay.Name = "btnFindDisplay";
            this.btnFindDisplay.Size = new System.Drawing.Size(96, 40);
            this.btnFindDisplay.TabIndex = 8;
            this.btnFindDisplay.Text = "参照";
            this.btnFindDisplay.UseVisualStyleBackColor = true;
            this.btnFindDisplay.Click += new System.EventHandler(this.btnFindDisplay_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(119, 273);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(224, 25);
            this.label5.TabIndex = 12;
            this.label5.Text = "コメント表示の最小間隔[ms]:";
            // 
            // numSendInterval
            // 
            this.numSendInterval.Location = new System.Drawing.Point(349, 271);
            this.numSendInterval.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numSendInterval.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numSendInterval.Name = "numSendInterval";
            this.numSendInterval.Size = new System.Drawing.Size(109, 31);
            this.numSendInterval.TabIndex = 11;
            this.numSendInterval.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(156, 334);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(187, 25);
            this.label6.TabIndex = 14;
            this.label6.Text = "ランキングの表示上限数:";
            // 
            // numRankingLimit
            // 
            this.numRankingLimit.Location = new System.Drawing.Point(349, 328);
            this.numRankingLimit.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numRankingLimit.Name = "numRankingLimit";
            this.numRankingLimit.Size = new System.Drawing.Size(109, 31);
            this.numRankingLimit.TabIndex = 13;
            this.numRankingLimit.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numPoolingInterval);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.rbPoolingType);
            this.groupBox1.Controls.Add(this.rbWatchingType);
            this.groupBox1.Location = new System.Drawing.Point(520, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(573, 161);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "リスナーデータの監視タイプ";
            // 
            // numPoolingInterval
            // 
            this.numPoolingInterval.Location = new System.Drawing.Point(342, 113);
            this.numPoolingInterval.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numPoolingInterval.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numPoolingInterval.Name = "numPoolingInterval";
            this.numPoolingInterval.Size = new System.Drawing.Size(109, 31);
            this.numPoolingInterval.TabIndex = 19;
            this.numPoolingInterval.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(185, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(151, 25);
            this.label7.TabIndex = 2;
            this.label7.Text = "チェックの間隔[ms]:";
            // 
            // rbPoolingType
            // 
            this.rbPoolingType.AutoSize = true;
            this.rbPoolingType.Location = new System.Drawing.Point(36, 78);
            this.rbPoolingType.Name = "rbPoolingType";
            this.rbPoolingType.Size = new System.Drawing.Size(534, 29);
            this.rbPoolingType.TabIndex = 1;
            this.rbPoolingType.TabStop = true;
            this.rbPoolingType.Text = "定期的にチェック（リスナーが多い or コメントが多い配信者にお勧め）";
            this.rbPoolingType.UseVisualStyleBackColor = true;
            // 
            // rbWatchingType
            // 
            this.rbWatchingType.AutoSize = true;
            this.rbWatchingType.Location = new System.Drawing.Point(36, 43);
            this.rbWatchingType.Name = "rbWatchingType";
            this.rbWatchingType.Size = new System.Drawing.Size(449, 29);
            this.rbWatchingType.TabIndex = 0;
            this.rbWatchingType.TabStop = true;
            this.rbWatchingType.Text = "データファイルの変更時にチェック（過疎配信者にお勧め）";
            this.rbWatchingType.UseVisualStyleBackColor = true;
            // 
            // SettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 378);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numRankingLimit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numSendInterval);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDisplayPath);
            this.Controls.Add(this.btnFindDisplay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtOneCommentDir);
            this.Controls.Add(this.btnFindOneCommentDir);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numWsPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numHttpPort);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numHttpPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWsPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSendInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRankingLimit)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPoolingInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numHttpPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numWsPort;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnFindOneCommentDir;
        private System.Windows.Forms.TextBox txtOneCommentDir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDisplayPath;
        private System.Windows.Forms.Button btnFindDisplay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numSendInterval;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numRankingLimit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rbPoolingType;
        private System.Windows.Forms.RadioButton rbWatchingType;
        private System.Windows.Forms.NumericUpDown numPoolingInterval;
    }
}