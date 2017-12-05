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
            // get install path of Borderlands 2
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 49520"))
            {
                if (key != null)
                {
                    b2il = key.GetValue("InstallLocation") as string;
                }
                // else key could not be found
            }

            // get install path of Borderlands The PreSequel
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 261640"))
            {
                if (key != null)
                {
                    btpsil = key.GetValue("InstallLocation") as string;
                }
                // else key could not be found
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filepath;
            try
            {
                if (isBorderlands2)
                {
                    // if we don't know the install location
                    if (String.IsNullOrEmpty(b2il))
                    {
                        b2il = AskForInstallLocation(folderBrowserDialog1, isBorderlands2);
                    }

                    filepath = b2il + "\\Binaries\\Win32\\Borderlands2.exe";
                }
                else
                {
                    // if we don't know the install location
                    if (String.IsNullOrEmpty(btpsil))
                    {
                        btpsil = AskForInstallLocation(folderBrowserDialog1, isBorderlands2);
                    }

                    filepath = btpsil + "\\Binaries\\Win32\\BorderlandsPreSequel.exe";
                }

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
            if (isBorderlands2)
            {
                var stream = new FileStream(file, FileMode.Open, FileAccess.ReadWrite);
                stream.Position = 0x004F2590;
                stream.WriteByte(0xff);
                for (long i = 0x01B94B0C; i <= 0x01B94B10; i++)
                {
                    stream.Position = i;
                    stream.WriteByte(0x00);
                }
                stream.Close();
                MessageBox.Show("Done!");
            }
            else
            {
                var stream = new FileStream(file, FileMode.Open, FileAccess.ReadWrite);
                stream.Position = 0x00D8BD1F;
                stream.WriteByte(0xff);
                for (long i = 0x01982A00; i <= 0x01982A05; i++)
                {
                    stream.Position = i;
                    stream.WriteByte(0x00);
                }
                stream.Close();
                MessageBox.Show("Done!");
            }
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

        private void button2_Click(object sender, EventArgs e)
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
            temp[i] = "ConsoleKey=" + textBox1.Text;
            File.WriteAllLines(path, temp);
            MessageBox.Show("Done!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To use Community Patch you need to patch your Borderlands2(PreSequel).exe (it will backup original file, don't worry), add console hotkey if you doesn't have one and place patch file(Patch.txt and PatchOffline.txt) to Binaries directory. Program will find your game path and download latest patch automaticly, if won't find it, you still can choose path manually. Then launch your game, open console, type \"exec Patch.txt\"(or PatchOffline.txt if you want to play offline) and press enter. Do it after game downloads all stuff(when you see actual menu). That's all, you can now enjoy patch! It will work only for current session, you need to enter console command every time you launch the game. You can press \"Arrow Up\" to show your last typed command on console.");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("https://youtu.be/o_ee3BM1TQQ");
        }

        private void button4_Click(object sender, EventArgs e)
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

                    content = getTextFile(@"https://raw.githubusercontent.com/BLCM/BLCMods/master/Borderlands%202%20mods/Shadowevil/Patch.txt");
                    contentOffline = getTextFile(@"https://raw.githubusercontent.com/BLCM/BLCMods/master/Borderlands%202%20mods/Shadowevil/PatchOffline.txt");
                }
                else
                {
                    // if we don't know the install location
                    if (String.IsNullOrEmpty(btpsil))
                    {
                        btpsil = AskForInstallLocation(folderBrowserDialog1, isBorderlands2);
                    }

                    path = btpsil;

                    content = getTextFile(@"https://raw.githubusercontent.com/BLCM/BLCMods/master/Pre%20Sequel%20Mods/Community%20Patch/Community%20Patch%202.0/Patch");
                }

                File.WriteAllLines(path + "\\Binaries\\Patch.txt", content);

                MessageBox.Show("Done!");
            }
            catch (System.Net.WebException)
            {
                MessageBox.Show("Looks like you doesn't have internet connetcion. I can't download patch for you, sorry. I will redirect you to patch location, download it manually and place it in ...\\Borderlands 2(PreSequel)\\Binaries directory.");
                System.Diagnostics.Process.Start("https://github.com/BLCM/BLCMods");
            }
        }

        string[] files;

        private void button1_DragDrop(object sender, DragEventArgs e)
        {
            if (files.Length == 1)
            {
                PatchExe(files[0]);
            }
            else
                MessageBox.Show("Too many files dropped. Drop me Borderlands2.exe only");
        }

        private void button1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;
            files = (string[])e.Data.GetData(DataFormats.FileDrop);
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Borderlands 2")
            {
                isBorderlands2 = true;
                button1.Text = "Patch Borderlands2.exe";
            }
            else
            {
                isBorderlands2 = false;
                button1.Text = "Patch BorderlandsPreSequel.exe";
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel2.LinkVisited = true;
            System.Diagnostics.Process.Start("https://github.com/BLCM/ModCabinet/wiki");
        }
    }
}
