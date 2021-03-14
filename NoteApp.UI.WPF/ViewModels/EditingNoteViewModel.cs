
using System;
using System.Collections;
using System.Linq;
using System.Windows;
using NoteApp.DataAccess;
using NoteAppWPF;
using NoteAppWPF.Services;

namespace NoteAppWPF.ViewModels
{
	/// <inheritdoc/>
	public class EditingNoteViewModel : IEditingNoteViewModel
	{
		/// <summary>
		/// Хранит значение редактируемой/создаваемой заметки
		/// </summary>
		private INoteViewModel _currentNote;

		/// <summary>
		/// Хранит объект сервиса вызова окна
		/// </summary>
		private IWindowService _windowService;

		/// <summary>
		/// Хранит объект сервиса вызова MessageBox
		/// </summary>
		private IMessageBoxService _messageBoxService;

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
					       var isError = (bool)obj;

					       if (isError)
					       {
						       _messageBoxService.Show("Title's length must be shorter, than 50 symbols",
							       "Warning");
					       }
					       else
					       {
						       CurrentNote.Modified = DateTime.Now;
						       IsChangesAccepted = true;
							   _windowService.Close();
					       }
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
						   _windowService.Close();
				       }));
			}
		}

		/// <summary>
		/// Устанавливает значение списка заметок и текущей заметки для модели представления
		/// </summary>
		/// <param name="notesModel"></param>
		public EditingNoteViewModel(INoteViewModel note, 
			IWindowService windowService, IMessageBoxService messageBoxService)
		{
			CurrentNote = note;
			_messageBoxService = messageBoxService;
			_windowService = windowService;

			_windowService.ShowNoteWindow(this);

		}
	}

}