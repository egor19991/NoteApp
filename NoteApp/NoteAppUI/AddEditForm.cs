using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteAppUI
{
    public partial class AddEditForm : Form
    {
        public AddEditForm()
        {
            InitializeComponent();
            this.Text = "Add/Edit Note";
            this.MinimumSize = new System.Drawing.Size(620, 375);
        }

        private void AddEditForm_Load(object sender, EventArgs e)
        {

        }
    }
}
