using System.ComponentModel;

namespace NoteApp.Application.WPF
{
	/// <summary>
	/// Модель представления списка заметок
	/// </summary>
	public interface INotesViewModel : INotifyPropertyChanged
	{
		/// <summary>
		/// Возвращает и устанавливает значение выбранной заметки
		/// </summary>
		INoteViewModel SelectedNote { get; set; }

		/// <summary>
		/// Обновляет содержимое заметки
		/// </summary>
		void UpdateNote();
	}
}