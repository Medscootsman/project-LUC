using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
/// <summary>
/// USM Path. Can only be initialized by a USM object.
/// </summary>
/// 
namespace LiveUncertainty.classes
{
    public class Path : INotifyPropertyChanged, IDataErrorInfo
    {
        public Double length;
        public Double offset; //chords
        public Double x;
        public Double angle;
        public bool weightingFactorUse;
        public double weightingFactor;
        public uint bounces;

        public Path()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public string this[string columnName]
        {
            get
            {
                switch(columnName)
                {
                    case "Length":
                        if(double.IsNaN(Length) || Length < 0)
                        {
                            Error = "Length cannot be negative";
                            break;
                        }
                        else
                        {
                            Error = null;
                            break;
                        }

                    case "Angle":
                        if (double.IsNaN(Angle) || Angle < 0)
                        {
                            Error = "Angle cannot be negative";
                            break;
                        }
                        else
                        {
                            Error = null;
                            break;
                        }

                    case "X":
                        if (double.IsNaN(X) || X < 0)
                        {
                            Error = "Angle cannot be negative";
                            break;
                        }
                        else
                        {
                            Error = null;
                            break;
                        }

                    case "Chords":
                        if (double.IsNaN(Chord) || Chord < 0)
                        {
                            Error = "Offset/Chord cannot be negative";
                            break;
                        }
                        else
                        {
                            Error = null;
                            break;
                        }
                }
                return Error;
            }
        }

        public double Length
        {
            get
            {
                return length;
            }

            set
            {
                length = value;
                OnPropertyChanged("Length");
            }
        }

        public double Chord
        {
            get
            {
                return offset;
            }

            set
            {
                offset = value;
                OnPropertyChanged("offset");
            }
        }

        public double X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
                OnPropertyChanged("x");
            }
        }

        public double Angle
        {
            get
            {
                return angle;
            }

            set
            {
                angle = value;
                OnPropertyChanged("Angle");
            }
        }

        public double WeightingFactor
        {
            get
            {
                return weightingFactor;
            }

            set
            {
                weightingFactor = value;
                OnPropertyChanged("WeightingFactor");
            }
        }

        public uint Bounces
        {
            get
            {
                return bounces;
            }

            set
            {
                if (value > 2)
                {
                    bounces = 2;
                }
                
                else
                {
                    bounces = value;
                    OnPropertyChanged("Bounces");
                }
            }
        }
    
        public string Error
        {
            get;
            set;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}