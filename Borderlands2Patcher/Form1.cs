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
            string[] version = getTextFile(@"https://raw.githubusercontent.com/AnotherBugworm/Borderlands2Patcher/master/Patch/Version.txt");
            label1.Text += version[0];
        }

        public string[] getTextFile(string url)
        {
            var file = GetFileViaHttp(url);
            string str = Encoding.UTF8.GetString(file);
            string[] content = str.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            return content;
        }
        
        RegistryKey InstallLocation = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Steam App 49520");

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = new DialogResult();
            try
            {
                string path = InstallLocation.GetValue("InstallLocation") as string;
                openFileDialog1.FileName = path + "\\Binaries\\Win32\\Borderlands2.exe";
                result = DialogResult.OK;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Cannot detect your game path. Please select Borderlands2.exe file. It's usually on ...\\Steam(Library)\\steamapps\\common\\Borderlands 2\\Binaries\\Win32 directory.");
                openFileDialog1.InitialDirectory = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Borderlands 2\\Binaries\\Win32";
                openFileDialog1.Filter = "Executable files (.exe)|*.exe|All Files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;
                result = openFileDialog1.ShowDialog();
            }
            if (result == DialogResult.OK)
            {
                try
                {
                    File.Copy(openFileDialog1.FileName, openFileDialog1.FileName + ".bk", false);
                }
                catch (IOException)
                {
                    MessageBox.Show("You already have a backup. Skipping.");
                }
                var stream = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.ReadWrite);
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\my games\\borderlands 2\\willowgame\\Config\\WillowInput.ini";
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
            MessageBox.Show("To use Community Patch you need to patch your borderlands2.exe (it will backup original file, don't worry), add console hotkey if you doesn't have one and place patch file(patch.txt) to Binaries directory. Program will find your game path and download latest patch automaticly, if won't find it, you still can choose path manually. Then launch your game, open console, type \"exec patch.txt\" and press enter. Do it after game downloads all stuff(when you see actual menu). That's all, you can now enjoy patch! It will work only for current session, you need to enter console command every time you launch the game. You can press \"Arrow Up\" to show your last typed command on console.");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("https://youtu.be/o_ee3BM1TQQ");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel2.LinkVisited = true;
            System.Diagnostics.Process.Start("https://github.com/AnotherBugworm/Borderlands2Patcher/blob/master/Patch/Patch%20Notes.txt");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string[] content = getTextFile(@"https://raw.githubusercontent.com/AnotherBugworm/Borderlands2Patcher/master/Patch/Patch.txt");
            try
            {
                string path = InstallLocation.GetValue("InstallLocation") as string;
                File.WriteAllLines(path + "\\Binaries\\patch.txt", content);
                MessageBox.Show("Done!");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Cannot detect your game path. Choose your Binaries directory. It's usually on ...\\Steam(Library)\\steamapps\\common\\Borderlands 2\\Binaries");
                DialogResult result = new DialogResult();
                result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string path = folderBrowserDialog1.SelectedPath;
                    File.WriteAllLines(path + "\\patch.txt", content);
                    MessageBox.Show("Done!");
                }
            }
        }

        public byte[] GetFileViaHttp(string url)
        {
            using (WebClient client = new WebClient())
            {
                return client.DownloadData(url);
            }
        }

    }
}