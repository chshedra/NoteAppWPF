using System.ComponentModel;

namespace NoteAppWPF
{
	//TODO: Правильнее нотифаер и релейкоманду переместить в отдельную папку или вообще отдельную сборку.
	//TODO: Зачем нужна эта сущность и почему она не абстрактная?
	//TODO: XML комментарии?
	public class Notifier : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler
			PropertyChanged = delegate { };

		protected void NotifyPropertyChanged(string propertyName)
		{
			PropertyChanged(this,
				new PropertyChangedEventArgs(
					propertyName));
		}
	}
}