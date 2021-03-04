using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
			EditWindow editWindow = new EditWindow();
			editWindow.DataContext
				= new NotesViewModel(_notesModel);
			editWindow.Owner = this;
			editWindow.Show();
		}
	}
}
