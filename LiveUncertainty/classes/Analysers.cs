using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveUncertainty.classes
{
    class Analyser
    {
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
