using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LiveUncertainty.classes
{
    public class UltraSonicMeter
    {
        protected Int64 manufacturer_id;
        protected Int64 model_id;
        public Int16 pathsTotal;
        public Int16 signal_output;
        public double calFrequency; //calibration frequency.
        public double nomDiameter; //Nominal Diameter.
        public double internalDiameter; //Internal Diameter.
        public double boreDiameter;
        public double wallThickness;
        public double outerDiameter;
        public double metrologyTolerance;
        public bool wetCalibration;
        public double calLabUncertainty; //calibration lab uncertainty
        public double calTemperature; //Calibration Temperature
        public double calPressure; //Calibration Pressure;
        public bool metrologyData = true; //Always will be true (for now).
        public double transducerDistance;
        public double pathLengthTolerance;
        public double fluidPathTolerance;
        public double meterDiameterTolerance;

        protected double elasticity = 210 * Math.Pow(10, 9); // known as Yym on the mathcad sheet. supposed to be constant.
        private double coeff = 1.2 * Math.Pow(10, 5); //Coeff. of Linear Exp. (/°C)
        public const double thermalExpansion = 0.000011;
        private const double tmet = 20;

        public OperatingConditions opconditions;

        //Objects you will or may need.
        public List<Path> paths;
        public List<Double> pathLengthsL;
        public List<Double> pathXvals;
        public List<Double> pathChords;
        public List<Double> pathWeightingFactors;
        public List<Double> pathAngles;
        

        


        public UltraSonicMeter()
        {
        }

        protected Int64 ManufacturerID
        {
            get
            {
                return manufacturer_id;
            }
        }

        protected Int64 ModelID
        {
            get
            {
                return model_id;
            }
        }

        protected Int16 Paths
        {
            get
            {
                return pathsTotal;
            }

            set
            {
                pathsTotal = value;
            }
        }

        protected Int16 SignalOutput
        {
            get
            {
                return signal_output;
            }

            set
            {
                signal_output = value;
            }
        }

        protected double Calculation_Frequency
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

        protected double Nominal_Diameter
        {
            get
            {
                return nomDiameter;
            }

            set
            {
                nomDiameter = value;
            }
        }

        protected double Internal_Diameter
        {
            get
            {
                return internalDiameter;
            }

            set
            {
                internalDiameter = value;
            }
        }

        protected double Bore_Diameter
        {
            get
            {
                return boreDiameter;
            }

            set
            {
                boreDiameter = value;
            }
        }

        public double Wall_Thickness
        {
            get
            {
                return wallThickness;
            }
            set
            {
                wallThickness = value;
            }
        }

        public double Outer_Diameter
        {
            get
            {
                return outerDiameter;
            }
            set
            {
                outerDiameter = value;
            }
        }

        public double Metrology_Tolerance
        {
            get
            {
                return metrologyTolerance;
            }

            set
            {
                metrologyTolerance = value;
            }
        }

        public bool Wet_Calibration
        {
            get
            {
                return wetCalibration;
            }

            set
            {
                wetCalibration = value;
            }
        }

        public double Calibration_Lab_Uncertainty
        {
            get
            {
                return calLabUncertainty;
            }
            set
            {
                calLabUncertainty = value;
            }
        }

        public double Calibration_Temperature
        {
            get
            {
                return calTemperature;
            }
            set
            {
                calTemperature = value;
            }
        }

        public double Callibration_Pressure
        {
            get
            {
                return calPressure;
            }

            set
            {
                calPressure = value;
            }
        }

        public bool Metrology_Data
        {
            get
            {
                return metrologyData;

            }
            set
            {
                metrologyData = value;
            }
        }

        public double Transducer_Distance
        {
            get
            {
                return transducerDistance;
            }

            set
            {
                transducerDistance = value;
            }
        }

        public double Path_Length_Tolerance
        {
            get
            {
                return pathLengthTolerance;
            }
            set
            {
                pathLengthTolerance = value;
            }
        }

        public double Fluid_Path_Tolerance
        {
            get
            {
                return fluidPathTolerance;
            }

            set
            {
                fluidPathTolerance = value;
            }
        }

        public double Meter_Diameter_Tolerance
        {
            get
            {
                return meterDiameterTolerance;
            }

            set
            {
                meterDiameterTolerance = value;
            }
        }

        public OperatingConditions OperatingConditionsObject
        {
            get
            {
                return opconditions;
            }

            set
            {
                opconditions = value;
            }
        }

        //meter tube bore is calculated by dividing the internal diameter by 1000. (Mathcad reference: dDry)
        public double calculateMeterTubeBore()
        {
            double dDry = this.internalDiameter / 1000;
            return dDry;
        }

        //NOTE: outerdiameter and meterwallthickness can be 0, but 1 has to be filled in at one time.

        //Mathcad reference (tw)
        public double calculateMeterWallThickness()
        {

            double tw = 0; //metertubewallthickness
            if(wallThickness != 0)
            {
                tw = wallThickness / 1000;
            }
            else
            {
                //tw is outerDiameter multiplied by 10 to the power of 3 taken away by the metertubebore divided by 2.

                tw = (outerDiameter * Math.Pow(10, 3)) - this.calculateMeterTubeBore() / 2;
            }

            return tw;
        }

        public double calculateOuterDiameter()
        {
            double dOut = 0; //true outer diameter.
            if(outerDiameter != 0)
            {
                //this is bore plus 2 multiplied by meterwallthickness or tw
                dOut = calculateMeterTubeBore() + 2 * calculateMeterWallThickness();
            }
            else
            {
                dOut = outerDiameter / 1000;
            }

            return dOut;
        }

        
        public void addPath(Path path)
        {
            paths.Add(path);
            pathsTotal += 1;
        }

        public void addPathLengths()
        {
            pathLengthsL.Clear();
            foreach(Path pathobj in paths)
            {
                pathLengthsL.Add(pathobj.Length);
            }
        }

        public void AddPathAngles()
        {
            pathAngles.Clear();
            foreach(Path pathobj in paths)
            {
                pathAngles.Add(pathobj.Angle * Math.Pow(10, 3));
            }
        }

        public void AddPathChords() //offsets
        {
            pathChords.Clear();
            foreach(Path pathobj in paths)
            {
                pathChords.Add(pathobj.offset * (this.calculateMeterTubeBore() / 2));
            }

        }

        public void AddPathWeightingFactors()
        {
            pathWeightingFactors.Clear();
            foreach(Path pathobj in paths)
            {
                pathWeightingFactors.Add(pathobj.weightingFactor);
            }
        }

        public void AddPathXValues()
        {
            pathXvals.Clear();
            foreach(Path pathobj in paths)
            {
                pathXvals.Add(pathobj.x * Math.Pow(10, 3));
            }
        }

        //Convert the wet calibration values into SI + Absolute.

        public double CalculateSIAbsoluteCalibratedPressure() 
        {
            double correctedCalPressure = this.Callibration_Pressure * Math.Pow(10, 5);
            return correctedCalPressure;
        }

        public double CalculateSIAbsoluteCalibratedTemperature()
        {
            double correctedCalTemperature = this.Calibration_Temperature + 275.15;
            return correctedCalTemperature;
        }

        public double CalculateSIAbsoluteMetrologyTemperature()
        {
            double correctMetTemperature = 20 + 273.15;
            return correctMetTemperature;
        }

        //This is for calculating the radical pressure corrected. It is known as Fβs in the mathcad sheets.
        public double CalculateRadicalPressureCorrection()
        {
            //Pull the values you will need. This makes for cleaner code.
            double dOutSquared = Math.Pow(this.calculateOuterDiameter(), 2);

            double dDrySquared = Math.Pow(this.calculateMeterTubeBore(), 2);

            double FBs = 1 / elasticity * (((1.3 * dOutSquared) - (0.4 * dDrySquared)) /
                                          (dOutSquared - dDrySquared));
            return FBs;
        }



        //Cpsf
        //I currently do not know what this stands for. You will need to pass in a Operating Conditions objects.
        //Pass the corrected Operating pressure as a parameter.

        public double CalculateCpsf()
        {
            double cpsf = 1 + this.CalculateRadicalPressureCorrection() * this.opconditions.CalculateSIAbsoluteOperatingPressure();

            return cpsf;
        }
        
        
        public double CalculateCpsw()
        {
            double cpsw = 1 + this.CalculateRadicalPressureCorrection() * (this.CalculateSIAbsoluteCalibratedPressure() - 1);

            return cpsw;
        }

        public double CalculateCtsfr()
        {
            double ctsfr = 1 + coeff * (this.opconditions.OperatingTemperature - tmet);

            return ctsfr;
        }




        




    }
}
