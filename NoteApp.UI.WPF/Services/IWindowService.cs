using NoteAppWPF.ViewModels;

namespace NoteAppWPF.Services
{
	/// <summary>
	/// Сервис вызова окон приложения
	/// </summary>
	public interface IWindowService
	{
		/// <summary>
		/// Устанавливает и возвращает результат вызова окна
		/// </summary>
		bool NoteWindowResult { get; set; }

		/// <summary>
		/// Вызывает информационное окно
		/// </summary>
		void ShowAboutWindow();

		/// <summary>
		/// Вызывает окно редактирования
		/// </summary>
		/// <param name="editingNoteViewModel">Модель представление текущей заметки</param>
		bool? ShowNoteWindow(IEditingNoteViewModel editingNoteViewModel);

		/// <summary>
		/// Закрывает окно редактирования
		/// </summary>
		void Close();

	}
}