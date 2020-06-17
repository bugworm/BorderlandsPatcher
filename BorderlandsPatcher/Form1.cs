using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BorderlandsPatcher
{
    public partial class Form1 : Form
    {
        private bool isBorderlands2 = true;
        private string b2il = String.Empty;
        private string btpsil = String.Empty;
        private string filepath;

        public Form1()
        {
            InitializeComponent();
        }

        public static string AskForInstallLocation(FolderBrowserDialog folderBrowser, bool isBorderlands)
        {
            folderBrowser.ShowNewFolderButton = false;

            if (isBorderlands)
            {
                folderBrowser.Description = "Select the Borderlands 2 installation directory.\n\n";
                folderBrowser.Description += "It's usually ...\\Steam(Library)\\steamapps\\common\\Borderlands 2";
            }
            else
            {
                folderBrowser.Description = "Select the Borderlands Pre Sequel installation directory.\n\n";
                folderBrowser.Description += "It's usually ...\\Steam(Library)\\steamapps\\common\\BorderlandsPreSequel";
            }

            DialogResult result = folderBrowser.ShowDialog();

            if (result == DialogResult.OK)
            {
                return folderBrowser.SelectedPath;
            }

            return String.Empty;
        }

        public static string AskForExeLocation(OpenFileDialog openFileDialog, string blil)
        {
            if (!String.IsNullOrEmpty(blil))
                openFileDialog.InitialDirectory = blil;

            openFileDialog.Title = "Select .exe file you want to patch";

            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                return openFileDialog.FileName;
            }

            return String.Empty;
        }

        public byte[] GetFileViaHttp(string url)
        {
            using (WebClient client = new WebClient())
            {
                return client.DownloadData(url);
            }
        }

        public string[] getTextFile(string url)
        {
            var file = GetFileViaHttp(url);
            string str = Encoding.UTF8.GetString(file);
            string[] content = str.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            return content;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            FindBL2Steam();
            FindTPSSteam();
            ChechGame();
        }

        private void FindTPSSteam()
        {
            // get install path of Borderlands The PreSequel
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 261640");
            if (key != null)
            {
                btpsil = key.GetValue("InstallLocation") as string;
            }
            else
            {
                key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Steam App 261640");
                if (key != null)
                {
                    btpsil = key.GetValue("InstallLocation") as string;
                }
            }
            // else key could not be found
        }

        private void FindBL2Steam()
        {
            // get install path of Borderlands 2
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 49520");
            if (key != null)
            {
                b2il = key.GetValue("InstallLocation") as string;
            }
            else
            {
                key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Steam App 49520");
                if (key != null)
                {
                    b2il = key.GetValue("InstallLocation") as string;
                }
            }
            // else key could not be found
        }

        private void BtnPatchGame_Click(object sender, EventArgs e)
        {
            //string filepath;
            try
            {
                if (isBorderlands2)
                {
                    // if we don't know the install location
                    if (String.IsNullOrEmpty(b2il))
                    {
                        b2il = AskForInstallLocation(folderBrowserDialog1, isBorderlands2);
                    }
                }
                else
                {
                    // if we don't know the install location
                    if (String.IsNullOrEmpty(btpsil))
                    {
                        btpsil = AskForInstallLocation(folderBrowserDialog1, isBorderlands2);
                    }
                }

                filepath = pathExe.Text;

                if (VerifyExe(filepath))
                {
                    PatchExe(filepath);
                }
                else
                {
                    MessageBox.Show("Did you select the folder? I can't patch the air");
                }
            }
            catch (Exception err)
            {
                string message = String.Format("Error: {0}\n{1}\n\nStack Trace:\n{2}", err.HResult, err.Message, err.StackTrace);
                MessageBox.Show(message, "this is a caption", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
        }

        private void PatchExe(string file)
        {
            //if (file.EndsWith("Borderlands2.exe") || file.EndsWith("borderlands2.exe"))
            try
            {
                File.Copy(file, file + ".bk", false);
            }
            catch (IOException)
            {
                MessageBox.Show("You already have a backup. Skipping.");
            }
            MessageBox.Show("This would take couple minutes. Please be patient...");

            backgroundWorker1.RunWorkerAsync();
            progressBar1.Value = 0;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //progressBar1.Value = 20;
            backgroundWorker1.ReportProgress(15);
            byte[] dataArraySay = new byte[32] { 0x61, 0x00, 0x77, 0x00, 0x20, 0x00, 0x5B, 0x00, 0x47, 0x00, 0x54, 0x00, 0x5D, 0x00, 0x00, 0x00, 0x73, 0x00, 0x61, 0x00, 0x79, 0x00, 0x20, 0x00, 0x00, 0x00, 0x00, 0x00, 0x6D, 0x73, 0x67, 0x20 };
            byte[] dataArraySayChanged = new byte[32] { 0x61, 0x00, 0x77, 0x00, 0x20, 0x00, 0x5B, 0x00, 0x47, 0x00, 0x54, 0x00, 0x5D, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x20, 0x00, 0x00, 0x00, 0x00, 0x00, 0x6D, 0x73, 0x67, 0x20 };
            byte[] dataArraySet = new byte[8] { 0x83, 0xC4, 0x0C, 0x85, 0xC0, 0x75, 0x1A, 0x6A };
            byte[] dataArraySetChanged = new byte[8] { 0x83, 0xC4, 0x0C, 0x85, 0xFF, 0x75, 0x1A, 0x6A };
            long positions = 0;
            long positions2 = 0;

            positions = FindBytes(filepath, dataArraySay);
            if (positions == 0)
            {
                MessageBox.Show("Looks like binary file is already patched or it's a bug. Check if it's working", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                backgroundWorker1.ReportProgress(100);
                backgroundWorker1.CancelAsync();
            }
            backgroundWorker1.ReportProgress(55);
            positions2 = FindBytes(filepath, dataArraySet);
            backgroundWorker1.ReportProgress(95);

            if (positions2 == 0)
            {
                MessageBox.Show("Looks like binary file is already patched or it's a bug. Check if it's working", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                backgroundWorker1.ReportProgress(100);
                backgroundWorker1.CancelAsync();
            }
            var stream = new FileStream(filepath, FileMode.Open, FileAccess.ReadWrite);
            stream.Position = positions;
            stream.Write(dataArraySayChanged, 0, 32);
            stream.Position = positions2;
            stream.Write(dataArraySetChanged, 0, 8);
            stream.Close();
            backgroundWorker1.ReportProgress(100);
            MessageBox.Show("Done!");
        }

        private long FindBytes(string fileName, byte[] bytes)
        {
            long i;
            int j, k = 0;
            using (FileStream fs = File.OpenRead(fileName))
            {
                for (i = 0; i < fs.Length - bytes.Length; i++)
                {
                    fs.Seek(i, SeekOrigin.Begin);
                    for (j = 0; j < bytes.Length; j++)
                    {
                        if (fs.ReadByte() != bytes[j])
                            break;
                    }
                    if (j == bytes.Length)
                        return i;
                }
                fs.Close();
            }
            return 0;
        }


        private bool VerifyExe(string file)
        {
            bool isExeExtension = false;
            bool isExeMagicNumber = false;
            try
            {
                // if the file has the correct extension
                isExeExtension = (Path.GetExtension(file) == ".exe");

                // open IDisposable object safely
                using (FileStream stream = File.OpenRead(file))
                {
                    byte[] magicNumber = { 0x0, 0x0 };

                    stream.Seek(0, SeekOrigin.Begin);
                    stream.Read(magicNumber, 0, 2);
                    // if the first two bytes are 0x4D5A
                    isExeMagicNumber = (magicNumber[0] == 0x4D) && (magicNumber[1] == 0x5A);
                }
            }
            catch (Exception)
            {
                // suppress exceptions
            }

            // microsoft doesn't do magic numbers right
            // (*.dll, *.exe, and *.sys all have the same one)
            // so let's hope the extension doesn't lie to us
            return (isExeExtension && isExeMagicNumber);
        }

        private void BtnConsoleKey_Click(object sender, EventArgs e)
        {
            string tmppath;
            if (isBorderlands2)
            {
                tmppath = "\\my games\\borderlands 2\\willowgame\\Config\\WillowInput.ini";
            }
            else
            {
                tmppath = "\\my games\\borderlands the pre-sequel\\willowgame\\Config\\WillowInput.ini";
            }
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + tmppath;
            string[] temp = File.ReadAllLines(path);
            int i;
            for (i = 1; i <= temp.Length; i++)
            {
                if (temp[i].StartsWith("ConsoleKey="))
                    break;
            }
            temp[i] = "ConsoleKey=" + TxtConsoleKey.Text;
            File.WriteAllLines(path, temp);
            //TODO: Check if it worked and write correct message
            MessageBox.Show("Done!");
        }

        private void BtnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To use Community Patch you need to patch your Borderlands2(PreSequel).exe (it will backup the original file, don't worry), add console hotkey if you don't have one and place the patch file(Patch.txt and PatchOffline.txt) in the Binaries directory. Program will find your game path and download latest patch automatically, if it won't find it, you can still choose the path manually. Then launch your game, open console, type \"exec Patch.txt\"(or PatchOffline.txt if you want to play offline) and press enter. Do it after game downloads all stuff(when you see actual menu). That's all, you can now enjoy the patch! It will work only for current session, you need to enter console command every time you launch the game. You can press \"Arrow Up\" to show your last typed command in the console.");
        }

        private void LblCommunityPatchVideo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LblCommunityPatchVideo.LinkVisited = true;
            System.Diagnostics.Process.Start("https://youtu.be/o_ee3BM1TQQ");
        }

        private void BtnDownloadPatch_Click(object sender, EventArgs e)
        {
            string path;
            string[] content, contentOffline;
            try
            {
                if (isBorderlands2)
                {
                    // if we don't know the install location
                    if (String.IsNullOrEmpty(b2il))
                    {
                        b2il = AskForInstallLocation(folderBrowserDialog1, isBorderlands2);
                    }

                    path = b2il;

                    content = getTextFile(@"https://raw.githubusercontent.com/BLCM/BLCMods/master/Borderlands%202%20mods/Community%20Patch%20Team/Patch.txt");
                    contentOffline = getTextFile(@"https://raw.githubusercontent.com/BLCM/BLCMods/master/Borderlands%202%20mods/Community%20Patch%20Team/PatchOffline.txt");
                }
                else
                {
                    // if we don't know the install location
                    if (String.IsNullOrEmpty(btpsil))
                    {
                        btpsil = AskForInstallLocation(folderBrowserDialog1, isBorderlands2);
                    }

                    path = btpsil;

                    content = getTextFile(@"https://raw.githubusercontent.com/BLCM/BLCMods/master/Pre%20Sequel%20Mods/Community%20Patch/Community%20Patch%202.2/Patch");
                }

                if (path != "")
                {
                    File.WriteAllLines(path + "\\Binaries\\Patch.txt", content);
                    MessageBox.Show("Done!");
                }
                else
                {
                    MessageBox.Show("Cannot read path. I will redirect you to patch location, download it manually and place it in ...\\Borderlands 2(PreSequel)\\Binaries directory.");
                    ShowLink();
                }

            }
            catch (System.Net.WebException)
            {
                MessageBox.Show("Looks like you don't have an internet connection. I can't download patch for you, sorry. I will redirect you to patch location instead, download it manually and place it in ...\\Borderlands 2(PreSequel)\\Binaries directory.");
                //System.Diagnostics.Process.Start("https://github.com/BLCM/BLCMods");
                ShowLink();
            }
        }

        private void ShowLink()
        {
            if (isBorderlands2)
            {
                System.Diagnostics.Process.Start("https://github.com/BLCM/ModCabinet/wiki/Community-Patch");
            }
            else System.Diagnostics.Process.Start("https://github.com/BLCM/ModCabinet/wiki/Community-Patch(TPS)");
        }

        string[] files;

        private void BtnPatchGame_DragDrop(object sender, DragEventArgs e)
        {
            if (files.Length == 1)
            {
                PatchExe(files[0]);
            }
            else
                MessageBox.Show("Too many files dropped. Drop me Borderlands2.exe only");
        }

        private void BtnPatchGame_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;
            files = (string[])e.Data.GetData(DataFormats.FileDrop);
        }

        private void ComboBoxGameSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChechGame();
        }

        private void ChechGame()
        {
            if (ComboBoxGameSelection.Text == "Borderlands 2")
            {
                isBorderlands2 = true;
                BtnPatchGame.Text = "Patch Borderlands2.exe";
                pathGame.Text = b2il;
                if (!String.IsNullOrEmpty(pathGame.Text))
                    pathExe.Text = b2il + "\\Binaries\\Win32\\Borderlands2.exe";
                else
                    pathExe.Text = String.Empty;
            }
            else
            {
                isBorderlands2 = false;
                BtnPatchGame.Text = "Patch BorderlandsPreSequel.exe";
                pathGame.Text = btpsil;
                if (!String.IsNullOrEmpty(pathGame.Text))
                    pathExe.Text = btpsil + "\\Binaries\\Win32\\BorderlandsPreSequel.exe";
                else
                    pathExe.Text = String.Empty;
            }
        }

        private void LblCommunityMods_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LblCommunityMods.LinkVisited = true;
            System.Diagnostics.Process.Start("https://github.com/BLCM/ModCabinet/wiki");
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void pathGameEdit_Click(object sender, EventArgs e)
        {
            //TODO
            string path = AskForInstallLocation(folderBrowserDialog1, isBorderlands2);
            if (isBorderlands2)
                b2il = path;
            else
                btpsil = path;
            ChechGame();
        }

        private void lblGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lblGithub.LinkVisited = true;
            System.Diagnostics.Process.Start("https://github.com/BLCM/BLCMods");
        }

        private void lblNMBL2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lblNMBL2.LinkVisited = true;
            System.Diagnostics.Process.Start("https://www.nexusmods.com/borderlands2");
        }

        private void buttonPathDetect_Click(object sender, EventArgs e)
        {
            FindBL2Steam();
            FindTPSSteam();
            ChechGame();
        }

        private void pathExeEdit_Click(object sender, EventArgs e)
        {
            string path = String.Empty;
            if (isBorderlands2)
                path = AskForExeLocation(openFileDialog1, b2il);
            else
                path = AskForExeLocation(openFileDialog1, btpsil);
            if (!String.IsNullOrEmpty(path))
                pathExe.Text = path;
        }
    }
}
