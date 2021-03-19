using System.ComponentModel;

namespace NoteAppWPF.Common
{
	//TODO:+ Правильнее нотифаер и релейкоманду переместить в отдельную папку или вообще отдельную сборку.
	//TODO:+Зачем нужна эта сущность и почему она не абстрактная?
	//TODO: +XML комментарии?
	/// <summary>
	/// Универсальный уведомитель об изменениях в свойстве
	/// </summary>
	public abstract class Notifier : INotifyPropertyChanged
	{
		/// <summary>
		/// Событие изменения свойства
		/// </summary>
		public event PropertyChangedEventHandler
			PropertyChanged = delegate { };

		/// <summary>
		/// Вызывает событие изменения свойства
		/// </summary>
		/// <param name="propertyName">Название измененного свойствва</param>
		protected void NotifyPropertyChanged(string propertyName)
		{
			PropertyChanged(this,
				new PropertyChangedEventArgs(
					propertyName));
		}
	}
}