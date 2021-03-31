using System;
using System.Collections.ObjectModel;
using System.Linq;
using NoteApp.DataAccess;

namespace NoteApp.Application.WPF.Model
{
	/// <inheritdoc/>
	public class NotesModel : INotesModel
	{
		/// <inheritdoc/>
		public ObservableCollection<Note> Notes { get; private set; }

		/// <inheritdoc/>
		public Note CurrentNote { get; set; }

		/// <summary>
		/// Создает объект модели и загружает данные из хранилища
		/// </summary>
		public NotesModel()
		{
			Notes = new ObservableCollection<Note>();

			var project = ProjectManager.LoadFromFile(ProjectManager.DefaultPath);

			CurrentNote = project.CurrentNote;
			foreach (Note note in project.Notes)
			{
				Notes.Add(note);
			}
		}

		/// <summary>
		/// Сортирует список заметок по времени изменения
		/// </summary>
		public void SortNotes()
		{
			Notes = new ObservableCollection<Note>(Notes.
				OrderByDescending(note => note.Modified));
		}
	}
}