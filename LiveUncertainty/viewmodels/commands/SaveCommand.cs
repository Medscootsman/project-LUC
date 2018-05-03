using LiveUncertainty.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LiveUncertainty.viewmodels.commands
{
    public class SaveCommand : ICommand
    {
        public USMViewModel Meter;
        public SaveCommand(USMViewModel meter)
        {
            this.Meter = meter;
        }

        public SaveCommand()
        {

        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Meter.Save();
        }
    }
}
