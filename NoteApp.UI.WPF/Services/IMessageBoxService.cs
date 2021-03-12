using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteAppWPF.Services
{
	public interface IMessageBoxService
	{
		bool Show(string message, string caption);
	}
}
