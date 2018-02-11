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
        public bool ptz_calc;
        public double maxMassFlow;
        public double maxGOVFlow;
        public Int16 measurementType;

        public OperatingConditions()
        {

        }

        //getters and setters. All attributes will be assigned this way.

        public double OperatingPressure
        {
            get
            {
                return opPressure;
            }

            set
            {
                opPressure = value;
            }
        }

        public double OperatingTemperature
        {
            get
            {
                return opTemperature;
            }

            set
            {
                opTemperature = value;
            }
        }

        public double OperatingDensity
        {
            get
            {
                return opDensity;
            }

            set
            {
                opDensity = value;
            }
        }

        public double BaseDensity
        {
            get
            {
                return baseDensity;
            }

            set
            {
                baseDensity = value;
            }
        }

        public double ReferenceTemperature
        {
            get
            {
                return refTemperature;
            }

            set
            {
                refTemperature = value;
            }
        }

        public double ReferencePressure
        {
            get
            {
                return refPressure;
            }

            set
            {
                refPressure = value;
            }
        }

        public bool PTZ_CalcUsed
        {
            get
            {
                return ptz_calc;
            }

            set
            {
                ptz_calc = value;
            }
        }

        public double MaxMassFlow
        {
            get
            {
                return maxMassFlow;
            }

            set
            {
                maxMassFlow = value;
            }
        }

        public double MaxGOVFlow
        {
            get
            {
                return maxGOVFlow;
            }

            set
            {
                maxGOVFlow = value;
            }
        }

        public Int16 MeasurementType
        {
            get
            {
                return measurementType;
            }

            set
            {
                measurementType = value;
            }
        }


    }
}
