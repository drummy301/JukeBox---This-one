namespace JukeBox
{
    partial class SetupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupForm));
            this.importListBox = new System.Windows.Forms.ListBox();
            this.trackListBox = new System.Windows.Forms.ListBox();
            this.copyBtn = new System.Windows.Forms.Button();
            this.moveBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.importBtn = new System.Windows.Forms.Button();
            this.leftGenreSelectorBtn = new System.Windows.Forms.Button();
            this.clearImportsBtn = new System.Windows.Forms.Button();
            this.rightGenreSelectorBtn = new System.Windows.Forms.Button();
            this.addGenreBtn = new System.Windows.Forms.Button();
            this.deleteGenreBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // importListBox
            // 
            this.importListBox.FormattingEnabled = true;
            this.importListBox.ItemHeight = 16;
            this.importListBox.Location = new System.Drawing.Point(22, 87);
            this.importListBox.Name = "importListBox";
            this.importListBox.Size = new System.Drawing.Size(262, 276);
            this.importListBox.TabIndex = 0;
            this.importListBox.SelectedIndexChanged += new System.EventHandler(this.importListBox_SelectedIndexChanged);
            // 
            // trackListBox
            // 
            this.trackListBox.FormattingEnabled = true;
            this.trackListBox.ItemHeight = 16;
            this.trackListBox.Location = new System.Drawing.Point(290, 87);
            this.trackListBox.Name = "trackListBox";
            this.trackListBox.Size = new System.Drawing.Size(262, 276);
            this.trackListBox.TabIndex = 1;
            // 
            // copyBtn
            // 
            this.copyBtn.Location = new System.Drawing.Point(22, 28);
            this.copyBtn.Name = "copyBtn";
            this.copyBtn.Size = new System.Drawing.Size(262, 23);
            this.copyBtn.TabIndex = 2;
            this.copyBtn.Text = "Copy Track > > >";
            this.copyBtn.UseVisualStyleBackColor = true;
            // 
            // moveBtn
            // 
            this.moveBtn.Location = new System.Drawing.Point(22, 57);
            this.moveBtn.Name = "moveBtn";
            this.moveBtn.Size = new System.Drawing.Size(262, 23);
            this.moveBtn.TabIndex = 3;
            this.moveBtn.Text = "Move Track > > >";
            this.moveBtn.UseVisualStyleBackColor = true;
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(290, 369);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(262, 23);
            this.deleteBtn.TabIndex = 4;
            this.deleteBtn.Text = "Delete Track";
            this.deleteBtn.UseVisualStyleBackColor = true;
            // 
            // importBtn
            // 
            this.importBtn.Location = new System.Drawing.Point(22, 369);
            this.importBtn.Name = "importBtn";
            this.importBtn.Size = new System.Drawing.Size(262, 23);
            this.importBtn.TabIndex = 5;
            this.importBtn.Text = "Import Directory";
            this.importBtn.UseVisualStyleBackColor = true;
            // 
            // leftGenreSelectorBtn
            // 
            this.leftGenreSelectorBtn.Location = new System.Drawing.Point(290, 58);
            this.leftGenreSelectorBtn.Name = "leftGenreSelectorBtn";
            this.leftGenreSelectorBtn.Size = new System.Drawing.Size(32, 23);
            this.leftGenreSelectorBtn.TabIndex = 6;
            this.leftGenreSelectorBtn.Text = "<";
            this.leftGenreSelectorBtn.UseVisualStyleBackColor = true;
            // 
            // clearImportsBtn
            // 
            this.clearImportsBtn.Location = new System.Drawing.Point(22, 398);
            this.clearImportsBtn.Name = "clearImportsBtn";
            this.clearImportsBtn.Size = new System.Drawing.Size(75, 23);
            this.clearImportsBtn.TabIndex = 7;
            this.clearImportsBtn.Text = "Clear";
            this.clearImportsBtn.UseVisualStyleBackColor = true;
            // 
            // rightGenreSelectorBtn
            // 
            this.rightGenreSelectorBtn.Location = new System.Drawing.Point(520, 57);
            this.rightGenreSelectorBtn.Name = "rightGenreSelectorBtn";
            this.rightGenreSelectorBtn.Size = new System.Drawing.Size(32, 23);
            this.rightGenreSelectorBtn.TabIndex = 8;
            this.rightGenreSelectorBtn.Text = ">";
            this.rightGenreSelectorBtn.UseVisualStyleBackColor = true;
            this.rightGenreSelectorBtn.Click += new System.EventHandler(this.rightGenreSelectorBtn_Click);
            // 
            // addGenreBtn
            // 
            this.addGenreBtn.Location = new System.Drawing.Point(427, 29);
            this.addGenreBtn.Name = "addGenreBtn";
            this.addGenreBtn.Size = new System.Drawing.Size(125, 23);
            this.addGenreBtn.TabIndex = 9;
            this.addGenreBtn.Text = "Add ";
            this.addGenreBtn.UseVisualStyleBackColor = true;
            // 
            // deleteGenreBtn
            // 
            this.deleteGenreBtn.Location = new System.Drawing.Point(290, 29);
            this.deleteGenreBtn.Name = "deleteGenreBtn";
            this.deleteGenreBtn.Size = new System.Drawing.Size(125, 23);
            this.deleteGenreBtn.TabIndex = 10;
            this.deleteGenreBtn.Text = "Delete";
            this.deleteGenreBtn.UseVisualStyleBackColor = true;
            this.deleteGenreBtn.Click += new System.EventHandler(this.deleteGenreBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(302, 443);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 11;
            this.okBtn.Text = "Ok";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(489, 443);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 12;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(328, 58);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(189, 22);
            this.textBox1.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.importListBox);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.trackListBox);
            this.groupBox1.Controls.Add(this.copyBtn);
            this.groupBox1.Controls.Add(this.moveBtn);
            this.groupBox1.Controls.Add(this.deleteGenreBtn);
            this.groupBox1.Controls.Add(this.deleteBtn);
            this.groupBox1.Controls.Add(this.addGenreBtn);
            this.groupBox1.Controls.Add(this.importBtn);
            this.groupBox1.Controls.Add(this.rightGenreSelectorBtn);
            this.groupBox1.Controls.Add(this.leftGenreSelectorBtn);
            this.groupBox1.Controls.Add(this.clearImportsBtn);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(557, 425);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add/Delete Music";
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 483);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SetupForm";
            this.Text = "Setup";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox importListBox;
        private System.Windows.Forms.ListBox trackListBox;
        private System.Windows.Forms.Button copyBtn;
        private System.Windows.Forms.Button moveBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button importBtn;
        private System.Windows.Forms.Button leftGenreSelectorBtn;
        private System.Windows.Forms.Button clearImportsBtn;
        private System.Windows.Forms.Button rightGenreSelectorBtn;
        private System.Windows.Forms.Button addGenreBtn;
        private System.Windows.Forms.Button deleteGenreBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}