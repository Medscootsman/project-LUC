using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Maps a cromatograph for a metering system.
/// </summary
/// >
namespace LiveUncertainty.classes
{
    public class Cromatograph
    {
        public string tagNum;
        public double range;
        public string manufacturer;
        public string model;
        public int sigOutput; //Signal Output
        public double calFrequency; //Calibration Frequency
        public double reCalTolerance; //re-calibration tolerance

        public Cromatograph()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}