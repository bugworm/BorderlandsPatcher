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
using LibGit2Sharp;
using LibGit2Sharp.Handlers;

namespace Borderlands2Patcher
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            updateAll();
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
                openFileDialog1.Filter = "Executable files (.exe)|*.exe|All Files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;
                result = openFileDialog1.ShowDialog();
            }
            if (result == DialogResult.OK)
            {
                PatchExe(openFileDialog1.FileName);
            }
        }

        private void PatchExe(string file)
        {
            if (file.EndsWith("Borderlands2.exe") || file.EndsWith("borderlands2.exe"))
            {
                try
                {
                    File.Copy(file, file + ".bk", false);
                }
                catch (IOException)
                {
                    MessageBox.Show("You already have a backup. Skipping.");
                }
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
            else MessageBox.Show("Incorrect filename. I will only patch Borderlands2.exe or borderlands2.exe files");
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

        /*private void button4_Click(object sender, EventArgs e)
        {
            try
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
            catch (System.Net.WebException)
            {
                MessageBox.Show("Looks like you doesn't have internet connetcion. I can't download patch for you, sorry. I will redirect you to patch location, download it manually and place it in ...\\Borderlands 2\\Binaries directory.");
                System.Diagnostics.Process.Start("https://raw.githubusercontent.com/AnotherBugworm/Borderlands2Patcher/master/Patch/Patch.txt");
            }
        }*/

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

        string repoURL = "https://github.com/BL2CP/community-custom-weapons.git";
        string repoPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Community Patch";

        private void cloneRepo()
        {
            Repository.Clone(repoURL, repoPath);
        }
        
        private void gitpull()
        {
            using (var repo = new Repository(repoPath))
            {
                LibGit2Sharp.PullOptions options = new LibGit2Sharp.PullOptions();
                options.FetchOptions = new FetchOptions();
                Signature signature = new Signature("BorderlandsPatcher", "bugworm@zoho.com", new DateTimeOffset(DateTime.Now));
                repo.Network.Pull(signature, options);
            }
        }

        private bool checkFiles(string filepath1, string filepath2)
        {
            using (var reader1 = new System.IO.FileStream(filepath1, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                using (var reader2 = new System.IO.FileStream(filepath2, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    byte[] hash1;
                    byte[] hash2;

                    using (var md51 = new System.Security.Cryptography.MD5CryptoServiceProvider())
                    {
                        md51.ComputeHash(reader1);
                        hash1 = md51.Hash;
                    }

                    using (var md52 = new System.Security.Cryptography.MD5CryptoServiceProvider())
                    {
                        md52.ComputeHash(reader2);
                        hash2 = md52.Hash;
                    }

                    int j = 0;
                    for (j = 0; j < hash1.Length; j++)
                    {
                        if (hash1[j] != hash2[j])
                        {
                            break;
                        }
                    }

                    if (j == hash1.Length)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        List<string> paths = new List<string> { };

        private void updateAll()
        {
            try
            {
                cloneRepo();
            }
            catch (NameConflictException)
            {
                gitpull();
            }
            string bindir = InstallLocation.GetValue("InstallLocation") as string;
            bindir += "\\Binaries";
            string[] files = Directory.GetFiles(bindir);
            int i = 0;
            using (var repo = new Repository(repoPath))
            {
                foreach (IndexEntry ie in repo.Index)
                {
                    string[] tmp = ie.Path.ToString().Split('\\');
                    string name = tmp[tmp.Length - 1];
                    string[] row = new string[4] { name, "None", "Not Installed", "Install" };
                    paths.Add(ie.Path);
                    if (ie.StageLevel == 0 && ie.Path.ToString().StartsWith("Borderlands 2"))
                    {
                        //for (int i = 0; i < files.Length; i++)
                        foreach (string patch in files)
                        {
                            string[] tmp2 = patch.Split('\\');
                            if (tmp2[tmp2.Length - 1].Equals(name))
                            {
                                if (checkFiles(repoPath + "\\" + ie.Path.ToString(), patch))
                                {
                                    row[2] = "Updated";
                                    row[3] = "No actions";
                                }
                                else
                                {
                                    row[2] = "Out to Date";
                                    row[3] = "Update";
                                }
                            }
                        }
                        dataGridView1.Rows.Add(row);
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[3];
                if(cell.Value.ToString().Equals("Update") || cell.Value.ToString().Equals("Install"))
                {
                    string path = InstallLocation.GetValue("InstallLocation") as string;
                    string[] tmp = paths[e.RowIndex].Split('\\');
                    File.Copy(repoPath + "\\" + paths[e.RowIndex], path + "\\Binaries\\" + tmp[tmp.Length - 1],true);
                    dataGridView1.Rows[e.RowIndex].Cells[2].Value = "Updated";
                    dataGridView1.Rows[e.RowIndex].Cells[3].Value = "No actions";
                }
            }
        }
    }
}