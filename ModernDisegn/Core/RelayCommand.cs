using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ModernDisegn.Core
{
    class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;
    }
}
