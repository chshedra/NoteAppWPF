using System;

namespace NoteApp.DataAccess
{
	/// <summary>
	/// Данные заметки и методы для обработки данных заметки
	/// </summary>
	public interface INote
	{
		/// <summary>
		/// Возвращает и устанавливает заголовок заметки
		/// </summary>
		string Title { get; set; }

		/// <summary>
		/// Возвращает и устанавливает текст заметки
		/// </summary>
		string Text { get; set; }

		/// <summary>
		/// Возвращает и устанавливает категорию заметки
		/// </summary>
		NoteCategory Category { get; set; }

		/// <summary>
		/// Возвращает и устанавливает время создания заметки
		/// </summary>
		DateTime Created { get; }

		/// <summary>
		/// Возвращает и устанавливает время изменения заметки
		/// </summary>
		DateTime Modified { get; set; }

	}
}
