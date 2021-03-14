using System;
using System.ComponentModel;
using NoteApp.Application.WPF;
using NoteApp.DataAccess;

namespace NoteAppWPF.ViewModels
{
	/// <inheritdoc cref="INotesViewModel"/>
	public class NoteViewModel : Notifier, INoteViewModel, IDataErrorInfo
	{
		/// <summary>
		/// Хранит значение заголовка выбранной заметки
		/// </summary>
		private string _title;

		/// <summary>
		/// Хранит значение текста выбранной заметки
		/// </summary>
		private string _text;

		/// <summary>
		/// Хранит значение категории выбранной заметки
		/// </summary>
		private NoteCategory _category;

		/// <summary>
		/// Хранит значение времени создания выбранной заметки
		/// </summary>
		private DateTime _created;

		/// <summary>
		/// Хранит значение времени изменения выбранной заметки
		/// </summary>
		private DateTime _modified;

		/// <summary>
		/// Возвращает и устанавливает заголовок  выбранной заметки
		/// </summary>
		public string Title
		{
			get => _title;

			set
			{
				_title = value;
				NotifyPropertyChanged(nameof(Title));
			}
		}

		/// <summary>
		/// Возвращает и устанавливает текст выбранной заметки
		/// </summary>
		public string Text
		{
			get => _text;
			set
			{
				_text = value;
				NotifyPropertyChanged(nameof(Text));
			}
		}

		/// <summary>
		/// Возвращает и устанавливает категорию выбранной заметки
		/// </summary>
		public NoteCategory Category
		{
			get => _category; 
			set
			{
				_category = value;
				NotifyPropertyChanged(nameof(Category));
			}
		}

		/// <summary>
		/// Возвращает и устанавливает время создания выбранной заметки
		/// </summary>
		public DateTime Created
		{
			get => _created;

			set
			{
				_created = value;
				NotifyPropertyChanged(nameof(Created));
			}
		}

		/// <summary>
		/// Возвращает и устанавливает время изменения выбранной заметки
		/// </summary>
		public DateTime Modified
		{
			get => _modified; 

			set
			{
				_modified = value;
				NotifyPropertyChanged(nameof(Modified));
			}
		}

		/// <summary>
		/// Устанавливает значение заметки модели-представления
		/// </summary>
		/// <param name="note">Значение выбранной заметки</param>
		public NoteViewModel(INote note)
		{
			if (note == null)
			{
				return;
			}

			Update(note);
		}

		public string this[string columnName]
		{
			get
			{
				string error = String.Empty;
				switch (columnName)
				{
					case nameof(Title):
						if (Title.Length > 50)
						{
							return "Размер заголовка должен быть не более 50 символов";
						}
						break;
				}
				return error;
			}
		}
		public string Error => throw new NotImplementedException();

		/// <summary>
		/// Обновляет свойства выбранной заметки
		/// </summary>
		/// <param name="note"></param>
		public void Update(INote note)
		{
			Title = note.Title;
			Text = note.Text;
			Category = note.Category;
			Created = note.Created;
			Modified = note.Modified;
		}

		/// <inheritdoc/>
		public Note ConvertToNote() => 
			new Note(this.Title, this.Text, this.Category, this.Created, this.Modified);

		/// <inheritdoc/>
		public object Clone()
		{
			return this.MemberwiseClone();
		}
	}
}
