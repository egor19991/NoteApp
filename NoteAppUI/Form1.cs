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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var note = new Note();
            note.Name = "Д1 — серия дизель-поездов.";
            Console.WriteLine("Дата создания " + note.Created);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
       
    }

}
