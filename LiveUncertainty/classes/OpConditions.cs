using System;
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
        public double maximumfluidvelocity;
        public double kappa;
        public double viscosity;
        public double zCompressibility;
        public double baseCompressibility;
        public double moleWeight;

        //Velocity of sound
        double kf = 1.3;

        //velocity and steps.
        int velocityIncrementStep;

        double lowestVelocityIncrementStep;

        int velocityForStepChangeOver;

        int stepChangeOver;

        public Int16 measurementType;

        public OperatingConditions()
        {

        }

        //getters and setters. All attributes will be assigned this way.

        public int VelocityIncrementStep
        {
            get => velocityIncrementStep;

            set => velocityIncrementStep = value;
        }

        public double LowestVelocityIncrementStep
        {
            get => lowestVelocityIncrementStep;

            set => lowestVelocityIncrementStep = value;
        }

        public int VelocityForStepChangeOver
        {
            get => velocityForStepChangeOver;

            set => velocityForStepChangeOver = value;
        }

        public int StepChangeOver
        {
            get => stepChangeOver;

            set => stepChangeOver = value;
        }


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

        public double MaxFluidVelocity
        {
            get
            {
                return maximumfluidvelocity;
            }

            set
            {
                maximumfluidvelocity = value;
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

        /// <summary>
        /// Convert operating pressure to "SI and absolute" (small pf)
        /// </summary>
        /// <returns>Returns the operating pressure multiplied by 10 to the power of 5</returns>

        public double CalculateSIAbsoluteOperatingPressure() //pf
        {
            double correctedOpPressure = this.OperatingPressure * Math.Pow(10, 5);

            return correctedOpPressure;

        }

        //hopefully this should be the same.
        /// <summary>
        /// Pf Capitalized corrects to SI Absolute by adding 1.01325.
        /// </summary>
        /// <returns></returns>
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

        public double CalculatePM()
        {
            return this.OperatingPressure + 1.01325;
        }

        public double calculateVelocityofSound()
        {
            double Pf = CalculateSIAbsoluteOperatingPressureConverted();
            double pf = CalculateSIAbsoluteOperatingPressure();
            double vosfResult = Math.Sqrt((kf * Pf) / pf);

            return vosfResult;
        }

        //Gas Flow Velocity Increments.

        /// <summary>
        /// Rounds the Maximum fluid Velocity. (vmax)
        /// </summary>
        /// <returns>returns rounded fluid velocity</returns>
        public int RoundFluidVelocity()
        {
            double fluidrounded = Math.Round(this.maximumfluidvelocity);

            int roundedmfv = (int)fluidrounded;

            return roundedmfv;
        }

        /// <summary>
        /// Calculates the next increment
        /// </summary>
        /// <returns></returns>
        public double CalculatenextVelocityIncrement()
        {
            double vnext = RoundFluidVelocity() - VelocityIncrementStep;

            return vnext;
        }

        public double CalculateStepChangeOverIX()
        {
            double ix = Math.Truncate((double)(RoundFluidVelocity() - VelocityForStepChangeOver) / VelocityIncrementStep);

            return ix;
        }

        public double CalcuateStepChangeOverIY()
        {
            double iy = Math.Truncate(VelocityForStepChangeOver - LowestVelocityIncrementStep / StepChangeOver);
            return iy;
        }

        public int CalculateIV()
        {
            return (int)CalculateStepChangeOverIX() + (int)CalcuateStepChangeOverIY();
        }

        /// <summary>
        /// Calculates the velocity steps (for the graph)
        /// </summary>
        /// <returns></returns>
        public List<double> CalculateViv() 
        {
            List<double> Viv = new List<double>();

            for(int i = 0; i < CalculateIV(); i++)
            {
                double val = RoundFluidVelocity() + (i - 1) * (CalculatenextVelocityIncrement() - RoundFluidVelocity());
                Viv.Add(val);
            }

            return Viv;

        }

        public List<double> CalculateWiv() 
        {
            List<int> wiv = new List<int>();

            for(int i = 0; i < CalculateIV(); i++)
            {
                int val = VelocityForStepChangeOver - ((i - 1) * (StepChangeOver));
                wiv.Add(val);
            }

            List<double> finalWiv = new List<double>();

            foreach(int val in wiv)
            {
                finalWiv.Add(val + CalculateStepChangeOverIX());
            }

            return finalWiv;
        }

       

    }
}