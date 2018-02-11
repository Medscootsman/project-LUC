using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveUncertainty.classes
{
    class Analyser
    {
        public int analyserID;
        public string tagNum;
        public double range;
        public string manufacturer;
        public string model;
        public string sigOutput; //signal output
        public double calFrequency; //calibration frequency
        public double recalTolerance; //re-calibration tolerance

        public Analyser()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public string TagNum
        {
            get
            {
                return tagNum;
            }

            set
            {
                tagNum = value;
            }
        }

        public int ID
        {
            get
            {
                return analyserID;
            }

            set
            {
                analyserID = value;
            }
        }

        public double Range
        {
            get
            {
                return range;
            }

            set
            {
                range = value;
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

        public string Model
        {
            get
            {
                return model;
            }

            set
            {
                model = value;
            }
        }

        public string SigOutput
        {
            get
            {
                return sigOutput;
            }

            set
            {
                sigOutput = value;
            }
        }

        public double CalculationFrequency
        {
            get
            {
                return calFrequency;
            }

            set
            {
                calFrequency = value;
            }
        }

        public double RecalibrationTolerance
        {
            get
            {
                return recalTolerance;
            }

            set
            {
                recalTolerance = value;
            }
        }

    }

    class Densitometer : Analyser {
        public Densitometer()
        {

        }
    }

    class Cromatograph : Analyser
    {
        public Cromatograph()
        {

        }
    }

    class RD_Analsyer : Analyser
    {
        public RD_Analsyer()
        {

        }
    }

}
