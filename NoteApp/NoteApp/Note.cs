using System;
using System.Runtime.Remoting.Messaging;
using Newtonsoft.Json;


namespace NoteApp
{

    public class Note : ICloneable
    {
        /// <summary>
        /// Переменная с названим заметки.
        /// </summary>
        private string _name;

        /// <summary>
        /// Переменная с текстом заметки.
        /// </summary>
        private string _text;

        /// <summary>
        ///  Переменная с датой создания заметки.
        /// </summary>
        private DateTime _created = DateTime.Now;

        /// <summary>
        /// Переменная с датой изменения заметки.
        /// </summary>
        private DateTime _modified = DateTime.Now;

        /// <summary>
        /// Переменная с категорией заметки.
        /// </summary>
        private NoteCategory _category;

        /// <summary>
        /// Возвращает и задает название заметки.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException("Длина заголовка меньше 50, а " + value.Length);
                }
                else
                {
                    if (value == String.Empty)
                    {
                        _name = "Без названия";
                    }
                    else
                    {
                        _name = value;
                    }
                    _modified = DateTime.Now;
                }
            }
        }

        /// <summary>
        /// Возвращает и задает категорию заметки.
        /// </summary>
        public NoteCategory Category
        {
            get { return _category; }
            set
            {
                _category = value;
                _modified = DateTime.Now;
            }
        }

        /// <summary>
        /// Возвращает и задает текст заметки.
        /// </summary>
        public string Text
        {
            get { return _text; }
            set
            {
                if (value == String.Empty)
                {
                    _text = "Текст заметки";
                }
                else
                {
                    _text = value;
                }

                _modified = DateTime.Now;
            }
        }

        /// <summary>
        /// Возвращает время создания заметки.
        /// </summary>
        public DateTime Created
        {
            get { return _created; }
            set { _created = value; }
        }

        /// <summary>
        /// Вовращает время изменения заметки.
        /// </summary>
        public DateTime Modified
        {
            get { return _modified; }
            set { _modified = value; }
        }

        /// <summary>
        /// Метод для клонирования заметки
        /// </summary>
        public object Clone()
        {
            return new Note
            {
                Name = this.Name, Category = this.Category, Text = this.Text
            };
        }

        public Note() { }

        public Note(string name, string text, NoteCategory category)
        {
            Name = name;
            Text = text;
            Category = category;
        }

        [JsonConstructor]
        private Note(string name, string text, NoteCategory category, DateTime created, DateTime modified)
        {
            _name = name;
            _text = text;
            _category = category;
            _created = created;
            _modified = modified;
        }
    }
}

