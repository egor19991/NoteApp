using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NoteApp
{
    /// <summary>
    /// Класс проекта, хранит лист с заметками
    /// </summary>
    public class Project
    {
        
        public List<Note> Notes { get; set; } = new List<Note>();
        
    }
}
