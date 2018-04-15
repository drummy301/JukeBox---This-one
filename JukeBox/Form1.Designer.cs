namespace JukeBox
{
    partial class JukeBoxForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JukeBoxForm));
            this.CopyRightLbl = new System.Windows.Forms.Label();
            this.GenreTitleTxtBox = new System.Windows.Forms.TextBox();
            this.GenreListBox = new System.Windows.Forms.ListBox();
            this.GenreSelecHScroll = new System.Windows.Forms.HScrollBar();
            this.PresentlyPlayTxtBox = new System.Windows.Forms.TextBox();
            this.PlayListBox = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.setupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WinMedPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WinMedPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // CopyRightLbl
            // 
            this.CopyRightLbl.AutoSize = true;
            this.CopyRightLbl.Location = new System.Drawing.Point(328, 9);
            this.CopyRightLbl.Name = "CopyRightLbl";
            this.CopyRightLbl.Size = new System.Drawing.Size(342, 17);
            this.CopyRightLbl.TabIndex = 0;
            this.CopyRightLbl.Text = "© 2018 JOSEPH DRUMMY ALL RIGHTS RESERVED";
            // 
            // GenreTitleTxtBox
            // 
            this.GenreTitleTxtBox.Location = new System.Drawing.Point(242, 99);
            this.GenreTitleTxtBox.Name = "GenreTitleTxtBox";
            this.GenreTitleTxtBox.Size = new System.Drawing.Size(176, 22);
            this.GenreTitleTxtBox.TabIndex = 1;
            // 
            // GenreListBox
            // 
            this.GenreListBox.FormattingEnabled = true;
            this.GenreListBox.ItemHeight = 16;
            this.GenreListBox.Items.AddRange(new object[] {
            "cant stop",
            "dancing in the moonlight",
            "the pretender",
            "pour it up"});
            this.GenreListBox.Location = new System.Drawing.Point(242, 127);
            this.GenreListBox.Name = "GenreListBox";
            this.GenreListBox.Size = new System.Drawing.Size(176, 84);
            this.GenreListBox.TabIndex = 2;
            this.GenreListBox.DoubleClick += new System.EventHandler(this.GenreListBox_DoubleClick);
            // 
            // GenreSelecHScroll
            // 
            this.GenreSelecHScroll.Location = new System.Drawing.Point(242, 214);
            this.GenreSelecHScroll.Name = "GenreSelecHScroll";
            this.GenreSelecHScroll.Size = new System.Drawing.Size(176, 22);
            this.GenreSelecHScroll.TabIndex = 3;
            // 
            // PresentlyPlayTxtBox
            // 
            this.PresentlyPlayTxtBox.Location = new System.Drawing.Point(242, 264);
            this.PresentlyPlayTxtBox.Name = "PresentlyPlayTxtBox";
            this.PresentlyPlayTxtBox.Size = new System.Drawing.Size(176, 22);
            this.PresentlyPlayTxtBox.TabIndex = 4;
            // 
            // PlayListBox
            // 
            this.PlayListBox.FormattingEnabled = true;
            this.PlayListBox.ItemHeight = 16;
            this.PlayListBox.Location = new System.Drawing.Point(242, 311);
            this.PlayListBox.Name = "PlayListBox";
            this.PlayListBox.Size = new System.Drawing.Size(176, 196);
            this.PlayListBox.TabIndex = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setupToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 625);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(682, 28);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // setupToolStripMenuItem
            // 
            this.setupToolStripMenuItem.Name = "setupToolStripMenuItem";
            this.setupToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.setupToolStripMenuItem.Text = "Setup";
            this.setupToolStripMenuItem.Click += new System.EventHandler(this.setupToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // WinMedPlayer
            // 
            this.WinMedPlayer.Enabled = true;
            this.WinMedPlayer.Location = new System.Drawing.Point(12, 9);
            this.WinMedPlayer.Name = "WinMedPlayer";
            this.WinMedPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("WinMedPlayer.OcxState")));
            this.WinMedPlayer.Size = new System.Drawing.Size(10, 10);
            this.WinMedPlayer.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(67, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // JukeBoxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(682, 653);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PlayListBox);
            this.Controls.Add(this.PresentlyPlayTxtBox);
            this.Controls.Add(this.GenreSelecHScroll);
            this.Controls.Add(this.GenreListBox);
            this.Controls.Add(this.GenreTitleTxtBox);
            this.Controls.Add(this.CopyRightLbl);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.WinMedPlayer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(700, 700);
            this.Name = "JukeBoxForm";
            this.Text = "JukeBox";
            this.Load += new System.EventHandler(this.JukeBoxForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WinMedPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CopyRightLbl;
        private System.Windows.Forms.TextBox GenreTitleTxtBox;
        private System.Windows.Forms.ListBox GenreListBox;
        private System.Windows.Forms.HScrollBar GenreSelecHScroll;
        private System.Windows.Forms.TextBox PresentlyPlayTxtBox;
        private System.Windows.Forms.ListBox PlayListBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem setupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private AxWMPLib.AxWindowsMediaPlayer WinMedPlayer;
        private System.Windows.Forms.Button button1;
    }
}

