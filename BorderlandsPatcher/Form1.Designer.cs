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
            this.lblNMBL2 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.pathGame = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pathExe = new System.Windows.Forms.TextBox();
            this.buttonPathDetect = new System.Windows.Forms.Button();
            this.pathGameEdit = new System.Windows.Forms.Button();
            this.pathExeEdit = new System.Windows.Forms.Button();
            this.lblGithub = new System.Windows.Forms.LinkLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // BtnPatchGame
            // 
            this.BtnPatchGame.AllowDrop = true;
            this.BtnPatchGame.Location = new System.Drawing.Point(54, 146);
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
            this.BtnConsoleKey.Location = new System.Drawing.Point(54, 175);
            this.BtnConsoleKey.Name = "BtnConsoleKey";
            this.BtnConsoleKey.Size = new System.Drawing.Size(133, 23);
            this.BtnConsoleKey.TabIndex = 1;
            this.BtnConsoleKey.Text = "Add Console Hotkey";
            this.BtnConsoleKey.UseVisualStyleBackColor = true;
            this.BtnConsoleKey.Click += new System.EventHandler(this.BtnConsoleKey_Click);
            // 
            // TxtConsoleKey
            // 
            this.TxtConsoleKey.Location = new System.Drawing.Point(193, 177);
            this.TxtConsoleKey.Name = "TxtConsoleKey";
            this.TxtConsoleKey.Size = new System.Drawing.Size(37, 20);
            this.TxtConsoleKey.TabIndex = 2;
            this.TxtConsoleKey.Text = "Tilde";
            // 
            // BtnHelp
            // 
            this.BtnHelp.Location = new System.Drawing.Point(55, 233);
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
            this.LblCommunityPatchVideo.Location = new System.Drawing.Point(12, 363);
            this.LblCommunityPatchVideo.Name = "LblCommunityPatchVideo";
            this.LblCommunityPatchVideo.Size = new System.Drawing.Size(119, 13);
            this.LblCommunityPatchVideo.TabIndex = 4;
            this.LblCommunityPatchVideo.TabStop = true;
            this.LblCommunityPatchVideo.Text = "Community Patch Video";
            this.LblCommunityPatchVideo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LblCommunityPatchVideo_LinkClicked);
            // 
            // BtnDownloadPatch
            // 
            this.BtnDownloadPatch.Location = new System.Drawing.Point(54, 204);
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
            this.ComboBoxGameSelection.Location = new System.Drawing.Point(94, 12);
            this.ComboBoxGameSelection.Name = "ComboBoxGameSelection";
            this.ComboBoxGameSelection.Size = new System.Drawing.Size(140, 21);
            this.ComboBoxGameSelection.TabIndex = 7;
            this.ComboBoxGameSelection.Text = "Borderlands 2";
            this.ComboBoxGameSelection.SelectedIndexChanged += new System.EventHandler(this.ComboBoxGameSelection_SelectedIndexChanged);
            // 
            // LblCommunityMods
            // 
            this.LblCommunityMods.AutoSize = true;
            this.LblCommunityMods.Location = new System.Drawing.Point(190, 337);
            this.LblCommunityMods.Name = "LblCommunityMods";
            this.LblCommunityMods.Size = new System.Drawing.Size(64, 13);
            this.LblCommunityMods.TabIndex = 8;
            this.LblCommunityMods.TabStop = true;
            this.LblCommunityMods.Text = "ModCabinet";
            this.LblCommunityMods.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LblCommunityMods_LinkClicked);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(56, 262);
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
            // lblNMBL2
            // 
            this.lblNMBL2.AutoSize = true;
            this.lblNMBL2.Location = new System.Drawing.Point(190, 363);
            this.lblNMBL2.Name = "lblNMBL2";
            this.lblNMBL2.Size = new System.Drawing.Size(88, 13);
            this.lblNMBL2.TabIndex = 10;
            this.lblNMBL2.TabStop = true;
            this.lblNMBL2.Text = "NexusMods(BL2)";
            this.lblNMBL2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblNMBL2_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(190, 324);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Links to mods:";
            // 
            // pathGame
            // 
            this.pathGame.Location = new System.Drawing.Point(15, 56);
            this.pathGame.Name = "pathGame";
            this.pathGame.Size = new System.Drawing.Size(217, 20);
            this.pathGame.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Path to game:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Path to .exe:";
            // 
            // pathExe
            // 
            this.pathExe.Location = new System.Drawing.Point(15, 100);
            this.pathExe.Name = "pathExe";
            this.pathExe.Size = new System.Drawing.Size(217, 20);
            this.pathExe.TabIndex = 15;
            // 
            // buttonPathDetect
            // 
            this.buttonPathDetect.Location = new System.Drawing.Point(12, 10);
            this.buttonPathDetect.Name = "buttonPathDetect";
            this.buttonPathDetect.Size = new System.Drawing.Size(75, 23);
            this.buttonPathDetect.TabIndex = 16;
            this.buttonPathDetect.Text = "Detect Path";
            this.buttonPathDetect.UseVisualStyleBackColor = true;
            this.buttonPathDetect.Click += new System.EventHandler(this.buttonPathDetect_Click);
            // 
            // pathGameEdit
            // 
            this.pathGameEdit.BackgroundImage = global::BorderlandsPatcher.Properties.Resources._84380;
            this.pathGameEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pathGameEdit.Location = new System.Drawing.Point(239, 56);
            this.pathGameEdit.Name = "pathGameEdit";
            this.pathGameEdit.Size = new System.Drawing.Size(19, 20);
            this.pathGameEdit.TabIndex = 17;
            this.pathGameEdit.UseVisualStyleBackColor = true;
            this.pathGameEdit.Click += new System.EventHandler(this.pathGameEdit_Click);
            // 
            // pathExeEdit
            // 
            this.pathExeEdit.BackgroundImage = global::BorderlandsPatcher.Properties.Resources._84380;
            this.pathExeEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pathExeEdit.Location = new System.Drawing.Point(239, 100);
            this.pathExeEdit.Name = "pathExeEdit";
            this.pathExeEdit.Size = new System.Drawing.Size(19, 20);
            this.pathExeEdit.TabIndex = 18;
            this.pathExeEdit.UseVisualStyleBackColor = true;
            this.pathExeEdit.Click += new System.EventHandler(this.pathExeEdit_Click);
            // 
            // lblGithub
            // 
            this.lblGithub.AutoSize = true;
            this.lblGithub.Location = new System.Drawing.Point(190, 350);
            this.lblGithub.Name = "lblGithub";
            this.lblGithub.Size = new System.Drawing.Size(38, 13);
            this.lblGithub.TabIndex = 20;
            this.lblGithub.TabStop = true;
            this.lblGithub.Text = "Github";
            this.lblGithub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblGithub_LinkClicked);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 385);
            this.Controls.Add(this.lblGithub);
            this.Controls.Add(this.pathExeEdit);
            this.Controls.Add(this.pathGameEdit);
            this.Controls.Add(this.buttonPathDetect);
            this.Controls.Add(this.pathExe);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pathGame);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNMBL2);
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
        private System.Windows.Forms.LinkLabel lblNMBL2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pathGame;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox pathExe;
        private System.Windows.Forms.Button buttonPathDetect;
        private System.Windows.Forms.Button pathGameEdit;
        private System.Windows.Forms.Button pathExeEdit;
        private System.Windows.Forms.LinkLabel lblGithub;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}