using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveUncertainty.classes
{
    public class FlowComputer
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
            }
        }
    }
}
