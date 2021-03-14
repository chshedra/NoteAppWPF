namespace NoteAppWPF.ViewModels
{
	/// <summary>
	/// Хранит значение редактируемой/создаваемой заметки
	/// </summary>
	public interface IEditingNoteViewModel
	{
		/// <summary>
		/// Устанавливает и возвращает значение обрабатываемой заметки
		/// </summary>
		INoteViewModel CurrentNote { get; set; }
	}
}