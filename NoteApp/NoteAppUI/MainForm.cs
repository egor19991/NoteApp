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
            
            ProjectManager.SaveToFile(_project, ProjectManager.DefaultPath);
            
            
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
    }

}
