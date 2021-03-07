using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using NoteApp.Application.WPF;
using NoteApp.Application.WPF.Model;
using NoteApp.DataAccess;

namespace NoteAppWPF.ViewModels
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
		/// Хранит команду редактирования текущей заметки
		/// </summary>
		private RelayCommand _editNoteCommand;

		/// <summary>
		/// Хранит команду удаления заметки
		/// </summary>
		private RelayCommand _removeNoteCommand;

		/// <summary>
		/// Хранит команду выхода из приложения
		/// </summary>
		private RelayCommand _exitCommand;

		/// <summary>
		/// Хранит команду вызова информационного окна
		/// </summary>
		private RelayCommand _aboutWindowCommand;

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
		public Note SelectedValue
		{
			get => SelectedNote.ConvertToNote();

			set
			{
				if (value.Created == DateTime.MinValue)
				{
					return;
				}

				Note note = GetNote(value.Created);
				SelectedNote = new NoteViewModel(note);
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
						.Select(note => note).OrderByDescending(note => note.Created));

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

					       if (_editingNoteViewModel.IsChangesAccepted)
					       {
						       _model.Notes.Add(_editingNoteViewModel.CurrentNote.ConvertToNote());
						       SelectedValue = _editingNoteViewModel.CurrentNote.ConvertToNote();
						       UpdateNoteList();
					       }
				       }));
			}
		}

		/// <summary>
		/// Возвращает команду добавления новой заметки
		/// </summary>
		public RelayCommand EditNoteCommand
		{
			get
			{
				return _editNoteCommand ??
				       (_editNoteCommand = new RelayCommand(obj =>
				       {
						   var note = GetNote(SelectedNote.Created);
					       _editingNoteViewModel = new EditingNoteViewModel(SelectedNote);

					       if (_editingNoteViewModel.IsChangesAccepted)
					       {
						       var editingNoteIndex = SelectedNotes.IndexOf(note);
						       _model.Notes.Insert(editingNoteIndex + 1,
							       _editingNoteViewModel.CurrentNote.ConvertToNote());
							   SelectedNote = _editingNoteViewModel.CurrentNote;

						       _model.Notes.Remove(note);
							   UpdateNoteList();
					       }
				       }));
			}
		}


		/// <summary>
		/// Возвращает команду удаления выбранной заметки
		/// </summary>
		public RelayCommand RemoveNoteCommand
		{
			get
			{
				return _removeNoteCommand ??
				       (_removeNoteCommand = new RelayCommand(obj =>
				       {
						  if(MessageBox.Show("Do you really want remove this note?",
							   "Note removing", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
						   {
							   _model.Notes.Remove(_model.CurrentNote);
							   if (_model.Notes.Count != 0)
							   {
								   SelectedNote = new NoteViewModel(_model.Notes[0]);
								   _model.CurrentNote = _model.Notes[0];
							   }
						   }
				       }));
			}
		}

		/// <summary>
		/// Возвращает команду вызова информационного окна
		/// </summary>
		public RelayCommand AboutWindowCommand
		{
			get
			{
				return _aboutWindowCommand ??
				       (_aboutWindowCommand = new RelayCommand(obj =>
					       {
						       var window = new AboutWindow();
							   window.Show();
					       }
				       ));
			}
		}

		/// <summary>
		/// Возвращает команду закрытия приложения
		/// </summary>
		public RelayCommand ExitCommand
		{
			get
			{
				return _exitCommand ??
				       (_exitCommand = new RelayCommand(obj =>
				       {
					       ProjectManager.SaveToFile(new Project(_model.Notes.ToList(), _model.CurrentNote), 
						       ProjectManager.DefaultPath);

					       ((MainWindow)obj).Close();
				       }));
			}
		}

		/// <summary>
		/// Находит заметку по времени создания
		/// </summary>
		/// <param name="created"></param>
		/// <returns>Заметка по заданному времени создания</returns>
		private Note GetNote(DateTime created)
		{
			return (from note in SelectedNotes
				where note.Created == created
				select note).FirstOrDefault();
		}

		/// <summary>
		/// Обновляет список ListBox после изменений
		/// </summary>
		public void UpdateNoteList()
		{
			_model.SortNotes();

			if (SelectedCategory != NoteCategory.All)
			{
				SelectedNotes = new ObservableCollection<Note>(_model.Notes.
					Where(note => note.Category == SelectedCategory)
					.Select(note => note).OrderByDescending(note => note.Created));


			}
			else
			{
				SelectedNotes = _model.Notes;
			}
			NotifyPropertyChanged("SelectedNotes");
		}
	}
}