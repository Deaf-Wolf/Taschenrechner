using System;
using System.Windows.Input;

namespace Taschenrechner2.Core
{
    //RelayCommand adds flexibility 
    internal class RelayCommand : ICommand
    {
        private Action<object> _execute;
        private Func<object, bool> _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        //Constructor
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }



        public bool CanExecute(object parameter)
        {
            // checks if  _canExecute is Null or (parameter)
            return _canExecute == null || _canExecute(parameter);
        }
        /*
                   // Logical AND operation
                    true && true; // true
                    true && false; // false
                    false && true; // false
                    false && false; // false
        */
        /*
                    // Logical OR operation
                    true || true; // true
                    true || false; // true
                    false || true; // true
                    false || false; // false
        */

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
