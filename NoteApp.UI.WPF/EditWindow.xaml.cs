using System.Windows;
using NoteApp.Application.WPF;


namespace NoteAppWPF
{
	/// <summary>
	/// Interaction logic for EditWindow.xaml
	/// </summary>
	public partial class EditWindow : Window
	{
		public EditWindow(INotesModel notesModel)
		{
			InitializeComponent();

			DataContext = new EditingNoteViewModel(notesModel);
		}
	}
}
