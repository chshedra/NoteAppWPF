using System;
using System.Collections.ObjectModel;
using System.Linq;
using NoteApp.DataAccess;

namespace NoteApp.Application.WPF
{
	/// <inheritdoc/>

	public class NotesModel : INotesModel
	{
		/// <inheritdoc/>
		public ObservableCollection<Note> Notes { get; set; }

		/// <inheritdoc/>
		public Note CurrentNote { get; set; }

		/// <inheritdoc/>
		public event EventHandler<NoteEventArgs> NoteUpdated;

		/// <summary>
		/// Создает объект модели и загружает данные из хранилища
		/// </summary>
		public NotesModel()
		{
			Notes = new ObservableCollection<Note>();
			foreach (Note note
				in ProjectManager.LoadFromFile(ProjectManager.DefaultPath).Notes)
			{
				Notes.Add(note);
			}
		}

		/// <inheritdoc/>
		public void UpdateNote(INote updatedNote)
		{
			//GetNote(updatedNote.Created).Update(updatedNote);
			NoteUpdated(this,
				new NoteEventArgs(updatedNote));

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