using System;
using System.Windows.Input;

namespace PoemaDay.viewmodel.commands
{
    public class NavigationCommands : ICommand
    {
         public MainPageVM mainPageVM { get; set; }


        public NavigationCommands(MainPageVM mpvm)
        {
            mainPageVM = mpvm;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            mainPageVM.Navigate();
        }
    }
}
