namespace NoteAppWPF.ViewModels
{
	public interface IEditingNoteViewModel
	{
		/// <summary>
		/// Устанавливает и возвращает значение обрабатываемой заметки
		/// </summary>
		INoteViewModel CurrentNote { get; set; }
	}
}