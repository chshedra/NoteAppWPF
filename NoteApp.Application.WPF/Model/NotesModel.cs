using System;
using System.Collections.ObjectModel;
using System.Linq;
using NoteApp.DataAccess;

namespace NoteApp.Application.WPF.Model
{
	/// <inheritdoc/>

	public class NotesModel : INotesModel
	{
		//TODO: Автосвойство?
		private ObservableCollection<Note> _notes;

		/// <inheritdoc/>
		public ObservableCollection<Note> Notes
		{
			get => _notes;

			set => _notes = value;
		}

		/// <inheritdoc/>
		public Note CurrentNote { get; set; }

		/// <summary>
		/// Создает объект модели и загружает данные из хранилища
		/// </summary>
		public NotesModel()
		{
			_notes = new ObservableCollection<Note>();

			CurrentNote = ProjectManager.LoadFromFile(ProjectManager.DefaultPath).CurrentNote;
			foreach (Note note
				in ProjectManager.LoadFromFile(ProjectManager.DefaultPath).Notes)
			{
				_notes.Add(note);
			}
		}

		public void SortNotes()
		{
			Notes = new ObservableCollection<Note>(_notes.OrderByDescending(note => note.Created));
		}

		/// <summary>
		/// Получает заметку из списка по дате создания
		/// </summary>
		/// <param name="created">Искомая дата создвния</param>
		/// <returns>Найденная заметка</returns>
		private Note GetNote(DateTime created)
		{
			return Notes.FirstOrDefault(
				note => note.Created == created);
		}
	}
}