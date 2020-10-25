using System;

namespace NoteApp
{
    public class Note
    {
        /// <summary>
        /// Возвращает и задает название.
        /// </summary>
        public string Title 
        {
            get {};
            set
            {
                if (value.Length > 50)
                {
                    
                }
            }
        }
        /// <summary>
        /// Возвращает и задает категорию заметки.
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// Возвращает и задает текст заметки.
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Возвращает и задает время создания заметки.
        /// </summary>
        protected string TimeCreate { get; set; }
        /// <summary>
        /// Метод, выполняющий смену даты изменения.
        /// </summary>
        public string TimeChange { get; set; }
    }

}

