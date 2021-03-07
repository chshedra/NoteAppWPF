
using System;
using System.Collections;
using System.Linq;
using NoteApp.DataAccess;
using NoteAppWPF;

namespace NoteAppWPF.ViewModels
{
	public class EditingNoteViewModel
	{
		/// <summary>
		/// Хранит значение редактируемой/создаваемой заметки
		/// </summary>
		private INoteViewModel _currentNote;

		/// <summary>
		/// Хранит команду успешного завершения операции с заметкой
		/// </summary>
		private RelayCommand _okCommand;

		/// <summary>
		/// Хранит команду отмены операции с заметкой
		/// </summary>
		private RelayCommand _cancelCommand;

		/// <summary>
		/// Возвращает и устанавливает значение редактируемой/создаваемой заметки
		/// </summary>
		public INoteViewModel CurrentNote
		{
			get => _currentNote;
			set => _currentNote = value;
		}

		/// <summary>
		/// Возвращает список категорий
		/// </summary>
		public IEnumerable Categories =>
			Enum.GetValues(typeof(NoteCategory)).Cast<NoteCategory>();

		/// <summary>
		/// Возвращает и устанавливает флаг, приняты ли внесенные изменения
		/// </summary>
		public bool IsChangesAccepted { get; set; }

		/// <summary>
		/// Возвращает команду успешного завершения операции с заметкой
		/// </summary>
		public RelayCommand OkCommand
		{
			get
			{
				return _okCommand ??
				       (_okCommand = new RelayCommand(obj =>
				       {
						   CurrentNote.Modified = DateTime.Now;
						   IsChangesAccepted = true;
						   var window = obj as EditWindow;
						   window.Close();
				       }));
			}
		}

		/// <summary>
		/// Возвращает команду отмены операции с заметкой
		/// </summary>
		public RelayCommand CancelCommand
		{
			get
			{
				return _cancelCommand ??
				       (_cancelCommand = new RelayCommand(obj =>
				       {
						   IsChangesAccepted = false;
					       ((EditWindow)obj).Close();
				       }));
			}
		}

		/// <summary>
		/// Устанавливает значение списка заметок и текущей заметки для модели представления
		/// </summary>
		/// <param name="notesModel"></param>
		public EditingNoteViewModel(INoteViewModel note)
		{
			CurrentNote = note;

			EditWindow editWindow = new EditWindow
			{
				DataContext = this
			};

			editWindow.ShowDialog();
		}
	}

}