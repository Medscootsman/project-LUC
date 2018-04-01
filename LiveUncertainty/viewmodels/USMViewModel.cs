using LiveUncertainty.classes;
using LiveUncertainty.viewmodels.commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LiveUncertainty.viewmodels
{
    public class USMViewModel : INotifyPropertyChanged
    {
        public UpdateStringCommand Update { get; set; }
        public UltraSonicMeter meter;
        /// <summary>
        /// Creates a view model for manipulating the object
        /// </summary>
        /// <param name="meter"></param>
        /// 

        public USMViewModel()
        {
            this.Update = new UpdateStringCommand(this);
            meter = new UltraSonicMeter();
        }

        public bool Updatable
        {
            get;
            set;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged( string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void UpdateString(string s)
        {
             
        }

        public void UpdateInteger(int i)
        {

        }

        public void UpdateDouble(double dub)
        {

        }





    }
}
