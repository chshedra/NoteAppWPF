using System.Collections.Generic;

namespace NoteApp.DataAccess
{
	/// <summary>
	/// Класс <see cref="Project"/>, хранящий список объектов класса Note
	/// </summary>
	public class Project
	{
		//TODO: Какой смысл в инициализации, если в конструкторе идёт присваивание?
		//TODO: Нужен паблик сет?
		/// <summary>
		/// Устанавливает и возвращает список объектов класса Note
		/// </summary>
		public List<Note> Notes { get; set; } = new List<Note>();

		/// <summary>
		/// Возвращает и устанавливает значение текущей заметки
		/// </summary>
		public Note CurrentNote { get; set; }

		/// <summary>
		/// Конструктор класса Project
		/// </summary>
		/// <param name="notes"> Список заметок</param>
		/// <param name="currentNote">Текущая заметка</param>
		public Project(List<Note> notes, Note currentNote)
		{
			//TODO: Упрощённую запись через ?? посмотрите
			Notes = notes != null
				? notes 
				: new List<Note>() ;
			CurrentNote = notes.Contains(currentNote)
				? currentNote
				: null;
		}

		/// <summary>
		/// Создает пустой объект Project
		/// </summary>
		public Project() : this(new List<Note>(), new Note()) { }
	}
}
