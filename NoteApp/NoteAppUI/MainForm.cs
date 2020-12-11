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

       public MainForm()
        {
            InitializeComponent();
            this.Text = "NoteApp";
            this.Size = new Size(800, 480);
            _project = ProjectManager.LoadToFile(ProjectManager.DefaultPath);
           foreach (var item in _project.Notes)
            {
                NoteListBox.Items.Add(item.Name);
            }



        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.Show();
        }
    }

}
