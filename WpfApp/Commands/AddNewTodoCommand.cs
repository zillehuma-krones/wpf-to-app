using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp.Models;
using WpfApp.ViewModels;


namespace WpfApp.Commands
{

    public class AddNewTodoCommand : ICommand
    {
        private MainWindowViewModel _viewModel;

        public AddNewTodoCommand(MainWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Is used to raise the CanExecute Changed event forcefully, if not raised otherwise
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }


        public bool CanExecute(object parameter)
        {
          

            return (parameter != null && !String.IsNullOrWhiteSpace(parameter.ToString()));

        }

        public void Execute(object parameter)
        {

            _viewModel.NewTODOButton_Click();
        }
    }

}
