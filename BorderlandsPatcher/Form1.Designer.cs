namespace BorderlandsPatcher
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.BtnPatchGame = new System.Windows.Forms.Button();
            this.BtnConsoleKey = new System.Windows.Forms.Button();
            this.TxtConsoleKey = new System.Windows.Forms.TextBox();
            this.BtnHelp = new System.Windows.Forms.Button();
            this.LblCommunityPatchVideo = new System.Windows.Forms.LinkLabel();
            this.BtnDownloadPatch = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.ComboBoxGameSelection = new System.Windows.Forms.ComboBox();
            this.LblCommunityMods = new System.Windows.Forms.LinkLabel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // BtnPatchGame
            // 
            this.BtnPatchGame.AllowDrop = true;
            this.BtnPatchGame.Location = new System.Drawing.Point(57, 43);
            this.BtnPatchGame.Name = "BtnPatchGame";
            this.BtnPatchGame.Size = new System.Drawing.Size(177, 23);
            this.BtnPatchGame.TabIndex = 0;
            this.BtnPatchGame.Text = "Patch Borderlands2.exe";
            this.BtnPatchGame.UseVisualStyleBackColor = true;
            this.BtnPatchGame.Click += new System.EventHandler(this.BtnPatchGame_Click);
            this.BtnPatchGame.DragDrop += new System.Windows.Forms.DragEventHandler(this.BtnPatchGame_DragDrop);
            this.BtnPatchGame.DragEnter += new System.Windows.Forms.DragEventHandler(this.BtnPatchGame_DragEnter);
            // 
            // BtnConsoleKey
            // 
            this.BtnConsoleKey.Location = new System.Drawing.Point(57, 72);
            this.BtnConsoleKey.Name = "BtnConsoleKey";
            this.BtnConsoleKey.Size = new System.Drawing.Size(133, 23);
            this.BtnConsoleKey.TabIndex = 1;
            this.BtnConsoleKey.Text = "Add Console Hotkey";
            this.BtnConsoleKey.UseVisualStyleBackColor = true;
            this.BtnConsoleKey.Click += new System.EventHandler(this.BtnConsoleKey_Click);
            // 
            // TxtConsoleKey
            // 
            this.TxtConsoleKey.Location = new System.Drawing.Point(196, 74);
            this.TxtConsoleKey.Name = "TxtConsoleKey";
            this.TxtConsoleKey.Size = new System.Drawing.Size(37, 20);
            this.TxtConsoleKey.TabIndex = 2;
            this.TxtConsoleKey.Text = "Tilde";
            // 
            // BtnHelp
            // 
            this.BtnHelp.Location = new System.Drawing.Point(58, 129);
            this.BtnHelp.Name = "BtnHelp";
            this.BtnHelp.Size = new System.Drawing.Size(176, 23);
            this.BtnHelp.TabIndex = 3;
            this.BtnHelp.Text = "Help";
            this.BtnHelp.UseVisualStyleBackColor = true;
            this.BtnHelp.Click += new System.EventHandler(this.BtnHelp_Click);
            // 
            // LblCommunityPatchVideo
            // 
            this.LblCommunityPatchVideo.AutoSize = true;
            this.LblCommunityPatchVideo.Location = new System.Drawing.Point(13, 186);
            this.LblCommunityPatchVideo.Name = "LblCommunityPatchVideo";
            this.LblCommunityPatchVideo.Size = new System.Drawing.Size(119, 13);
            this.LblCommunityPatchVideo.TabIndex = 4;
            this.LblCommunityPatchVideo.TabStop = true;
            this.LblCommunityPatchVideo.Text = "Community Patch Video";
            this.LblCommunityPatchVideo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LblCommunityPatchVideo_LinkClicked);
            // 
            // BtnDownloadPatch
            // 
            this.BtnDownloadPatch.Location = new System.Drawing.Point(57, 100);
            this.BtnDownloadPatch.Name = "BtnDownloadPatch";
            this.BtnDownloadPatch.Size = new System.Drawing.Size(177, 23);
            this.BtnDownloadPatch.TabIndex = 6;
            this.BtnDownloadPatch.Text = "Download Patch";
            this.BtnDownloadPatch.UseVisualStyleBackColor = true;
            this.BtnDownloadPatch.Click += new System.EventHandler(this.BtnDownloadPatch_Click);
            // 
            // ComboBoxGameSelection
            // 
            this.ComboBoxGameSelection.FormattingEnabled = true;
            this.ComboBoxGameSelection.Items.AddRange(new object[] {
            "Borderlands 2",
            "Borderlands The Pre-Sequel"});
            this.ComboBoxGameSelection.Location = new System.Drawing.Point(57, 12);
            this.ComboBoxGameSelection.Name = "ComboBoxGameSelection";
            this.ComboBoxGameSelection.Size = new System.Drawing.Size(177, 21);
            this.ComboBoxGameSelection.TabIndex = 7;
            this.ComboBoxGameSelection.Text = "Borderlands 2";
            this.ComboBoxGameSelection.SelectedIndexChanged += new System.EventHandler(this.ComboBoxGameSelection_SelectedIndexChanged);
            // 
            // LblCommunityMods
            // 
            this.LblCommunityMods.AutoSize = true;
            this.LblCommunityMods.Location = new System.Drawing.Point(185, 186);
            this.LblCommunityMods.Name = "LblCommunityMods";
            this.LblCommunityMods.Size = new System.Drawing.Size(87, 13);
            this.LblCommunityMods.TabIndex = 8;
            this.LblCommunityMods.TabStop = true;
            this.LblCommunityMods.Text = "Community Mods";
            this.LblCommunityMods.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LblCommunityMods_LinkClicked);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(58, 160);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(176, 23);
            this.progressBar1.Step = 33;
            this.progressBar1.TabIndex = 9;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 208);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.LblCommunityMods);
            this.Controls.Add(this.ComboBoxGameSelection);
            this.Controls.Add(this.BtnDownloadPatch);
            this.Controls.Add(this.LblCommunityPatchVideo);
            this.Controls.Add(this.BtnHelp);
            this.Controls.Add(this.TxtConsoleKey);
            this.Controls.Add(this.BtnConsoleKey);
            this.Controls.Add(this.BtnPatchGame);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Borderlands  Patcher";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnPatchGame;
        private System.Windows.Forms.Button BtnConsoleKey;
        private System.Windows.Forms.TextBox TxtConsoleKey;
        private System.Windows.Forms.Button BtnHelp;
        private System.Windows.Forms.LinkLabel LblCommunityPatchVideo;
        private System.Windows.Forms.Button BtnDownloadPatch;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ComboBox ComboBoxGameSelection;
        private System.Windows.Forms.LinkLabel LblCommunityMods;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}