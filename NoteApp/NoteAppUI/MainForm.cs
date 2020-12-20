using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NoteApp;

namespace NoteAppUI
{
    public partial class MainForm : Form
    {
        private Project _project;
        //private Project _project = new Project();

        public MainForm()
        {
            InitializeComponent();
            _project = ProjectManager.LoadToFile(ProjectManager.DefaultPath);
            var categories = Enum.GetValues(typeof(NoteCategory));
            foreach (NoteCategory category in categories)
            {
                CategoryComboBox.Items.Add(category);
            }
            CategoryComboBox.Items.Add("All");
            CategoryComboBox.SelectedItem = "All";


        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            /*foreach (var item in _project.Notes)
            {
                NoteListBox.Items.Add(item.Name);
            }*/
        }



        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.Show();
        }

        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CategoryComboBox.SelectedIndex == -1)
            {
                return;
            }
            if (CategoryComboBox.SelectedItem.ToString() != "All")
            {
                NoteCategory selectedCategory;
                selectedCategory = (NoteCategory) CategoryComboBox.SelectedItem;
                NoteListBox.Items.Clear(); 
                foreach (var item in _project.Notes)
                {
                     if (item.Category == selectedCategory)
                     {
                         NoteListBox.Items.Add(item.Name);
                     } 
                }
            }
            else
            {
                NoteListBox.Items.Clear();
                foreach (var item in _project.Notes)
                { 
                    NoteListBox.Items.Add(item.Name);
                }
            }
        }

        private void NoteListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NoteListBox.SelectedIndex == -1)
            {
                return;
            } 
            //Элемент листа ищется по названию
            var selectedItem = _project.Notes.Find(x => x.Name.Contains(NoteListBox.SelectedItem.ToString()));
            this.NameNoteLabel.Text = selectedItem.Name;
            this.CategoryTextLabel.Text = selectedItem.Category.ToString();
            this.NoteTextBox.Text = selectedItem.Text; 
            this.CreatedDateTimePicker.Value = selectedItem.Created;
            this.ModifiedDateTimePicker.Value = selectedItem.Modified;
        }


    }

}
