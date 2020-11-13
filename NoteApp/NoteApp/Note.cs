using System;
using System.Runtime.Remoting.Messaging;


namespace NoteApp
{
   
    public class Note :ICloneable
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
        readonly DateTime _created = DateTime.Now;

        /// <summary>
        /// Переменная с датой изменения заметки.
        /// </summary>
        private DateTime _modefited;

        /// <summary>
        /// Переменная с категорией заметки.
        /// </summary>
        private NoteCategory _category;

        /// <summary>
        /// Возвращает и задает название заметки.
        /// </summary>
        public string Name
        {
            get { return _name;}
            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException("Длинна сторики должна быть меньше 50, а была " + value.Length);
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
                    _modefited=DateTime.Now;
                }
            }
        }

        /// <summary>
        /// Возвращает и задает категорию заметки.
        /// </summary>
        public NoteCategory Category
        {
            get { return _category;}
            set
            {
                _category = value;
                _modefited = DateTime.Now;
            }
        }
        /// <summary>
        /// Возвращает и задает текст заметки.
        /// </summary>
        public string Text
        {
            get { return _text;}
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
                _modefited = DateTime.Now;
            }
        }

        /// <summary>
        /// Возвращает время создания заметки.
        /// </summary>
        public DateTime Created
        {
            get { return _created; }
        }

        /// <summary>
        /// Вовращает время изменения заметки.
        /// </summary>
        public DateTime Modifated
        {
            get { return _modefited; }
        }

        /// <summary>
        /// Метод для клонирования заметки
        /// </summary>
        public object Clone()
        {
            return new Note
            {
                Name = this.Name, Category = this.Category,  Text = this.Text
            };
        }


    }




}

