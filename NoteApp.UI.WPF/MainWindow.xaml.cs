using System.Windows;
using System.Windows.Controls;
using NoteApp.Application.WPF.Model;
using NoteAppWPF.Services;
using NoteAppWPF.ViewModels;

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

			this.DataContext = new NotesViewModel(new NotesModel(), 
				new MessageBoxService(), new WindowService());

			NotesListBox.SelectedIndex = 0;
		}
	}
}
