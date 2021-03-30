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
			//TODO: +У многих контролов дублируются марджины и другие свойства, может убрать дублирование в стили?
			InitializeComponent();

			this.DataContext = editingNoteViewModel;
		}
	}
}
