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
        public UpdateStringCommand _Update { get; set; }
        public SaveCommand _SaveCommand { get; set; }
        public UltraSonicMeter meter;
        /// <summary>
        /// Creates a view model for manipulating the object
        /// </summary>
        /// <param name="meter"></param>
        /// 

        public USMViewModel()
        {
            this._Update = new UpdateStringCommand(this);
            meter = new UltraSonicMeter();
            this._SaveCommand = new SaveCommand(this);
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

        public void Save()
        {
            this.meter.SaveFile(true);
            this.meter.SaveStatus = "Save Sucessful";
            OnPropertyChanged("SaveStatus");
        }

        public void UpdateInteger(int i)
        {

        }

        public void UpdateDouble(double dub)
        {

        }
        public string NotifySucess()
        {
            return "Save sucessful";
        }





    }
}
