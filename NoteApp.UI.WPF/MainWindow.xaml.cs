using System.Windows;
using System.Windows.Controls;
using NoteApp.Application.WPF;

namespace NoteAppWPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			this.DataContext = new NotesViewModel(new NotesModel());
			NotesListBox.SelectedIndex = 0;
		}
	}
}
