using System;
using NoteApp.DataAccess;

namespace NoteApp.Application.WPF
{
	/// <summary>
	/// Аргументы события изменения заметки
	/// </summary>
	public class NoteEventArgs : EventArgs
	{
		/// <summary>
		/// Измененная заметка
		/// </summary>
		public INote Note { get; set; }

		/// <summary>
		/// Устанавливает значение измененной заметки в аргументы
		/// </summary>
		/// <param name="note">Измененная заметка</param>
		public NoteEventArgs(INote note)
		{
			Note = note;
		}
	}
}