﻿using System;
using System.Runtime.Remoting.Messaging;


namespace NoteApp
{
    public class Note
    {
        private string _name;
        private string _text;
        readonly DateTime _created = DateTime.Now;

        public enum NoteCategory
        {
            Work,
            House,
            Health_and_Sport,
            People,
            Documents,
            Finance,
            Different
        }


        /// <summary>
        /// Возвращает и задает название.
        /// </summary>
        public string Name
        {
            get { return _name;}
            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException("Длинна сторики должна быть меньше 50, а была " +
                                                value.Length);

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
                    Modifated = DateTime.Now;
                }
            }
        }

        /// <summary>
        /// Возвращает и задает категорию заметки.
        /// </summary>
        public NoteCategory Category  { get ; set; }
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
                    throw new ArgumentException("Поле для ввода текста не должно быть пустым");
                }
                else
                {
                    _text = value;
                    Modifated = DateTime.Now;
                }
            }
        }

        /// <summary>
        /// Возвращает и задает время создания заметки.
        /// </summary>
        public DateTime Created
        {
            get { return _created; }
        }
        /// <summary>
        /// Метод, выполняющий смену даты изменения.
        /// </summary>
        public DateTime Modifated {get; set; }

        
    }

}

