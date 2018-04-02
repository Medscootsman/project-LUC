using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections;

namespace LiveUncertainty.classes
{
    public class FlowComputer : INotifyPropertyChanged, IDataErrorInfo
    {
        public string tagNo;
        public string manufacturer;
        public int manufactuerID;
        public string model;
        public string modelID;
        public string type;
        public int typeID;
        public double calUncertainty; //Calculation Uncertainty
        public FlowComputer()
        {
            //constructor logic tbc
        }

        public string TagNo
        {
            get
            {
                return tagNo;
            }
            set
            {
                tagNo = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return manufacturer;
            }

            set
            {
                manufacturer = value;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }
            
            set
            {
                type = value;
            }
        }

        public double Uncertainty
        {
            get
            {
                return calUncertainty;
            }

            set
            {
                calUncertainty = value;
                OnPropertyChanged("Uncertainty");
            }
        }

        public string Error
        {
            get;
            set;
        }


        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                switch(columnName)
                {
                    case "Uncertainty":
                        if(Uncertainty < 0)
                        {
                            Error = "Uncertainty cannot be negative";
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

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
