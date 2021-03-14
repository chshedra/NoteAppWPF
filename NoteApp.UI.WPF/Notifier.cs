using System.ComponentModel;

namespace NoteAppWPF.Services
{
	/// <summary>
	/// Уведомитель об изменениях свойств
	/// </summary>
	public class Notifier : INotifyPropertyChanged
	{
		/// <inheritdoc/>
		public event PropertyChangedEventHandler
			PropertyChanged = delegate { };

		/// <summary>
		/// Уведоьляет о измеенении свойства
		/// </summary>
		/// <param name="propertyName">Измененное свойство</param>
		protected void NotifyPropertyChanged(string propertyName)
		{
			PropertyChanged(this,
				new PropertyChangedEventArgs(
					propertyName));
		}
	}
}