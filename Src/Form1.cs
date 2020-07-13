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
        int value;

        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Mafia rmorf.bin file(*.bin)|*.bin";

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Powered by Smelson and Legion, (C) 2020. All rights reserved.", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void createAFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

            againblyad3:
            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel) { return; }
                string filepath = folderBrowserDialog1.SelectedPath;
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
                        MessageBox.Show("Invalid preset!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        goto UserChoice;
                }

                int i = 0;

            againblyad:
                try
                {
                    string num = Interaction.InputBox(
                    "Count of objects:",
                    "Insert Presets"
                    );
                    value = Convert.ToInt32(num);
                    textBox1.Text = "Count of objects:" + value;

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

                catch (FormatException)
                {
                    MessageBox.Show("Invalid type of data BLYAD!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    goto againblyad;
                }
            }

            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Directory shouldn't have cyrillic symbols, BLYAD!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                goto againblyad3;
            }
        }

        private void addObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) { return; }
            string filepath = openFileDialog1.FileName;
            byte[] addobj = File.ReadAllBytes(filepath);
            FileStream valobjfile = File.Open(filepath, FileMode.Open, FileAccess.Read);
            valobjfile.Seek(12, SeekOrigin.Begin);
            int valobj = valobjfile.ReadByte();
            valobjfile.Close();
            FileStream temporary = File.Create("temporary.txt");
            temporary.Write(addobj, 0, addobj.Length-1);

            int i = 0;

            againblyad2:
            try
            {
                string num = Interaction.InputBox(
                 "Count of objects:",
                 "Add object"
                 );
                int value2 = Convert.ToInt32(num);

                while (i < value2)
                {
                    i++;

                    string objname, meshname;
                    objname = Interaction.InputBox(
                       "Write name of object in scene2.bin: ",
                       "Add object"
                    );

                    meshname = Interaction.InputBox(
                       "Type name of objects layer with anim (it has MRPH parameter in Boz4ds): ",
                       "Add object"
                    );

                    byte[] objname_arr = Encoding.Default.GetBytes(objname);
                    temporary.Write(objname_arr, 0, objname_arr.Length);
                    temporary.Write(Point, 0, Point.Length);

                    byte[] meshname_arr = Encoding.Default.GetBytes(meshname);
                    temporary.Write(meshname_arr, 0, meshname_arr.Length);
                    temporary.Write(Null, 0, Null.Length);
                }
                temporary.Write(Null, 0, 1);
                temporary.Close();
                FileStream temporaryread = File.Open("temporary.txt", FileMode.Open);
                temporaryread.Close();
                byte[] addobj2 = File.ReadAllBytes("temporary.txt");
                FileStream fs2 = File.Create(filepath);
                fs2.Write(addobj2, 0, addobj2.Length);

                // Writing count of objects on 12th offset
                int valueresult = valobj + value2;
                byte[] intBytes = BitConverter.GetBytes(valueresult);
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(intBytes);
                byte[] result = intBytes;
                fs2.Seek(9, SeekOrigin.Begin);
                fs2.Write(result, 0, 4);
                textBox1.Text = "Count of objects:" + valueresult;

                // Writing size of file on file's start and save it
                fs2.Seek(0, SeekOrigin.Begin);
                System.IO.FileInfo file = new System.IO.FileInfo(filepath);
                long size = file.Length;
                byte[] sizeout = BitConverter.GetBytes(size);
                fs2.Write(sizeout, 0, 4);
                fs2.Close();
                File.Delete("temporary.txt");
                MessageBox.Show("DONE BLYAD!");
            }

            catch (FormatException)
            {
               MessageBox.Show("Invalid type of data BLYAD!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
               goto againblyad2;
            }
        }
    }
}