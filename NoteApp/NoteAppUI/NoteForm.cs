using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NoteApp;

namespace NoteAppUI
{
    public partial class NoteForm : Form
    {
        private Note _note;

        public Note NNote
        {
            get
            {
                return _note;
            }
            set
            {
                _note = value;
                if (_note != null)
                {
                    TitleTextBox.Text = _note.Name;
                    NoteTextBox.Text = _note.Text;
                    CreatedNoteDateTimePicker.Value = _note.Created;
                    ModifiedNoteDateTimePicker.Value = _note.Modified;
                    CategoryComboBox.SelectedItem = _note.Category;
                }
            }
        }


        public NoteForm()
        {
            InitializeComponent();
            var categories = Enum.GetValues(typeof(NoteCategory));
            foreach (NoteCategory category in categories)
            {
                CategoryComboBox.Items.Add(category);
            }
        }

      

        private void OK_Click(object sender, EventArgs e)
        {
            _note.Name = TitleTextBox.Text;
            _note.Text = NoteTextBox.Text;
            _note.Category = (NoteCategory)CategoryComboBox.SelectedItem;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void TitleTextBox_TextChanged(object sender, EventArgs e)
        {
            if (TitleTextBox.Text.Length > 50)
            {
                TitleTextBox.BackColor = Color.Red;
                TitleExeceptionLabel.Text = "Max length 50";
                TitleExeceptionLabel.ForeColor = Color.Red;
                TitleTextBox.Text = TitleTextBox.Text.Substring(0, 50);
            }
        }
    }
}
