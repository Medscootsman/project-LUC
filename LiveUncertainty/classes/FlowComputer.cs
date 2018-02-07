using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveUncertainty.classes
{
    class FlowComputer
    {
        public string tagNo;
        public string manufacturer;
        public string type;
        public double calUncertainty;
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
