using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LiveUncertainty.viewmodels.commands
{
    public class UpdateStringCommand : ICommand
    {
        public UpdateStringCommand(USMViewModel USM) {
            this.ViewModel = USM;
        }
        
        public USMViewModel ViewModel { get; set; }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return String.IsNullOrWhiteSpace(ViewModel.meter.Error);
        }

        public void Execute(object parameter)
        {
            this.ViewModel.ToString();
        }
    }
}
