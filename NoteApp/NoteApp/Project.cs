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
        /// <summary>
        /// Переменная хранит номер выбранной заметки
        /// </summary>
        private int _selectNote;

        /// <summary>
        /// Метод хранит лист заметок
        /// </summary>
        public List<Note> Notes { get; set; } = new List<Note>();

        /// <summary>
        /// Метод хранит номер выбранной заметки
        /// </summary>
        public int SelectNote
        {
            get { return _selectNote; }
            set { _selectNote = value; }
        }

        /// <summary>
        /// Метод выполняет сортировку листа
        /// </summary>
        public List<Note> SortList()
        {
            var sortedNote =  Notes.OrderByDescending(note => note.Modified).ToList();
            return sortedNote;
        }
        public List<Note> SortList(NoteCategory category)
        {
            List<Note> sortedNote = new List<Note>();
            sortedNote = Notes.Where(note => note.Category == category).OrderByDescending(note => note.Modified).ToList();
            return sortedNote;
        }

    }
}
