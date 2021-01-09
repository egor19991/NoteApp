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
        /// <summary>
        /// Переменная, которая хранит загруженный проект
        /// </summary>
        private Project _project;

        /// <summary>
        /// Переменная хранит отсортированный лист
        /// </summary>
        private List<Note> _viewedNotes;

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
            _viewedNotes = _project.SortList();
            if (_project.Notes.Count != 0)
            {
                var selectedItem = _project.Notes[_project.SelectNote];
                UpdateFormFields(selectedItem);
                NoteListBox.SelectedIndex = _viewedNotes.IndexOf(selectedItem);
            }
        }
        
        /// <summary>
        /// Метод для изменения выбранной заметки
        /// </summary>
        private void EditNote()
        {
            if (NoteListBox.SelectedIndex == -1)
            {
                return;
            }
            var selectedIndex = NoteListBox.SelectedIndex;
            var selectedNote = _viewedNotes[selectedIndex];
            var edit = new NoteForm(); 
            edit.@Note = selectedNote;
            edit.ShowDialog();
            if (edit.DialogResult == DialogResult.OK)
            {
                //Индекс заметки в файле проекта
                var projectIndex = _project.Notes.IndexOf(selectedNote);
                var updatedData = edit.@Note;
                NoteListBox.Items.RemoveAt(selectedIndex);
                _project.Notes.RemoveAt(projectIndex);
                _project.Notes.Insert(projectIndex, updatedData);
                UpdateFormFields(updatedData);
                NoteListBox.Items.Insert(selectedIndex, updatedData.Name);
                ChangeCategory();
            }
        }

        /// <summary>
        /// Метод для удаления заметки
        /// </summary>
        private void RemoveNote()
        {
            if (NoteListBox.SelectedIndex == -1)
            {
                return;
            }
            var selectedIndex = NoteListBox.SelectedIndex;
            var selectedNote = _viewedNotes[selectedIndex];
            DialogResult result = MessageBox.Show(("Do you really want to remove this note: " + selectedNote.Name),  "Remove Note",
                MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                var projectIndex = _project.Notes.IndexOf(selectedNote);
                NoteListBox.Items.RemoveAt(selectedIndex);
                _project.Notes.RemoveAt(projectIndex);
                CleanFormFields();
                ProjectManager.SaveToFile(_project, ProjectManager.DefaultPath);
                if (_project.Notes.Count > 0)
                {
                    _project.SelectNote = _project.Notes.IndexOf(_project.SortList()[0]);
                }
                else
                {
                    _project.SelectNote = 0;
                }
                ChangeCategory();
            }
        }

        /// <summary>
        /// Метод для создания заметки
        /// </summary>
        private void AddNote()
        {
            Note note = new Note();
            var add = new NoteForm();
            add.@Note = note;
            add.ShowDialog();
            if (add.DialogResult == DialogResult.OK)
            {
                var addData = add.@Note;
                _project.Notes.Add(addData);
                ProjectManager.SaveToFile(_project,ProjectManager.DefaultPath);
                _project.SelectNote = _project.Notes.IndexOf(addData);
                ChangeCategory();
            }
        }

        /// <summary>
        /// Метод выполняет обновление листа заметок и NoteListBox
        /// </summary>
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
                _viewedNotes = _project.SortList(selectedCategory);
                NoteListBox.Items.Clear();
                foreach (var item in _viewedNotes)
                {
                    NoteListBox.Items.Add(item.Name);
                }
                if (_project.Notes.Count > 0 && _project.Notes[_project.SelectNote].Category == selectedCategory)
                {
                    var selectedItem = _project.Notes[_project.SelectNote];
                    UpdateFormFields(selectedItem);
                    NoteListBox.SelectedIndex = _viewedNotes.IndexOf(selectedItem);
                }
                else
                {
                    CleanFormFields();
                }
            }
            else
            {
                NoteListBox.Items.Clear();
                _viewedNotes = _project.SortList();
                foreach (var item in _viewedNotes)
                {
                    NoteListBox.Items.Add(item.Name);
                }

                if (_project.Notes.Count > 0)
                {
                    var selectedItem = _project.Notes[_project.SelectNote];
                    UpdateFormFields(selectedItem);
                    NoteListBox.SelectedIndex = _viewedNotes.IndexOf(selectedItem);
                }
            }
        }

        /// <summary>
        /// Метод обновления данных в полях отображения заметки
        /// </summary>
        private void UpdateFormFields(Note _sourceNote)
        {
            this.NameNoteLabel.Text = _sourceNote.Name;
            this.CategoryTextLabel.Text = _sourceNote.Category.ToString();
            this.NoteTextBox.Text = _sourceNote.Text;
            this.CreatedDateTimePicker.Value = _sourceNote.Created;
            this.ModifiedDateTimePicker.Value = _sourceNote.Modified;
        }

        /// <summary>
        /// Метод очистки данных в полях отображения заметки
        /// </summary>
        private void CleanFormFields()
        {
            this.NameNoteLabel.Text = "";
            this.CategoryTextLabel.Text = "";
            this.NoteTextBox.Text = "";
            this.CreatedDateTimePicker.Value = DateTime.Now;
            this.ModifiedDateTimePicker.Value = DateTime.Now;
        }

        private void NoteListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NoteListBox.SelectedIndex == -1)
            {
                return;
            }
            var selectedItem = _viewedNotes[NoteListBox.SelectedIndex];
            UpdateFormFields(selectedItem);
            _project.SelectNote = _project.Notes.IndexOf(selectedItem);
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

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.Show();
        }

        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeCategory();
        }
    }
}
