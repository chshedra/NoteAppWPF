using System;
using Newtonsoft.Json;
using NoteApp.DataAccess;

namespace NoteApp.DataAccess
{
    /// <summary>
    /// Класс <see cref="Note"/>, хранящий информацию о названии, тексте, категории, 
    /// времени создания и времени последнего изменения заметки
    /// </summary>
    public class Note : INote, ICloneable, IComparable
    {
        /// <summary>
        /// Название заметки
        /// </summary>
        private string _title;
        
        /// <summary>
        /// Содержимое заметки
        /// </summary>
        private string _text;

        /// <summary>
        /// Категория заметки
        /// </summary>
        private NoteCategory _category;

        /// <inheritdoc/>
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if(value.Length > 50)
                {
                    throw new ArgumentException("Размер имени заметки должен быть " +
                        "менее 50 символов. " + "Текущий размер:" + value.Length);
                }
                Modified = DateTime.Now;
                _title = value;
            }
        }

        /// <inheritdoc/>
        public NoteCategory Category
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
                Modified = DateTime.Now;
            }
        }

        /// <inheritdoc/>
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                Modified = DateTime.Now;
            }
        }

        /// <inheritdoc/>
        public DateTime Created { get; private set; }

        /// <inheritdoc/>
        public DateTime Modified { get;  set; }

        /// <summary>
        /// Метод, создающий копию объекта класса
        /// </summary>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        
        /// <summary>
        /// Конструктор для сериализации, устанавливает значения полей Название, Текст, 
        /// Категория заметки, Время создания, Время изменения
        /// </summary>
        [JsonConstructor]
        public Note(string title, string text, NoteCategory category, 
            DateTime created, DateTime modified) 
        {
            Title = title;
            Text = text;
            Category = category;
            Created = created;
            Modified = modified;
        }

        /// <summary>
        /// Конструктор без параметров, устанавливает значения полей Название, Текст заметки, 
        /// Категория, Время создания ,Время изменения
        /// </summary>
        public Note() : this("Без названия", null, NoteCategory.Other,
	        DateTime.Now, DateTime.Now){}

        //+TODO: В цепочку конструкторов, чтобы убрать дублирование
        /// <summary>
        /// Метод, задающий условия сравнения коллекций
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            Note note = obj as Note;
            return note.Modified.CompareTo(this.Modified);
        }
    }
}
