using System.ComponentModel;

namespace NoteAppWPF.Services
{
    //TODO: Правильнее нотифаер и релейкоманду переместить в отдельную папку или вообще отдельную сборку.
    //TODO: Зачем нужна эта сущность и почему она не абстрактная?
    //TODO: XML комментарии?
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