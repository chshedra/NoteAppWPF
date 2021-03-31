using System.Windows;
using NoteApp.Application.WPF;
using NoteAppWPF.ViewModels;


namespace NoteAppWPF
{
	/// <summary>
	/// Interaction logic for EditWindow.xaml
	/// </summary>
	public partial class EditWindow : Window
	{
		public EditWindow(IEditingNoteViewModel editingNoteViewModel)
		{
			InitializeComponent();

			this.DataContext = editingNoteViewModel;
		}
	}
}
