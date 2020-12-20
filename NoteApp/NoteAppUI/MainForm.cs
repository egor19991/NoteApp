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
            foreach (var item in _project.Notes)
            {
                NoteListBox.Items.Add(item.Name);
            }
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
            /*if (CategoryComboBox.SelectedItem.ToString() != "All")
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
            }*/
        }

        private void NoteListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NoteListBox.SelectedIndex == -1)
            {
                return;
            }
            //Поиск элемента по индексу ListsBox
            var  selectedItem = _project.Notes[NoteListBox.SelectedIndex];

            //Элемент листа ищется по названию ListBox
            //var selectedItem = _project.Notes.Find(x => x.Name.Contains(NoteListBox.SelectedItem.ToString()));
            this.NameNoteLabel.Text = selectedItem.Name;
            this.CategoryTextLabel.Text = selectedItem.Category.ToString();
            this.NoteTextBox.Text = selectedItem.Text; 
            this.CreatedDateTimePicker.Value = selectedItem.Created;
            this.ModifiedDateTimePicker.Value = selectedItem.Modified;
        }

        private void EditNote()
        {
            if (NoteListBox.SelectedIndex == -1)
            {
                return;
            }
            var selectedIndex = NoteListBox.SelectedIndex;
            var selectedNote = _project.Notes[selectedIndex];
            var add = new NoteForm(); 
            add.NNote = selectedNote;
            add.ShowDialog();
            if (add.DialogResult == DialogResult.OK)
            {
                var updatedData = add.NNote;
                NoteListBox.Items.RemoveAt(selectedIndex);
                _project.Notes.RemoveAt(selectedIndex);
                _project.Notes.Insert(selectedIndex, updatedData);
                this.NameNoteLabel.Text = updatedData.Name;
                this.CategoryTextLabel.Text = updatedData.Category.ToString();
                this.NoteTextBox.Text = updatedData.Text;
                this.CreatedDateTimePicker.Value = updatedData.Created;
                this.ModifiedDateTimePicker.Value = updatedData.Modified;
                NoteListBox.Items.Insert(selectedIndex, updatedData.Name);
            }
        }

        private void AddNoteButton_Click(object sender, EventArgs e)
        {
            
        }

        private void EditNoteButton_Click(object sender, EventArgs e)
        {
            EditNote();
        }

        private void RemoveNoteButton_Click(object sender, EventArgs e)
        {

        }

        private void editNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditNote();
        }
    }

}
