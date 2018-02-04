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
        public Int16 paths;
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
        public bool metrologyData; //Always will be true (for now).
        public double transducerDistance;
        public double pathLengthTolerance;
        public double fluidPathTolerance;
        public double meterDiameterTolerance;

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
                return paths;
            }

            set
            {
                paths = value;
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

    }
}
