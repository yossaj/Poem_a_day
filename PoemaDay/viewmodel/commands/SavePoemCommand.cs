using System;
using System.Windows.Input;

namespace PoemaDay.viewmodel.commands
{
    public class SavePoemCommand : ICommand
    {
        public MainPageVM mainPageVM { get; set; }

        public SavePoemCommand(MainPageVM mpvm)
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
            mainPageVM.SaveCurrentPoem();
        }
    }
}
