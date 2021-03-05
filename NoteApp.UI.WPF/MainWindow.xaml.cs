using System.Windows;
using NoteApp.Application.WPF;

namespace NoteAppWPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private NotesModel _notesModel;
		public MainWindow()
		{
			InitializeComponent();

			_notesModel = new NotesModel();
			this.DataContext = new NotesViewModel(_notesModel);
			NotesListBox.SelectedIndex = 0;
		}

		private void EditButton_Click(object sender,
			RoutedEventArgs e)
		{ 
			EditWindow editWindow = new EditWindow(_notesModel);
			editWindow.Show();
		}
	}
}
