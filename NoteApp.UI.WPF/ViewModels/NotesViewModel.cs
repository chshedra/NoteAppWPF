using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Sockets;
using System.Windows.Input;
using NoteApp.DataAccess;
using NoteAppWPF;

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
		/// Хранит модель представления окна редактирования
		/// </summary>
		private EditingNoteViewModel _editingNoteViewModel;

		/// <summary>
		/// Хранит значение выбранной заметки
		/// </summary>
		private INoteViewModel _selectedNote;

		/// <summary>
		/// Хранит выбранную категорию 
		/// </summary>
		private NoteCategory _selectedCategory;

		/// <summary>
		/// Хранит команду добавления заметки
		/// </summary>
		private RelayCommand _addNoteCommand;

		/// <summary>
		/// Хранит команду удаления заметки
		/// </summary>
		private RelayCommand _removeNoteCommand;

		/// <summary>
		/// Возвращает список заметок из модели
		/// </summary>
		public ObservableCollection<Note> SelectedNotes { get; set; }

		/// <inheritdoc/>
		public INoteViewModel SelectedNote
		{
			get => _selectedNote;

			set
			{
				if (((NoteViewModel)value).Created == DateTime.MinValue)
				{
					_selectedNote = value;
				}
				else
				{
					_selectedNote = new NoteViewModel(value);
					NotifyPropertyChanged(SELECTED_NOTE_PROPERTY_NAME);
					_model.CurrentNote = _selectedNote.ConvertToNote();
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
				{
					return;
				}

				Note note = GetProject(value);
				SelectedNote.Update(note);
				_model.CurrentNote = note;
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
			SelectedCategory = NoteCategory.All;
		}

		/// <summary>
		/// Возвращает команду добавления новой заметки
		/// </summary>
		public RelayCommand AddNoteCommand
		{
			get
			{
				return _addNoteCommand ??
				       (_addNoteCommand = new RelayCommand(obj =>
				       {
					       _editingNoteViewModel = new EditingNoteViewModel(new NoteViewModel(new Note()));

					       _model.Notes.Add(_editingNoteViewModel.CurrentNote.ConvertToNote());

					       SelectedValue = _editingNoteViewModel.CurrentNote.Created;
				       }));
			}
		}


		/// <summary>
		/// Возвращает команду удаления выбранной заметки
		/// </summary>
		public RelayCommand RemoveCommand
		{
			get
			{
				return _removeNoteCommand ??
				       (_removeNoteCommand = new RelayCommand(obj =>
				       {
					       _model.Notes.Remove(_model.CurrentNote);
					       if (_model.Notes.Count != 0)
					       {
						       SelectedNote =new NoteViewModel(_model.Notes[0]);
						       _model.CurrentNote = _model.Notes[0];
					       }
				       }));
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