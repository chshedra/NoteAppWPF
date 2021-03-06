using NoteApp.DataAccess;

namespace NoteAppWPF.ViewModels
{
	/// <summary>
	/// Модель представления выьранной заметки
	/// </summary>
	public interface INoteViewModel : INote
	{
		/// <summary>
		/// Конверитирует модель представления заметки в объект заметки
		/// </summary>
		/// <returns>Конверитированная заметка</returns>
		Note ConvertToNote();
	}
}