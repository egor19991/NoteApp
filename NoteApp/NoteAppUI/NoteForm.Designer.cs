
namespace NoteAppUI
{
    partial class NoteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoteForm));
            this.Title = new System.Windows.Forms.Label();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.Category = new System.Windows.Forms.Label();
            this.CategoryComboBox = new System.Windows.Forms.ComboBox();
            this.Created = new System.Windows.Forms.Label();
            this.CreatedNoteDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.Modified = new System.Windows.Forms.Label();
            this.ModifiedNoteDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.NoteTextBox = new System.Windows.Forms.TextBox();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.TitleExeceptionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Title.AutoSize = true;
            this.Title.Location = new System.Drawing.Point(13, 13);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(30, 13);
            this.Title.TabIndex = 0;
            this.Title.Text = "Title:";
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TitleTextBox.Location = new System.Drawing.Point(72, 10);
            this.TitleTextBox.MaxLength = 50;
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(565, 20);
            this.TitleTextBox.TabIndex = 1;
            this.TitleTextBox.TextChanged += new System.EventHandler(this.TitleTextBox_TextChanged);
            // 
            // Category
            // 
            this.Category.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Category.AutoSize = true;
            this.Category.Location = new System.Drawing.Point(12, 42);
            this.Category.Name = "Category";
            this.Category.Size = new System.Drawing.Size(52, 13);
            this.Category.TabIndex = 2;
            this.Category.Text = "Category:";
            // 
            // CategoryComboBox
            // 
            this.CategoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CategoryComboBox.FormattingEnabled = true;
            this.CategoryComboBox.Location = new System.Drawing.Point(72, 39);
            this.CategoryComboBox.Name = "CategoryComboBox";
            this.CategoryComboBox.Size = new System.Drawing.Size(118, 21);
            this.CategoryComboBox.TabIndex = 3;
            // 
            // Created
            // 
            this.Created.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Created.AutoSize = true;
            this.Created.Location = new System.Drawing.Point(13, 77);
            this.Created.Name = "Created";
            this.Created.Size = new System.Drawing.Size(47, 13);
            this.Created.TabIndex = 4;
            this.Created.Text = "Created:";
            // 
            // CreatedNoteDateTimePicker
            // 
            this.CreatedNoteDateTimePicker.Enabled = false;
            this.CreatedNoteDateTimePicker.Location = new System.Drawing.Point(72, 71);
            this.CreatedNoteDateTimePicker.Name = "CreatedNoteDateTimePicker";
            this.CreatedNoteDateTimePicker.Size = new System.Drawing.Size(117, 20);
            this.CreatedNoteDateTimePicker.TabIndex = 5;
            // 
            // Modified
            // 
            this.Modified.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Modified.AutoSize = true;
            this.Modified.Location = new System.Drawing.Point(210, 77);
            this.Modified.Name = "Modified";
            this.Modified.Size = new System.Drawing.Size(50, 13);
            this.Modified.TabIndex = 6;
            this.Modified.Text = "Modified:";
            // 
            // ModifiedNoteDateTimePicker
            // 
            this.ModifiedNoteDateTimePicker.Enabled = false;
            this.ModifiedNoteDateTimePicker.Location = new System.Drawing.Point(263, 71);
            this.ModifiedNoteDateTimePicker.Name = "ModifiedNoteDateTimePicker";
            this.ModifiedNoteDateTimePicker.Size = new System.Drawing.Size(119, 20);
            this.ModifiedNoteDateTimePicker.TabIndex = 7;
            // 
            // NoteTextBox
            // 
            this.NoteTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NoteTextBox.Location = new System.Drawing.Point(13, 103);
            this.NoteTextBox.Multiline = true;
            this.NoteTextBox.Name = "NoteTextBox";
            this.NoteTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.NoteTextBox.Size = new System.Drawing.Size(619, 375);
            this.NoteTextBox.TabIndex = 8;
            // 
            // OK
            // 
            this.OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OK.Location = new System.Drawing.Point(467, 484);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(74, 23);
            this.OK.TabIndex = 9;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Cancel
            // 
            this.Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel.Location = new System.Drawing.Point(558, 484);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(74, 23);
            this.Cancel.TabIndex = 10;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // TitleExeceptionLabel
            // 
            this.TitleExeceptionLabel.AutoSize = true;
            this.TitleExeceptionLabel.Location = new System.Drawing.Point(210, 39);
            this.TitleExeceptionLabel.Name = "TitleExeceptionLabel";
            this.TitleExeceptionLabel.Size = new System.Drawing.Size(0, 13);
            this.TitleExeceptionLabel.TabIndex = 11;
            // 
            // NoteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 511);
            this.Controls.Add(this.TitleExeceptionLabel);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.NoteTextBox);
            this.Controls.Add(this.ModifiedNoteDateTimePicker);
            this.Controls.Add(this.Modified);
            this.Controls.Add(this.CreatedNoteDateTimePicker);
            this.Controls.Add(this.Created);
            this.Controls.Add(this.CategoryComboBox);
            this.Controls.Add(this.Category);
            this.Controls.Add(this.TitleTextBox);
            this.Controls.Add(this.Title);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(660, 550);
            this.Name = "NoteForm";
            this.Text = "Add/Edit Note";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.TextBox TitleTextBox;
        public System.Windows.Forms.Label Category;
        private System.Windows.Forms.ComboBox CategoryComboBox;
        private System.Windows.Forms.Label Created;
        private System.Windows.Forms.DateTimePicker CreatedNoteDateTimePicker;
        private System.Windows.Forms.Label Modified;
        private System.Windows.Forms.DateTimePicker ModifiedNoteDateTimePicker;
        private System.Windows.Forms.TextBox NoteTextBox;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Label TitleExeceptionLabel;
    }
}