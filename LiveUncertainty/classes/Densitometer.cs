using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Summary description for Class1
/// </summary>
namespace LiveUncertainty.classes
{
    public class Densitometer
    {
        public string tagNum;
        public double range;
        public string manufacturer;
        public string model;
        public string sigOutput; //signal output
        public double calFrequency; //calibration frequency
        public double recalTolerance; //re-calibration tolerance

        public Densitometer()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}