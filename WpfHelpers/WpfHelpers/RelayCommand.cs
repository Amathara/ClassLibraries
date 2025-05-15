using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfHelpers
{
    internal class RelayCommand : ICommand
    {
        private Action<object> execute;// Function call
        private Func<object, bool> canExecute; // FUNK! returns value of the type specified by the bool parameter.
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            execute(parameter);
        }

        // Stuff to put in your window: (change "Car" for whatever item you are using)
        //public RelayCommand AddCommand => new RelayCommand(execute => AddCar());
        //public RelayCommand DeleteCommand => new RelayCommand(execute => DeleteCar(), canExecute => SelectedCar != null);
        //public RelayCommand SaveCommand => new RelayCommand(execute => Save(), canExecute => CanSave());
    }
}
