using System;
using System.Collections.ObjectModel;
using NoteApp.DataAccess;

namespace NoteApp.Application.WPF
{
	/// <summary>
	/// Модель с бизнес-логикой программы
	/// </summary>
	public interface INotesModel
	{
		/// <summary>
		/// Возвращает и устанавливает список заметок
		/// </summary>
		ObservableCollection<Note> Notes { get; set; }

		/// <summary>
		/// Устанавливает и возвращает значение текущей заметки
		/// </summary>
		Note CurrentNote { get; set;}

		/// <summary>
		/// Уведомляет об изменении заметки
		/// </summary>
		event EventHandler<NoteEventArgs> NoteUpdated;

		/// <summary>
		/// Обновляет данные заметки
		/// </summary>
		/// <param name="updatedNote"></param>
		void UpdateNote(INote updatedNote);
	}
}
