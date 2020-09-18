namespace rmorf.bin_GUI
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.creaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createAFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openAFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InsertGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InsertObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sprvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Objects = new System.Windows.Forms.ListBox();
            this.labelFilepath = new System.Windows.Forms.Label();
            this.Objects1 = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.buttonApply = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DelGrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.renameObjToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteObjToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.creaToolStripMenuItem,
            this.insertToolStripMenuItem,
            this.sprvToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(634, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // creaToolStripMenuItem
            // 
            this.creaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createAFileToolStripMenuItem,
            this.openAFileToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.creaToolStripMenuItem.Name = "creaToolStripMenuItem";
            this.creaToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.creaToolStripMenuItem.Text = "File";
            // 
            // createAFileToolStripMenuItem
            // 
            this.createAFileToolStripMenuItem.Name = "createAFileToolStripMenuItem";
            this.createAFileToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.createAFileToolStripMenuItem.Text = "Create";
            this.createAFileToolStripMenuItem.Click += new System.EventHandler(this.createAFileToolStripMenuItem_Click);
            // 
            // openAFileToolStripMenuItem
            // 
            this.openAFileToolStripMenuItem.Name = "openAFileToolStripMenuItem";
            this.openAFileToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.openAFileToolStripMenuItem.Text = "Open";
            this.openAFileToolStripMenuItem.Click += new System.EventHandler(this.openAFileToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // insertToolStripMenuItem
            // 
            this.insertToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InsertGroupToolStripMenuItem,
            this.InsertObjectToolStripMenuItem});
            this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            this.insertToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.insertToolStripMenuItem.Text = "Insert";
            // 
            // InsertGroupToolStripMenuItem
            // 
            this.InsertGroupToolStripMenuItem.Name = "InsertGroupToolStripMenuItem";
            this.InsertGroupToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.InsertGroupToolStripMenuItem.Text = "Insert group";
            this.InsertGroupToolStripMenuItem.Click += new System.EventHandler(this.InsertGroupToolStripMenuItem_Click);
            // 
            // InsertObjectToolStripMenuItem
            // 
            this.InsertObjectToolStripMenuItem.Name = "InsertObjectToolStripMenuItem";
            this.InsertObjectToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.InsertObjectToolStripMenuItem.Text = "Insert object";
            this.InsertObjectToolStripMenuItem.Click += new System.EventHandler(this.InsertObjectToolStripMenuItem_Click);
            // 
            // sprvToolStripMenuItem
            // 
            this.sprvToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.sprvToolStripMenuItem.Name = "sprvToolStripMenuItem";
            this.sprvToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.sprvToolStripMenuItem.Text = "About";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.aboutToolStripMenuItem.Text = "Program";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "rmorf.bin";
            // 
            // Objects
            // 
            this.Objects.FormattingEnabled = true;
            this.Objects.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Objects.Location = new System.Drawing.Point(11, 50);
            this.Objects.Name = "Objects";
            this.Objects.Size = new System.Drawing.Size(150, 238);
            this.Objects.TabIndex = 1;
            this.Objects.SelectedIndexChanged += new System.EventHandler(this.Objects_SelectedIndexChanged);
            this.Objects.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Objects_MouseUp);
            // 
            // labelFilepath
            // 
            this.labelFilepath.AutoSize = true;
            this.labelFilepath.Location = new System.Drawing.Point(12, 293);
            this.labelFilepath.Name = "labelFilepath";
            this.labelFilepath.Size = new System.Drawing.Size(0, 13);
            this.labelFilepath.TabIndex = 2;
            // 
            // Objects1
            // 
            this.Objects1.FormattingEnabled = true;
            this.Objects1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Objects1.Location = new System.Drawing.Point(167, 50);
            this.Objects1.Name = "Objects1";
            this.Objects1.Size = new System.Drawing.Size(150, 238);
            this.Objects1.TabIndex = 3;
            this.Objects1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Objects1_MouseUp);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(494, 99);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(494, 125);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 5;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(494, 151);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 6;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(494, 177);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 7;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(494, 203);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 8;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(494, 229);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 20);
            this.textBox6.TabIndex = 9;
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(494, 265);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(100, 23);
            this.buttonApply.TabIndex = 10;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(346, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Count of objects:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(346, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Type of animation:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(346, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Frequency of animation:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(346, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Unkown parameter 1:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(346, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Unkown parameter 2:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(346, 232);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Unkown parameter 3:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Groups";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(168, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Objects";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DelGrToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 26);
            // 
            // DelGrToolStripMenuItem
            // 
            this.DelGrToolStripMenuItem.Name = "DelGrToolStripMenuItem";
            this.DelGrToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.DelGrToolStripMenuItem.Text = "Delete";
            this.DelGrToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renameObjToolStripMenuItem,
            this.DeleteObjToolStripMenuItem1});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(118, 48);
            // 
            // renameObjToolStripMenuItem
            // 
            this.renameObjToolStripMenuItem.Name = "renameObjToolStripMenuItem";
            this.renameObjToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.renameObjToolStripMenuItem.Text = "Rename";
            this.renameObjToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // DeleteObjToolStripMenuItem1
            // 
            this.DeleteObjToolStripMenuItem1.Name = "DeleteObjToolStripMenuItem1";
            this.DeleteObjToolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
            this.DeleteObjToolStripMenuItem1.Text = "Delete";
            this.DeleteObjToolStripMenuItem1.Click += new System.EventHandler(this.DeleteObjToolStripMenuItem1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Unknown/None",
            "Flag",
            "Flag (Parnik)",
            "Flag (Parnik) 2",
            "Flag (Racing Circuit)",
            "Tree",
            "Tree 2",
            "Tree 3",
            "Spruce",
            "Water/Curtain",
            "Water 2",
            "Clothes",
            "Clothes 2",
            "Clothes (Strong wind)",
            "Clothes (Strong wind) 2",
            "Signboard",
            "Signboard 2",
            "Truck (MISE09)"});
            this.comboBox1.Location = new System.Drawing.Point(349, 50);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(139, 21);
            this.comboBox1.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(346, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Preset";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(494, 49);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "Apply Preset";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(634, 312);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Objects1);
            this.Controls.Add(this.labelFilepath);
            this.Controls.Add(this.Objects);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(650, 350);
            this.MinimumSize = new System.Drawing.Size(650, 350);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rmorf.bin Editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem creaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createAFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sprvToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openAFileToolStripMenuItem;
        private System.Windows.Forms.ListBox Objects;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.Label labelFilepath;
        private System.Windows.Forms.ListBox Objects1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStripMenuItem InsertGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem InsertObjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem DelGrToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem renameObjToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteObjToolStripMenuItem1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
    }
}

