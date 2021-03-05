using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Sockets;
using System.Windows.Input;
using NoteApp.DataAccess;

namespace NoteApp.Application.WPF
{
	public class NotesViewModel : Notifier, INotesViewModel
	{
		/// <summary>
		/// Хранит имя свойства выбранной заметки
		/// </summary>
		public const string SELECTED_NOTE_PROPERTY_NAME = "SelectedNote";

		/// <summary>
		/// Хранит объект модели 
		/// </summary>
		private readonly INotesModel _model;

		/// <summary>
		/// Хранит значение выбранной заметки
		/// </summary>
		private INoteViewModel _selectedNote;

		/// <summary>
		/// Хранит выбранную категорию 
		/// </summary>
		private NoteCategory _selectedCategory;

		/// <summary>
		/// Возвращает список заметок из модели
		/// </summary>
		public ObservableCollection<Note> SelectedNotes { get; set; }

		/// <inheritdoc/>
		public INoteViewModel SelectedNote
		{
			get
			{
				return _selectedNote;
			}

			set
			{
				if (((NoteViewModel)value).Created == DateTime.MinValue)
				{
					_selectedNote = value;
				}
				else
				{
					if (_selectedNote == null)
					{
						_model.CurrentNote = (Note)_selectedNote;
						_selectedNote = new NoteViewModel(value);
						_selectedNote.Update(value);
						NotifyPropertyChanged(SELECTED_NOTE_PROPERTY_NAME);
					}
				}
			}
		}

		/// <summary>
		/// Устанвливает значение выбранной заметки из NotesListBox по
		/// дате создания
		/// </summary>
		public DateTime SelectedValue
		{
			set
			{
				if (value == DateTime.MinValue)
					return;
				Note note = GetProject(value);
				if (SelectedNote == null)
				{
					SelectedNote = new NoteViewModel(note);
				}
				else
				{
					SelectedNote.Update(note);
				}
			}
		}

		/// <summary>
		/// Возвращает и устанавливает значение выбранной категории
		/// </summary>
		public NoteCategory SelectedCategory
		{
			get => _selectedCategory;

			set
			{
				SelectedNotes = value == NoteCategory.All
					? SelectedNotes = _model.Notes
					: new ObservableCollection<Note>(_model.Notes.Where(note => note.Category == value)
						.Select(note => note));

				_selectedCategory = value;
				NotifyPropertyChanged("SelectedNotes");
				SelectedNote = new NoteViewModel(SelectedNotes[0]);
				NotifyPropertyChanged("SelectedNote");
			}
		}

		/// <summary>
		/// Возвращает список категорий
		/// </summary>
		public IEnumerable Categories => 
			 Enum.GetValues(typeof(NoteCategory)).Cast<NoteCategory>();
	
		/// <summary>
		/// Конструктор модели представления по модели
		/// </summary>
		/// <param name="notesModel">Объект модели</param>
		public NotesViewModel(INotesModel notesModel)
		{
			_model = notesModel;
			_model.NoteUpdated += model_ProjectUpdated;
			SelectedCategory = NoteCategory.All;
		}

		/// <inheritdoc/>
		public void UpdateNote()
		{
			_model.UpdateNote(SelectedNote);
		}

		/// <summary>
		/// Вызывает метод обновления выбранной заметки по команде
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void model_ProjectUpdated(object sender,
			NoteEventArgs e)
		{
			GetProject(e.Note.Created).Update(e.Note);
			if (SelectedNote != null
			    && e.Note.Created == SelectedNote.Created)
			{
				SelectedNote.Update(e.Note);
			}
		}

		/// <summary>
		/// Находит заметку по времени создания
		/// </summary>
		/// <param name="created"></param>
		/// <returns></returns>
		private Note GetProject(DateTime created)
		{
			return (from note in SelectedNotes
				where note.Created == created
				select note).FirstOrDefault();
		}
	}
}