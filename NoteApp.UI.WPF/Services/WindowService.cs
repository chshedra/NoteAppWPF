using NoteAppWPF.ViewModels;

namespace NoteAppWPF.Services
{
	/// <inheritdoc cref="IWindowService"/>
	public class WindowService : IWindowService
	{
		/// <summary>
		/// Хранит объект окна редактирования
		/// </summary>
		private EditWindow _editWindow;

		/// <inheritdoc/>
		public bool NoteWindowResult { get; set; }

		/// <inheritdoc/>
		public void ShowAboutWindow()
		{
			AboutWindow aboutWindow = new AboutWindow();
			aboutWindow.Show();
		}

		/// <inheritdoc/>
		public bool? ShowNoteWindow(IEditingNoteViewModel editingNoteViewModel)
		{
			 _editWindow = new EditWindow(editingNoteViewModel);

			return _editWindow.ShowDialog();
		}

		public void Close()
		{
			_editWindow.Close();
		}

	}
}