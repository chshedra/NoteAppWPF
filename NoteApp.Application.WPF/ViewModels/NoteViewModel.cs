using System;
using NoteApp.DataAccess;

namespace NoteApp.Application.WPF
{
	/// <summary>
	/// Модель-представление выбранной заметки
	/// </summary>
	public class NoteViewModel : Notifier, INoteViewModel
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
			get { return _title;}

			set
			{
				_title = value;
				NotifyPropertyChanged("Title");
			}
		}

		/// <summary>
		/// Возвращает и устанавливает текст выбранной заметки
		/// </summary>
		public string Text
		{
			get { return _text;}
			set
			{
				_text = value;
				NotifyPropertyChanged("Text");
			}
		}

		/// <summary>
		/// Возвращает и устанавливает категорию выбранной заметки
		/// </summary>
		public NoteCategory Category
		{
			get { return _category; }
			set
			{
				_category = value;
				NotifyPropertyChanged("Category");
			}
		}

		/// <summary>
		/// Возвращает и устанавливает время создания выбранной заметки
		/// </summary>
		public DateTime Created
		{
			get { return _created; }
			set
			{
				_created = value;
				NotifyPropertyChanged("Created");
			}
		}

		/// <summary>
		/// Возвращает и устанавливает время изменения выбранной заметки
		/// </summary>
		public DateTime Modified
		{
			get { return _modified; }

			set
			{
				_modified = value;
				NotifyPropertyChanged("Modified");
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
			Created = note.Created;
			Update(note);
		}

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
	}
}
