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
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.SeriesAlgorithms;
using System.Xml.Serialization;
using System.Windows;
using System.Windows.Media;
using System.Reflection;

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
            set
            {
                meter = value;
                OnPropertyChanged("Meter");
            }

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

                this.meter.Internal_Diameter = test.Internal_Diameter;

                this.meter.OperatingConditions.OperatingDensity = test.OperatingConditions.OperatingDensity;
                this.meter.OperatingConditions.OperatingPressure = test.OperatingConditions.OperatingPressure;
                this.meter.OperatingConditions.OperatingTemperature = test.OperatingConditions.OperatingTemperature;
                this.meter.OperatingConditions.MaxFluidVelocity = test.OperatingConditions.MaxFluidVelocity;


                this.meter.PathsTotal = test.PathsTotal;

                this.meter.TargetUncertainty = test.TargetUncertainty;

                this.meter.MetrologyTemperature = test.MetrologyTemperature;

                this.meter.Nominal_Diameter = test.Nominal_Diameter;

                this.meter.Tag = test.Tag;

                this.meter = test;

                OnPropertyChanged(string.Empty);

                this.meter.AddPathLengths();
                this.meter.AddPathLengthsL();
                this.meter.AddPathWeightingFactors();
                this.meter.AddXNormal();
                this.meter.AddPathChords();
                this.meter.AddPathAngles();
                this.meter.AddPathAngles_Degrees();
                this.meter.AddNoOfBounces();
                this.meter.AddPathChordsDividedbydDdry();
                MessageBox.Show("File was loaded. You are now using meter " + meter.Tag);

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
            List<double> chartvals = new List<double>();
            ChartValues<double> GOVvals = new ChartValues<double>();

            var valsGOV = Meter.CalculateGOVUncertainty();
            
            //reverse the order.
            valsGOV.Reverse();
            var valsenum = valsGOV.GetEnumerator();
            while (valsvelocity.MoveNext())
            {

                chartvals.Add(valsvelocity.Current);
            }

            while (valsenum.MoveNext())
            {
                GOVvals.Add(valsenum.Current);
            }
            Collection = new SeriesCollection

            {

                new LineSeries()
                {
                    Title="GOV Uncertainty",
                    Values = GOVvals,
                }


            };

            //get string representation of charvals

        }
    }
}
