using System;
using NoteApp.DataAccess;

namespace NoteApp.Application.WPF
{
	//TODO: Почему не используется?
	/// <summary>
	/// Аргументы события изменения заметки
	/// </summary>
	public class NoteChangedEventArgs : EventArgs
	{
		//TODO: Нужен паблик сет?
		/// <summary>
		/// Измененная заметка
		/// </summary>
		public INote Note { get; set; }

		/// <summary>
		/// Устанавливает значение измененной заметки в аргументы
		/// </summary>
		/// <param name="note">Измененная заметка</param>
		public NoteChangedEventArgs(INote note)
		{
			Note = note;
		}
	}
}