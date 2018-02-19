﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveUncertainty.classes
{
    public class OperatingConditions
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
        public double kappa;
        public double viscosity;
        public double zCompressibility;
        public double baseCompressibility;
        public double moleWeight;

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

        //Convert reference pressure and temperature to "SI and absolute"
        public double calculateSIAbsoluteReferencePressure()
        {
            double correctedpref = this.ReferencePressure * Math.Pow(10, 5);
            return correctedpref;
        }

        //Convert reference pressure and temperature to "SI and absolute"
        public double CalculateSIAbsoluteReferenceTemperature()
        {
            double correctedptemp = this.ReferenceTemperature + 273.15; //273 is how much you need to add to correct it.
            return correctedptemp;
        }

        //Convert operating temperature to "SI and absolute"
        public double CalculateSIAbsoluteOperatingTemperature()
        {
            double correctedOpTemp = this.OperatingTemperature + 273.15;
            return correctedOpTemp;
        }

        //Convert operating pressure to "SI and absolute"
        public double CalculateSIAbsoluteOperatingPressure() //pf
        {
            double correctedOpPressure = this.OperatingPressure * Math.Pow(10, 5);

            return correctedOpPressure;

        }

        //hopefully this should be the same.

        public double CalculateSIAbsoluteOperatingPressureConverted() //Pf Capitalized
        {
            //add 1.01325 to the value.
            double correctedOpPressure = this.CalculateSIAbsoluteOperatingPressure() + 1.01325;

            return correctedOpPressure;
        }

        public double Base_compressibility
        {
            get
            {
                return baseCompressibility;
            }

            set
            {
                baseCompressibility = value;
            }
        }


    }
}
