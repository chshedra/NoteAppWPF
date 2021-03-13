using System.Collections.ObjectModel;
using NoteApp.DataAccess;

namespace NoteApp.Application.WPF.Model
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
		/// Добавляет новую заметку и сортирует список
		/// </summary>
		void SortNotes();
	}
}
