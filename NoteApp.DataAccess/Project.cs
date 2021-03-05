using System.Collections.Generic;

namespace NoteApp.DataAccess
{
	/// <summary>
	/// Класс <see cref="Project"/>, хранящий список объектов класса Note
	/// </summary>
	public class Project
	{
		/// <summary>
		/// Устанавливает и возвращает список объектов класса Note
		/// </summary>
		public List<Note> Notes { get; set; } = new List<Note>();

		/// <summary>
		/// Возвращает и устанавливает значение текущей заметки
		/// </summary>
		public Note CurrentNote { get; set; }
	}
}
