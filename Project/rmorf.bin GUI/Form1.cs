using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;

namespace rmorf.bin_GUI
{
    public partial class Form1 : Form
    {
        byte[] consts = {
            0x00, 0x00, 0x00, 0x00,
            0xCD, 0xCC, 0xCC, 0x3D,
            0x01, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00,
            0x80, 0x00, 0x00, 0x00,
        };

        byte[] unknown2 = {
            0x00, 0x00, 0x01, 0x00,
            0x00, 0x00, 0x01, 0x00,
            0x00, 0x00, 0x01, 0x00,
            0x00, 0x00
        };

        byte[] Point = { 0x2E };
        byte[] Null = { 0x00 };
        byte[] FW = { 0xE8, 0x03 };
        byte[] FF = { 0xA0, 0x00 };
        byte[] FT = { 0xFF, 0x00 };
        byte[] FC = { 0xE8, 0x03 };
        byte[] tree = { 0x2D, 0x01 };

        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Mafia rmorf.bin file(*.bin)|*.bin|All Files(*.*)|*.*";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Powered by Smelson and Legion, (C) 2020. All rights reserved.", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void createAFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel) { return; }
            String filepath = folderBrowserDialog1.SelectedPath;
            FileStream fs = File.Create(filepath + "\\rmorf.bin");
            MessageBox.Show("Clear file was created!", "Create A File", MessageBoxButtons.OK, MessageBoxIcon.Information);
            fs.Close();
            FileStream fs2 = File.Create(filepath + "\\rmorf.bin");
        UserChoice:
            string user_choice = Interaction.InputBox(
                "What kind of preset do you want to choice?\nw - water, t - trees, f - flags or c - clothes:",
                "Insert Preset"
                );
            switch (user_choice)
            {
                case "w":
                    fs2.Write(consts, 0, consts.Length);
                    fs2.Write(FW, 0, FW.Length);
                    fs2.Write(unknown2, 0, unknown2.Length);
                    break;
                case "t":
                    fs2.Write(consts, 0, consts.Length);
                    fs2.Write(FT, 0, FT.Length);
                    fs2.Write(unknown2, 0, unknown2.Length);
                    fs2.Seek(16, SeekOrigin.Begin);
                    fs2.Write(Null, 0, 1);
                    fs2.Write(Null, 0, 1);
                    fs2.Seek(24, SeekOrigin.Begin);
                    fs2.Write(tree, 0, tree.Length);
                    fs2.Write(unknown2, 0, 10);
                    break;
                case "f":
                    fs2.Write(consts, 0, consts.Length);
                    fs2.Write(FF, 0, FF.Length);
                    fs2.Write(unknown2, 0, unknown2.Length);
                    break;
                case "c":
                    fs2.Write(consts, 0, consts.Length);
                    fs2.Write(FC, 0, FC.Length);
                    fs2.Write(unknown2, 0, unknown2.Length);
                    break;
                default:
                    goto UserChoice;
            }

            int i = 0;
            string num = Interaction.InputBox(
                "Count of objects:",
                "Insert Presets"
            );

            int value = Convert.ToInt32(num);
            textBox1.Text = "Count of objects:" + num;

            while (i < value)
            {
                i++;

                string objname, meshname;
                objname = Interaction.InputBox(
                   "Write name of object in scene2.bin: ",
                   "Insert Presets"
                );

                meshname = Interaction.InputBox(
                   "Type name of objects layer with anim (it has MRPH parameter in Boz4ds): ",
                   "Insert Presets"
                );

                byte[] objname_arr = Encoding.Default.GetBytes(objname);
                fs2.Write(objname_arr, 0, objname_arr.Length);
                fs2.Write(Point, 0, Point.Length);

                byte[] meshname_arr = Encoding.Default.GetBytes(meshname);
                fs2.Write(meshname_arr, 0, meshname_arr.Length);
                fs2.Write(Null, 0, Null.Length);
            }

            // Writing count of objects on 12th offset
            byte[] intBytes = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(intBytes);
            byte[] result = intBytes;
            fs2.Seek(9, SeekOrigin.Begin);
            fs2.Write(result, 0, 4);

            // Writing size of file on file's start and save it
            fs2.Seek(0, SeekOrigin.End);
            fs2.Write(Null, 0, 1);
            fs2.Seek(0, SeekOrigin.Begin);
            System.IO.FileInfo file = new System.IO.FileInfo(filepath + "\\rmorf.bin");
            long size = file.Length;
            byte[] sizeout = BitConverter.GetBytes(size);
            fs2.Write(sizeout, 0, 4);
            fs2.Close();

            MessageBox.Show("DONE BLYAD!");
        }

        private void presetToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}