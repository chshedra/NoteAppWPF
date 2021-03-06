using System.ComponentModel;

namespace NoteAppWPF.ViewModels
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
	}
}