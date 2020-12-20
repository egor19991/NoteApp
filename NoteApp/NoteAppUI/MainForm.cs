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
            this.Text = "NoteApp";
            this.MinimumSize = new System.Drawing.Size(800, 480);
            _project = ProjectManager.LoadToFile(ProjectManager.DefaultPath);
           foreach (var item in _project.Notes)
           {
               NoteListBox.Items.Add(item.Name);
           }

            //ComboBox
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
                // Если ничего не выбрано, завершаем обработчик
                return;
            }
            NoteCategory selectedCategory;
            //selectedColor = (NoteCategory)CategoryComboBox.SelectedItem;
            //this.BackColor = selectedColor;
        }

        private void NoteListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = NoteListBox.SelectedIndex;
            var firstItem = _project.Notes[index];
            this.NameNoteLabel.Text = firstItem.Name;
            //this.CategoryTextLabel.Text = nameof(firstItem.Category);
            Console.Write(nameof(firstItem.Category));
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
