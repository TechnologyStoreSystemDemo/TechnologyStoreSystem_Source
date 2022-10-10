using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModels.Commands
{
    public class RelayCommands<T> : ICommand
    {
        private readonly Action<T> _executeAction;
        private readonly Predicate<T> _canExecuteAction;

        public RelayCommands(Action<T> executeAction) : this(executeAction, null!) { }

        public RelayCommands(Action<T> executeAction, Predicate<T> canExecuteAction) => (_executeAction, _canExecuteAction) = (executeAction, canExecuteAction);

        event EventHandler? ICommand.CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        bool ICommand.CanExecute(object? parameter) => _canExecuteAction == null ? true : _canExecuteAction((T)parameter!);
        void ICommand.Execute(object? parameter) => _executeAction((T)parameter!);
    }
}
