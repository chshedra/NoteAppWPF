
namespace NoteApp.Application.WPF
{
	public class EditingNoteViewModel
	{
		/// <summary>
		/// Хранит значение редактируемой/создаваемой заметки
		/// </summary>
		private INoteViewModel _currentNote;

		/// <summary>
		/// Возвращает и устанавливает значение редактируемой/создаваемой заметки
		/// </summary>
		public INoteViewModel CurrentNote
		{
			get => _currentNote;
			set => _currentNote = value;
		}
		
		public INotesModel Notes { get; set; }


		public EditingNoteViewModel(INotesModel notesModel)
		{
			Notes = notesModel;
			CurrentNote = new NoteViewModel(notesModel.CurrentNote);
		}
	}

}