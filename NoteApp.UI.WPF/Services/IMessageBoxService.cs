namespace NoteAppWPF.Services
{
	/// <summary>
	/// Сервис вызова MessageBox
	/// </summary>
	public interface IMessageBoxService
	{
		/// <summary>
		/// Реализует вызов MessageBox
		/// </summary>
		/// <param name="message">Сообщение MessageBox</param>
		/// <param name="caption">Заголовок MessageBox</param>
		/// <returns></returns>
		bool Show(string message, string caption);
	}
}
