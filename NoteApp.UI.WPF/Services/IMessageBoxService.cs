namespace NoteAppWPF.Services
{
	/// <summary>
	/// Сервис вызова MessageBox
	/// </summary>
	public interface IMessageBoxService
	{
		/// <summary>
		/// Вызывает MessageBox по заданным параметрам
		/// </summary>
		/// <param name="message">Сообщение MessageBox</param>
		/// <param name="caption">Заголовок MessageBox</param>
		/// <returns></returns>
		bool Show(string message, string caption);
	}
}
