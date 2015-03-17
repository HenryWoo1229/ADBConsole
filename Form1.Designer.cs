namespace ADBConsole
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.ADBStartBtn = new System.Windows.Forms.Button();
            this.ADBClearBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbLevel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TagNameBox = new System.Windows.Forms.TextBox();
            this.TagEnable = new System.Windows.Forms.CheckBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.consoleBox = new System.Windows.Forms.RichTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TopEnable = new System.Windows.Forms.CheckBox();
            this.cmbCode = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ADBStartBtn
            // 
            this.ADBStartBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ADBStartBtn.Location = new System.Drawing.Point(742, 15);
            this.ADBStartBtn.Name = "ADBStartBtn";
            this.ADBStartBtn.Size = new System.Drawing.Size(84, 43);
            this.ADBStartBtn.TabIndex = 0;
            this.ADBStartBtn.Text = "Start/Pause";
            this.ADBStartBtn.UseVisualStyleBackColor = true;
            this.ADBStartBtn.Click += new System.EventHandler(this.ADBStartBtn_Click);
            // 
            // ADBClearBtn
            // 
            this.ADBClearBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ADBClearBtn.Location = new System.Drawing.Point(832, 17);
            this.ADBClearBtn.Name = "ADBClearBtn";
            this.ADBClearBtn.Size = new System.Drawing.Size(84, 43);
            this.ADBClearBtn.TabIndex = 1;
            this.ADBClearBtn.Text = "Clear";
            this.ADBClearBtn.UseVisualStyleBackColor = true;
            this.ADBClearBtn.Click += new System.EventHandler(this.ADBClearBtn_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ExitBtn.Location = new System.Drawing.Point(12, 15);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(84, 43);
            this.ExitBtn.TabIndex = 2;
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbLevel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TagNameBox);
            this.groupBox1.Controls.Add(this.TagEnable);
            this.groupBox1.Location = new System.Drawing.Point(115, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(529, 53);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // cmbLevel
            // 
            this.cmbLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLevel.FormattingEnabled = true;
            this.cmbLevel.Items.AddRange(new object[] {
            "Verbose",
            "Debug",
            "Info",
            "Warn",
            "Error",
            "Fatal",
            "Silent"});
            this.cmbLevel.Location = new System.Drawing.Point(397, 28);
            this.cmbLevel.Name = "cmbLevel";
            this.cmbLevel.Size = new System.Drawing.Size(121, 20);
            this.cmbLevel.TabIndex = 7;
            this.cmbLevel.SelectedIndexChanged += new System.EventHandler(this.cmbLevel_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "Filter string :";
            // 
            // TagNameBox
            // 
            this.TagNameBox.Location = new System.Drawing.Point(99, 29);
            this.TagNameBox.MaxLength = 40;
            this.TagNameBox.Name = "TagNameBox";
            this.TagNameBox.Size = new System.Drawing.Size(283, 21);
            this.TagNameBox.TabIndex = 5;
            // 
            // TagEnable
            // 
            this.TagEnable.AutoSize = true;
            this.TagEnable.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.TagEnable.Location = new System.Drawing.Point(4, 9);
            this.TagEnable.Margin = new System.Windows.Forms.Padding(1);
            this.TagEnable.Name = "TagEnable";
            this.TagEnable.Size = new System.Drawing.Size(114, 16);
            this.TagEnable.TabIndex = 4;
            this.TagEnable.Text = "Enable filter :";
            this.TagEnable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.TagEnable.UseVisualStyleBackColor = true;
            this.TagEnable.CheckedChanged += new System.EventHandler(this.TagEnable_CheckedChanged);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveBtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.SaveBtn.Location = new System.Drawing.Point(922, 21);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(83, 34);
            this.SaveBtn.TabIndex = 7;
            this.SaveBtn.Text = "SaveToFile";
            this.SaveBtn.UseVisualStyleBackColor = false;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Red;
            this.pictureBox1.Location = new System.Drawing.Point(719, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // consoleBox
            // 
            this.consoleBox.BackColor = System.Drawing.Color.Black;
            this.consoleBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.consoleBox.DetectUrls = false;
            this.consoleBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consoleBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consoleBox.ForeColor = System.Drawing.Color.White;
            this.consoleBox.HideSelection = false;
            this.consoleBox.Location = new System.Drawing.Point(0, 0);
            this.consoleBox.MaxLength = 7483647;
            this.consoleBox.Name = "consoleBox";
            this.consoleBox.ShortcutsEnabled = false;
            this.consoleBox.Size = new System.Drawing.Size(1008, 372);
            this.consoleBox.TabIndex = 0;
            this.consoleBox.Text = "";
            this.consoleBox.WordWrap = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.consoleBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.TopEnable);
            this.splitContainer1.Panel2.Controls.Add(this.cmbCode);
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel2.Controls.Add(this.SaveBtn);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.ExitBtn);
            this.splitContainer1.Panel2.Controls.Add(this.ADBClearBtn);
            this.splitContainer1.Panel2.Controls.Add(this.ADBStartBtn);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(1008, 442);
            this.splitContainer1.SplitterDistance = 372;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // TopEnable
            // 
            this.TopEnable.AutoSize = true;
            this.TopEnable.Checked = true;
            this.TopEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TopEnable.Location = new System.Drawing.Point(651, 41);
            this.TopEnable.Name = "TopEnable";
            this.TopEnable.Size = new System.Drawing.Size(66, 16);
            this.TopEnable.TabIndex = 10;
            this.TopEnable.Text = "TopMost";
            this.TopEnable.UseVisualStyleBackColor = true;
            this.TopEnable.CheckedChanged += new System.EventHandler(this.TopEnable_CheckedChanged);
            // 
            // cmbCode
            // 
            this.cmbCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCode.FormattingEnabled = true;
            this.cmbCode.Items.AddRange(new object[] {
            "UTF-8",
            "GBK"});
            this.cmbCode.Location = new System.Drawing.Point(650, 10);
            this.cmbCode.Name = "cmbCode";
            this.cmbCode.Size = new System.Drawing.Size(63, 20);
            this.cmbCode.TabIndex = 9;
            this.cmbCode.SelectedIndexChanged += new System.EventHandler(this.cmbCode_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 442);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(1024, 160);
            this.Name = "Form1";
            this.Text = "adb logcat";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button ADBStartBtn;
        private System.Windows.Forms.Button ADBClearBtn;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbLevel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TagNameBox;
        private System.Windows.Forms.CheckBox TagEnable;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox consoleBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox cmbCode;
        private System.Windows.Forms.CheckBox TopEnable;
    }
}

