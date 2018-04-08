﻿using LiveUncertainty.classes;
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
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.SeriesAlgorithms;
using System.Xml.Serialization;
using System.Windows;
using System.Windows.Media;

namespace LiveUncertainty.viewmodels
{
    public class USMViewModel : INotifyPropertyChanged
    {
        public UpdateStringCommand _Update { get; set; }
        public LoadCommand _Load { get; set; }
        public LoadCommand _Load2 { get; set; }
        public SaveCommand _SaveCommand { get; set; }
        public CalculateCommand _CalculateCommand { get; set; }
        public SeriesCollection col;
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
            this._Load2 = new LoadCommand(this);
            this._CalculateCommand = new CalculateCommand(this);
            this.Meter.addPath(new classes.Path());
            this.Meter.addPath(new classes.Path());
            this.Meter.addPath(new classes.Path());
            this.Meter.addPath(new classes.Path());
            this.Meter.addPath(new classes.Path());
            this.Meter.addPath(new classes.Path());
            Collection = new SeriesCollection
                {

                    new LineSeries()
                    {
                        Title= "GOV values",
                        Values = new ChartValues<double> { 20, 18, 16, 14, 12, 10, 9, 1,},
                        PointForeground = Brushes.Blue
                    }    

                };

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
                this.meter.Paths.Clear();
                var serializer = new XmlSerializer(typeof(UltraSonicMeter));
                UltraSonicMeter test = (UltraSonicMeter)serializer.Deserialize(file);
                this.meter.Tag = test.Tag;
                this.meter = test;
                MessageBox.Show("File was loaded. You are now using meter " + meter.Tag);
                this.meter.OnPropertyChanged("Tag");
                this.meter.AddPathLengths();
                this.meter.AddPathLengthsL();
                this.meter.AddPathWeightingFactors();
                this.meter.AddPathXValues();
                this.meter.AddPathChords();
                this.meter.AddPathAngles();
                this.meter.AddPathAngles_Degrees();
                this.meter.AddNoOfBounces();
                this.meter.AddPathChordsDividedbydDdry();


            } 
            catch(Exception ex)
            {
                MessageBox.Show("File was not loaded" + ex.ToString());
            }
            

        }

        public SeriesCollection Collection {
            get
            {
                return col;
            }

            set
            {
                col = value;
                OnPropertyChanged("Collection");
            }
        }
        public string[] Labels { get; set; }

        public void Calculate()
        {
            var valsvelocity = Meter.OperatingConditions.CalculateViv().GetEnumerator();
            ChartValues<double> chartvals = new ChartValues<double>();
            ChartValues<double> GOVvals = new ChartValues<double>();

            var valsGOV = Meter.CalculateGOVUncertainty().GetEnumerator();
            while (valsvelocity.MoveNext())
            {
                chartvals.Add(valsvelocity.Current);
            }

            while (valsGOV.MoveNext())
            {
                GOVvals.Add(valsGOV.Current);
            }
            Collection = new SeriesCollection
                {

                    new LineSeries()
                    {
                        Title= "GOV values",
                        Values = chartvals,
                        PointForeground = Brushes.Blue
                    }

                };
        }






    }
}
