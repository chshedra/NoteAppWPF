namespace NoteAppWPF.Services
{
	public class WindowService : IWindowService
	{
		public void Show()
		{
			AboutWindow window = new AboutWindow();
			window.Show();
		}
	}
}