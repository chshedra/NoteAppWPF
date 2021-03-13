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
		/// <param name="message"></param>
		/// <param name="caption"></param>
		/// <returns></returns>
		bool Show(string message, string caption);
	}
}
