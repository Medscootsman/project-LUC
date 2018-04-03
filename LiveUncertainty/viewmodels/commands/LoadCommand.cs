using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace LiveUncertainty.viewmodels.commands
{
    public class LoadCommand : ICommand
    {
        USMViewModel meter;
        public LoadCommand(USMViewModel _meter)
        {
            this.meter = _meter;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            using (OpenFileDialog osd = new OpenFileDialog() { Filter = "lsav | LSAV", ValidateNames = true, CheckFileExists = true, Multiselect = false, })
            {
                if (osd.ShowDialog() == DialogResult.OK)

                    using (FileStream fs = File.Open(osd.FileName, FileMode.Open)) {
                        this.meter.LoadFile(fs);
                    }
                }
            }
        }
    }

