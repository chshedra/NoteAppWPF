using System;
using System.Windows.Input;

namespace NoteAppWPF.Common
{

	//TODO: +XML комментарии?
	/// <summary>
	/// Команда с проверкой выполнения
	/// </summary>
	public class RelayCommand : ICommand
	{
		/// <summary>
		/// Делегат выполнения команды
		/// </summary>
		private Action<object> _execute;

		/// <summary>
		/// Делегат проверки выполнения 
		/// </summary>
		private Func<object, bool> _canExecute;

		/// <summary>
		/// Событие проверки выполнения команды
		/// </summary>
		public event EventHandler CanExecuteChanged
		{
			add => CommandManager.RequerySuggested += value;
			remove => CommandManager.RequerySuggested -= value;
		}

		/// <summary>
		/// Создает команду
		/// </summary>
		/// <param name="execute">Делегат выполнения</param>
		/// <param name="canExecute">Делегат проверки выполнения</param>
		public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
		{
			_execute = execute;
			_canExecute = canExecute;
		}

		/// <summary>
		/// Проверяет возможность выполнения команды
		/// </summary>
		/// <param name="parameter">Проверяемый параметр</param>
		public bool CanExecute(object parameter)
		{
			return _canExecute == null || _canExecute(parameter);
		}

		/// <summary>
		/// Выполняет команду
		/// </summary>
		/// <param name="parameter"></param>
		public void Execute(object parameter)
		{
			_execute(parameter);
		}
	}
}