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
        private List<Note> _sortedList;

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
            _sortedList = _project.SortList();
            if (_project.Notes.Count != 0)
            {
                var selectedItem = _project.Notes[_project.SelectNote];
                this.NameNoteLabel.Text = selectedItem.Name;
                this.CategoryTextLabel.Text = selectedItem.Category.ToString();
                this.NoteTextBox.Text = selectedItem.Text;
                this.CreatedDateTimePicker.Value = selectedItem.Created;
                this.ModifiedDateTimePicker.Value = selectedItem.Modified;
            }
        }
        
        private void Form1_Load(object sender, EventArgs e) { }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.Show();
        }

        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeCategory();
        }

        private void NoteListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NoteListBox.SelectedIndex == -1)
            {
                return;
            }
            //Поиск элемента по индексу ListsBox
            var  selectedItem = _sortedList[NoteListBox.SelectedIndex];
            //Элемент листа ищется по названию ListBox
            //var selectedItem = _project.Notes.Find(x => x.Name.Contains(NoteListBox.SelectedItem.ToString()));
            this.NameNoteLabel.Text = selectedItem.Name;
            this.CategoryTextLabel.Text = selectedItem.Category.ToString();
            this.NoteTextBox.Text = selectedItem.Text; 
            this.CreatedDateTimePicker.Value = selectedItem.Created;
            this.ModifiedDateTimePicker.Value = selectedItem.Modified;
            _project.SelectNote = _project.Notes.IndexOf(selectedItem);
        }

        private void EditNote()
        {
            if (NoteListBox.SelectedIndex == -1)
            {
                return;
            }
            var selectedIndex = NoteListBox.SelectedIndex;
            var selectedNote = _sortedList[selectedIndex];
            var edit = new NoteForm(); 
            edit.NNote = selectedNote;
            edit.ShowDialog();
            if (edit.DialogResult == DialogResult.OK)
            {
                //Индекс заметки в файле проекта
                var projectIndex = _project.Notes.IndexOf(selectedNote);
                var updatedData = edit.NNote;
                NoteListBox.Items.RemoveAt(selectedIndex);
                _project.Notes.RemoveAt(projectIndex);
                _project.Notes.Insert(projectIndex, updatedData);
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
            var selectedNote = _sortedList[selectedIndex];
            DialogResult result = MessageBox.Show(("«Do you really want to remove this note: " + selectedNote.Name),  "Remove Note",
                MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                var projectIndex = _project.Notes.IndexOf(selectedNote);
                NoteListBox.Items.RemoveAt(selectedIndex);
                _project.Notes.RemoveAt(projectIndex);
                this.NameNoteLabel.Text = "";
                this.CategoryTextLabel.Text = "";
                this.NoteTextBox.Text = "";
                this.CreatedDateTimePicker.Value = DateTime.Now;
                this.ModifiedDateTimePicker.Value = DateTime.Now;
                ProjectManager.SaveToFile(_project, ProjectManager.DefaultPath);
                ChangeCategory();
                _project.SelectNote = _project.Notes.IndexOf(_sortedList[0]);
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
                ChangeCategory();
                ProjectManager.SaveToFile(_project,ProjectManager.DefaultPath);
            }
        }

        private void ChangeCategory()
        {
            if (CategoryComboBox.SelectedIndex == -1)
            {
                return;
            }
            if (CategoryComboBox.SelectedItem.ToString() != "All")
            {
                NoteCategory selectedCategory;
                selectedCategory = (NoteCategory)CategoryComboBox.SelectedItem;
                _sortedList = _project.SortList(selectedCategory);
                NoteListBox.Items.Clear();
                foreach (var item in _sortedList)
                {
                    NoteListBox.Items.Add(item.Name);
                }
            }
            else
            {
                NoteListBox.Items.Clear();
                _sortedList = _project.SortList();
                foreach (var item in _sortedList)
                {
                    NoteListBox.Items.Add(item.Name);
                }
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

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveNote();
            }
        }
    }
}
