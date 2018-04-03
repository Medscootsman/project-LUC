using LiveUncertainty.classes;
using LiveUncertainty.viewmodels.commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace LiveUncertainty.viewmodels
{
    public class USMViewModel : INotifyPropertyChanged
    {
        public UpdateStringCommand _Update { get; set; }
        public LoadCommand _Load { get; set; }
        public SaveCommand _SaveCommand { get; set; }
        public UltraSonicMeter meter;
        /// <summary>
        /// Creates a view model for manipulating the object
        /// </summary>
        /// <param name="meter"></param>
        /// 
        public UltraSonicMeter Meter
        {
            get { return meter; }
            set => meter = value;

        }
        public USMViewModel()
        {
            this._Update = new UpdateStringCommand(this);
            meter = new UltraSonicMeter();
            this._SaveCommand = new SaveCommand(this);
            this._Load = new LoadCommand(this);
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

        public string NotifySucess()
        {
            return "Save sucessful";
        }

        public void LoadFile(FileStream file)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(UltraSonicMeter));
                this.meter = (UltraSonicMeter)serializer.Deserialize(file);
                
                MessageBox.Show("File was loaded. You are now using meter " + meter.Tag);

            } 
            catch
            {
                MessageBox.Show("File was not loaded");
            }
            

        }






    }
}
