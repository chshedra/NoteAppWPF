﻿using System.Windows;

namespace NoteAppWPF.Services
{
	/// <inheritdoc/>
	public class MessageBoxService : IMessageBoxService
	{
		/// <inheritdoc/>
		public bool Show(string message, string caption) =>
			MessageBox.Show(message, caption,
				MessageBoxButton.OKCancel) == MessageBoxResult.OK;
	}
}