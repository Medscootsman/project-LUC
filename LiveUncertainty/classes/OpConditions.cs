using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveUncertainty.classes
{
    class OperatingConditions
    {
        public double opPressure;
        public double opTemperature;
        public double opDensity;
        public double baseDensity;
        public double refTemperature;
        public double refPressure;
        public bool PTZ_calc;
        public double maxMassFlow;
        public double maxGOVFlow;
        public Int16 measurementType;
        public OperatingConditions()
        {

        }
    }
}
