using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;

namespace rmorf.bin_GUI
{
    struct RmorfHead
    {
        public ulong fileSize;
        public ulong key;
        public ulong animGroupCcount;

        public RmorfHead(ulong fs, ulong k, ulong agc)
        {
            fileSize = fs;
            key = k;
            animGroupCcount = agc;
        }
    }

    struct RmorfGroup
    {
        public uint morfCount;
        public uint typeofanim1;
        public uint frequency;
        public uint unknown3;
        public uint unknown4;
        public uint unknown5;
        public List<string> objNames;
        public byte nullb;

        public RmorfGroup(uint mc, uint toa, uint frq, uint u3, uint u4, uint u5, List<string> objn)
        {
            morfCount = mc;
            typeofanim1 = toa;
            frequency = frq;
            unknown3 = u3;
            unknown4 = u4;
            unknown5 = u5;
            objNames = objn;
            nullb = 0x00;
        }
    }

    public partial class Form1 : Form
    {
        RmorfHead rmorfhead;
        List<RmorfGroup> rmorfgrouplist;

        byte[] fS = { 0x00, 0x00, 0x00, 0x00 };
        byte[] k = { 0xCD, 0xCC, 0xCC, 0x3D };
        byte[] agc = { 0x00, 0x00, 0x00, 0x00 };

        byte[] NendofFile = { 0x00, 0x00, 0x00 };

        private string filepath;
        private uint headFs;
        private uint headKey;
        private uint headAgc;
        private uint grMc;
        private uint grToa;
        private uint grFrq;
        private uint grU3;
        private uint grU4;
        private uint grU5;
        private List<string> nameslist;

        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Mafia rmorf.bin file(*.bin)|*.bin|All Files(*.*)|*.*";
        }
        
        private void createAFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFile();
        }
        
        private void openAFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                ParseFile();
                Objects1.Items.Clear();
                VisualGroup();
            }
        }
        
        private void Objects_SelectedIndexChanged(object sender, EventArgs e)
        {
            VisualObject(Objects.SelectedIndex);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void Objects_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(MousePosition, ToolStripDropDownDirection.Right);
            }
        }

        private void Objects1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip2.Show(MousePosition, ToolStripDropDownDirection.Right);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int a = Objects.SelectedIndex;
            int i = Objects1.SelectedIndex;
            if (rmorfgrouplist != null && i >= 0 && a >= 0)
            {
                string newname = Interaction.InputBox("Type new name of object:", "Renaming", Objects1.SelectedItem.ToString());
                if (newname == "")
                    MessageBox.Show("You didn't write new name", "Renaming", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    rmorfgrouplist[a].objNames[i] = newname;
                    VisualObject(a);
                    FilesaveString(false);
                }
            }
        }

        private void DeleteObjToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int a = Objects.SelectedIndex;
            int i = Objects1.SelectedIndex;
            if (rmorfgrouplist != null && i >= 0 && a >= 0)
            {
                nameslist = rmorfgrouplist[a].objNames;
                nameslist.RemoveAt(i);
                GetValues(a);
                rmorfgrouplist[a] = new RmorfGroup(grMc, grToa, grFrq, grU3, grU4, grU5, nameslist);
                VisualObject(a);
                FilesaveString(false);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = Objects.SelectedIndex;
            if (rmorfgrouplist != null && i >= 0)
            {
                rmorfgrouplist.RemoveAt(i);
                headAgc = (uint)rmorfgrouplist.Count;
                VisualGroup();
                Objects1.Items.Clear();
                FilesaveString(false);
            }
        }

        private void InsertGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rmorfgrouplist != null)
            {
                rmorfgrouplist.Add(new RmorfGroup(0, 0, 0, 0, 0, 0, new List<string>()));
                headAgc = (uint)rmorfgrouplist.Count;
                VisualGroup();
                Objects1.Items.Clear();
                FilesaveString(false);
            }
        }

        private void InsertObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int a = Objects.SelectedIndex;
            if (rmorfgrouplist != null && a >= 0)
            {
                string newname = Interaction.InputBox("Type a new object name:", "Adding", "NewObject");
                if (newname == "")
                    MessageBox.Show("You didn't write new name", "Adding", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    nameslist = rmorfgrouplist[a].objNames;
                    nameslist.Add(newname);
                    GetValues(a);
                    rmorfgrouplist[a] = new RmorfGroup(grMc, grToa, grFrq, grU3, grU4, grU5, nameslist);
                    VisualObject(a);
                    FilesaveString(false);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Rmorf.bin Editor v1.0.\nAuthors: Smelson, Legion, Firefox3860.\n(c) 2020. From Russia with love.", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            Apply();
        }

        private void CreateFile()
        {
            try
            {
                if (folderBrowserDialog1.ShowDialog() != DialogResult.Cancel)
                {
                    filepath = folderBrowserDialog1.SelectedPath + "\\rmorf.bin";
                    FileStream fileStream = new FileStream(filepath, FileMode.Create);
                    BinaryWriter writer = new BinaryWriter(fileStream);

                    headFs = (uint)BitConverter.ToInt32(fS, 0);
                    headKey = (uint)BitConverter.ToInt32(k, 0);
                    headAgc = (uint)BitConverter.ToInt32(agc, 0);
                    rmorfhead = new RmorfHead(headFs, headKey, headAgc);
                    rmorfgrouplist = new List<RmorfGroup>();

                    writer.Write(headFs);
                    writer.Write(headKey);
                    writer.Write(headAgc);

                    try
                    {
                        // Writing size of file on its begin and save it
                        writer.Seek(0, SeekOrigin.End);
                        writer.Write(NendofFile);
                        writer.Seek(0, SeekOrigin.Begin);

                        FileInfo file = new FileInfo(filepath);
                        long size = file.Length;
                        byte[] sizeout = BitConverter.GetBytes(size);
                        writer.Write(sizeout, 0, 4);

                        writer.Close();
                        fileStream.Close();
                        //MessageBox.Show("DONE BLYAD!");

                        VisualGroup();
                        Objects1.Items.Clear();
                        FilesaveString(false);
                        FilesaveString(true);
                    }

                    catch (FormatException)
                    {
                        MessageBox.Show("Wrong type of data!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            catch
            {
                MessageBox.Show("Wrong path!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ParseFile()
        {
            rmorfgrouplist = new List<RmorfGroup>();
            filepath = openFileDialog1.FileName;
            labelFilepath.Text = filepath;
            try
            {
                FileStream fileStream = new FileStream(filepath, FileMode.Open);
                BinaryReader reader = new BinaryReader(fileStream);
                headFs = reader.ReadUInt32();
                headKey = reader.ReadUInt32();

                if (headKey == 1036831949)
                {
                    try
                    {
                        headAgc = reader.ReadUInt32();
                        rmorfhead = new RmorfHead(headFs, headKey, headAgc);

                        for (int animgr = 0; animgr < headAgc; animgr++)
                        {
                            nameslist = new List<string>();
                            grMc = reader.ReadUInt32();
                            grToa = reader.ReadUInt32();
                            grFrq = reader.ReadUInt32();
                            grU3 = reader.ReadUInt32();
                            grU4 = reader.ReadUInt32();
                            grU5 = reader.ReadUInt32();

                            for (uint i = 0; i < grMc; i++)
                            {
                                List<byte> listname = new List<byte>();
                                byte[] arrname;
                                while (reader.PeekChar() != '\x00')
                                    listname.Add(reader.ReadByte());

                                arrname = listname.ToArray();
                                reader.BaseStream.Seek(+1, SeekOrigin.Current);
                                string name = Encoding.ASCII.GetString(arrname);
                                nameslist.Add(name);
                            }
                            rmorfgrouplist.Add(new RmorfGroup(grMc, grToa, grFrq, grU3, grU4, grU5, nameslist));
                        }
                    }
                    catch
                    { MessageBox.Show("File is wrong!. Couldn't parse.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                    MessageBox.Show("File is wrong!. Wrong constant.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                reader.Close();
                fileStream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveFile()
        {
            try
            {
                FileStream fileStream = new FileStream(filepath, FileMode.Create);
                BinaryWriter writer = new BinaryWriter(fileStream);
                writer.Write(headFs);
                writer.Write(headKey);
                writer.Write(headAgc);
                for (int a = 0; a < rmorfgrouplist.Count; a++)
                {
                    writer.Write(rmorfgrouplist[a].morfCount);
                    writer.Write(rmorfgrouplist[a].typeofanim1);
                    writer.Write(rmorfgrouplist[a].frequency);
                    writer.Write(rmorfgrouplist[a].unknown3);
                    writer.Write(rmorfgrouplist[a].unknown4);
                    writer.Write(rmorfgrouplist[a].unknown5);

                    for (int i = 0; i < rmorfgrouplist[a].objNames.Count; i++)
                    {
                        string name = rmorfgrouplist[a].objNames[i];
                        byte[] arrname = Encoding.ASCII.GetBytes(name);
                        writer.Write(arrname);
                        writer.Write(rmorfgrouplist[a].nullb);
                    }
                }

                writer.Seek(0, SeekOrigin.End);
                writer.Write(NendofFile);
                writer.Seek(0, SeekOrigin.Begin);

                FileInfo file = new FileInfo(filepath);
                long size = file.Length;
                byte[] sizeout = BitConverter.GetBytes(size);
                writer.Write(sizeout, 0, 4);
                writer.Close();
                fileStream.Close();

                //MessageBox.Show("DONE BLYAD!");
                FilesaveString(true);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetValues(int a)
        {
            grMc = (uint)nameslist.Count;
            grToa = rmorfgrouplist[a].typeofanim1;
            grFrq = rmorfgrouplist[a].frequency;
            grU3 = rmorfgrouplist[a].unknown3;
            grU4 = rmorfgrouplist[a].unknown4;
            grU5 = rmorfgrouplist[a].unknown5;
        }

        private void Apply()
        {
            int a = Objects.SelectedIndex;
            if (a >= 0)
                try
                {
                    grMc = (uint)rmorfgrouplist[a].objNames.Count;
                    grToa = uint.Parse(textBox2.Text);
                    grFrq = uint.Parse(textBox3.Text);
                    grU3 = uint.Parse(textBox4.Text);
                    grU4 = uint.Parse(textBox5.Text);
                    grU5 = uint.Parse(textBox6.Text);
                    nameslist = rmorfgrouplist[a].objNames;
                    rmorfgrouplist[a] = new RmorfGroup(grMc, grToa, grFrq, grU3, grU4, grU5, nameslist);
                    FilesaveString(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void FilesaveString(bool c)
        {
            if (c)
            {
                if (!labelFilepath.Text.Contains(" - File was saved."))
                    labelFilepath.Text += " - File was saved.";
                Interaction.Beep();
            }
            else
                labelFilepath.Text = filepath.ToString();
        }

        private void VisualGroup()
        {
            Objects.Items.Clear();

            if (rmorfgrouplist != null)
                for (int a = 0; a < rmorfgrouplist.Count; a++)
                    Objects.Items.Add((a + 1).ToString());

            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
        }

        private void VisualObject(int ngr)
        {
            Objects1.Items.Clear();

            if (ngr >= 0 && rmorfgrouplist[ngr].objNames != null)
            {
                for (int i = 0; i < rmorfgrouplist[ngr].objNames.Count; i++)
                    Objects1.Items.Add(rmorfgrouplist[ngr].objNames[i]);

                textBox1.Text = rmorfgrouplist[ngr].morfCount.ToString();
                textBox2.Text = rmorfgrouplist[ngr].typeofanim1.ToString();
                textBox3.Text = rmorfgrouplist[ngr].frequency.ToString();
                textBox4.Text = rmorfgrouplist[ngr].unknown3.ToString();
                textBox5.Text = rmorfgrouplist[ngr].unknown4.ToString();
                textBox6.Text = rmorfgrouplist[ngr].unknown5.ToString();
            }
        }
    }
}