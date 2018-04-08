using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LiveUncertainty.viewmodels.commands
{
    public class CalculateCommand : ICommand
    {
        public USMViewModel viewmodel;

        public CalculateCommand(USMViewModel model)
        {
            this.viewmodel = model;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if(string.IsNullOrEmpty(viewmodel.Meter.Error))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Execute(object parameter)
        {
            this.viewmodel.Calculate();
       
        }
    }
}
