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
            //выбор категории, отключена т.к. происходит поиск по названию категории, т.к. для изменения данных используется индекс, а не название заметки.
            // происходит конфликт. 
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
            var edit = new NoteForm(); 
            edit.NNote = selectedNote;
            edit.ShowDialog();
            if (edit.DialogResult == DialogResult.OK)
            {
                var updatedData = edit.NNote;
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


        private void RemoveNote()
        {
            if (NoteListBox.SelectedIndex == -1)
            {
                return;
            }
            var selectedIndex = NoteListBox.SelectedIndex;
            var selectedNote = _project.Notes[selectedIndex]; ;
            DialogResult result = MessageBox.Show(("«Do you really want to remove this note: " + selectedNote.Name),  "Remove Note",
                MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                NoteListBox.Items.RemoveAt(selectedIndex);
                _project.Notes.RemoveAt(selectedIndex);
                this.NameNoteLabel.Text = "";
                this.CategoryTextLabel.Text = "";
                this.NoteTextBox.Text = "";
                this.CreatedDateTimePicker.Value = DateTime.Now;
                this.ModifiedDateTimePicker.Value = DateTime.Now;
                ProjectManager.SaveToFile(_project, ProjectManager.DefaultPath);
            }
        }

        private void AddNote()
        {
            Note note = new Note();
            var add = new NoteForm();
            add.NNote = note;
            add.ShowDialog();
            if (add.DialogResult == DialogResult.OK)
            {
                var addData = add.NNote;
                _project.Notes.Add(addData);
                this.NameNoteLabel.Text = addData.Name;
                this.CategoryTextLabel.Text = addData.Category.ToString();
                this.NoteTextBox.Text = addData.Text;
                this.CreatedDateTimePicker.Value = addData.Created;
                this.ModifiedDateTimePicker.Value = addData.Modified;
                NoteListBox.Items.Add(addData.Name);
                ProjectManager.SaveToFile(_project,ProjectManager.DefaultPath);
            }
        }

        private void CloseForm()
        {
          ProjectManager.SaveToFile(_project, ProjectManager.DefaultPath);
          Environment.Exit(0);
        }

        private void AddNoteButton_Click(object sender, EventArgs e)
        {
            AddNote();
        }

        private void EditNoteButton_Click(object sender, EventArgs e)
        {
            EditNote();
        }

        private void RemoveNoteButton_Click(object sender, EventArgs e)
        {
            RemoveNote();
        }

        private void editNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditNote();
        }

        private void addNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNote();
        }

        private void removeNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveNote();
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

       

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseForm();
        }
    }

}
