using System;
using System.Collections.ObjectModel;
using System.Linq;
using NoteApp.DataAccess;

namespace NoteApp.Application.WPF.Model
{
	/// <inheritdoc/>

	public class NotesModel : INotesModel
	{
		//TODO: +Автосвойство?
		/// <inheritdoc/>
		public ObservableCollection<Note> Notes { get; set; }

		/// <inheritdoc/>
		public Note CurrentNote { get; set; }

		/// <summary>
		/// Создает объект модели и загружает данные из хранилища
		/// </summary>
		public NotesModel()
		{
			Notes = new ObservableCollection<Note>();

			var project = ProjectManager.LoadFromFile(ProjectManager.DefaultPath);

			//TODO: +Неплохо, загружаем проект 2 раза...
			CurrentNote = project.CurrentNote;
			foreach (Note note
				in project.Notes)
			{
				Notes.Add(note);
			}
		}

		public void SortNotes()
		{
			Notes = new ObservableCollection<Note>(Notes.OrderByDescending(note => note.Created));
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