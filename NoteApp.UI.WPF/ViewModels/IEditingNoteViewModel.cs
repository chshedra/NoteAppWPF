namespace NoteAppWPF.ViewModels
{
	/// <summary>
	/// Модель представления окна редакирования
	/// </summary>
	public interface IEditingNoteViewModel
	{
		/// <summary>
		/// Устанавливает и возвращает значение обрабатываемой заметки
		/// </summary>
		INoteViewModel CurrentNote { get; set; }
	}
}