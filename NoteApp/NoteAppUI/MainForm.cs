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
        private Project _project = new Project();

       public MainForm()
        {
            InitializeComponent();
            Note not = new Note();
            not.Name = "Д1 — серия дизель-поездов, строившаяся ";
            not.Text = "Всего было построено 605 составов. Конструкционно Д1 являлись усовершенствованной версией дизель-поездов серии Д и" +
                       " отличались от последних прежде всего наличием более мощного дизельного двигателя, гидромеханической передачи и составностью," +
                       " увеличенной на один прицепной вагон.";
            not.Category = NoteCategory.People;
            Note n2 = (Note)not.Clone();
            n2.Name = "Svin";
            Console.WriteLine(not.Name);
            Console.WriteLine(n2.Name);
            _project.Notes.Add(n2);
            _project.Notes.Add(not);
            //ProjectManager.SaveToFile(_project);
            Console.WriteLine(n2.Name);
            _project = ProjectManager.ReturnToFile();
            
        }


        

        private void Form1_Load(object sender, EventArgs e)
        {

        }
       
    }

}
