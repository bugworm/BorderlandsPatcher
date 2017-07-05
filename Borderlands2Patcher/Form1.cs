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

namespace Borderlands2Patcher
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
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

        static RegistryKey b2il = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Steam App 49520");
        static RegistryKey btpsil = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Steam App 261640");
        RegistryKey InstallLocation = b2il;
        bool isBorderlands2 = true;

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = new DialogResult();
            try
            {
                string path = InstallLocation.GetValue("InstallLocation") as string;
                if (isBorderlands2)
                {
                    openFileDialog1.FileName = path + "\\Binaries\\Win32\\Borderlands2.exe";
                }
                else
                {
                    openFileDialog1.FileName = path + "\\Binaries\\Win32\\BorderlandsPreSequel.exe";
                }
                result = DialogResult.OK;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Cannot detect your game path. Please select Borderlands2(PreSequel).exe file. It's usually on ...\\Steam(Library)\\steamapps\\common\\Borderlands 2(PreSequel)\\Binaries\\Win32 directory.");
                openFileDialog1.Filter = "Executable files (.exe)|*.exe|All Files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;
                result = openFileDialog1.ShowDialog();
            }
            if (result == DialogResult.OK)
            {
                PatchExe(openFileDialog1.FileName);
            }
            else MessageBox.Show("Did you select the file? I can't patch the air");
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

        private void button2_Click(object sender, EventArgs e)
        {
            string tmppath;
            if(isBorderlands2)
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
            MessageBox.Show("To use Community Patch you need to patch your Borderlands2(PreSequel).exe (it will backup original file, don't worry), add console hotkey if you doesn't have one and place patch file(patch.txt) to Binaries directory. Program will find your game path and download latest patch automaticly, if won't find it, you still can choose path manually. Then launch your game, open console, type \"exec patch.txt\" and press enter. Do it after game downloads all stuff(when you see actual menu). That's all, you can now enjoy patch! It will work only for current session, you need to enter console command every time you launch the game. You can press \"Arrow Up\" to show your last typed command on console.");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("https://youtu.be/o_ee3BM1TQQ");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string[] content, contentOffline;
                if (isBorderlands2)
                {
                    content = getTextFile(@"https://raw.githubusercontent.com/BLCM/BLCMods/master/Borderlands%202%20mods/Shadowevil/Patch.txt");
                    contentOffline = getTextFile(@"https://raw.githubusercontent.com/BLCM/BLCMods/master/Borderlands%202%20mods/Shadowevil/PatchOffline.txt");
                }
                else
                {
                    content = getTextFile(@"https://raw.githubusercontent.com/BLCM/BLCMods/master/Pre%20Sequel%20Mods/Community%20Patch/CommunityPatch");
                    contentOffline = getTextFile(@"https://raw.githubusercontent.com/BLCM/BLCMods/master/Pre%20Sequel%20Mods/Community%20Patch/OfflineCommunityPatch");
                } 
            try
            {
                string path = InstallLocation.GetValue("InstallLocation") as string;
                File.WriteAllLines(path + "\\Binaries\\Patch.txt", content);
                File.WriteAllLines(path + "\\Binaries\\PatchOffline.txt", contentOffline);
                MessageBox.Show("Done!");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Cannot detect your game path. Choose your Binaries directory. It's usually on ...\\Steam(Library)\\steamapps\\common\\Borderlands 2(PreSequel)\\Binaries");
                DialogResult result = new DialogResult();
                result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string path = folderBrowserDialog1.SelectedPath;
                    File.WriteAllLines(path + "\\Patch.txt", content);
                    File.WriteAllLines(path + "\\PatchOffline.txt", contentOffline);
                    MessageBox.Show("Done!");
                }
            }
                }
            catch (System.Net.WebException)
            {
                MessageBox.Show("Looks like you doesn't have internet connetcion. I can't download patch for you, sorry. I will redirect you to patch location, download it manually and place it in ...\\Borderlands 2(PreSequel)\\Binaries directory.");
                System.Diagnostics.Process.Start("https://raw.githubusercontent.com/AnotherBugworm/Borderlands2Patcher/master/Patch/Patch.txt");
            }
        }

        string[] files;

        private void button1_DragDrop(object sender, DragEventArgs e)
        {
            if (files.Length == 1)
            {
                PatchExe(files[0]);
            }
            else MessageBox.Show("Too many files dropped. Drop me Borderlands2.exe only");
        }

        private void button1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;
            files = (string[])e.Data.GetData(DataFormats.FileDrop);
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text == "Borderlands 2")
            {
                isBorderlands2 = true;
                button1.Text = "Patch Borderlands2.exe";
                InstallLocation = b2il;
            }
            else
            {
                isBorderlands2 = false;
                button1.Text = "Patch BorderlandsPreSequel.exe";
                InstallLocation = btpsil;
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel2.LinkVisited = true;
            System.Diagnostics.Process.Start("https://github.com/BLCM/BLCMods");
        }
    }
}