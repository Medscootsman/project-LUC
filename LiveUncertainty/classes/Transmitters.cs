using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveUncertainty.classes
{

    public abstract class Transmitter
    {
        public String tagNum;
        public Double range;
        public Double URL; //Upper Range Limit
        public String manufacturer;
        public String model;
        public Int16 signalOutput;
        public Double cal_frequency; //Calibration Frequency In Months
        public Double reCalibrationFreq; //Recalibration Frequency.
        public Transmitter()
        {
        }

        public String Tag_Num
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

        public Double Range
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

        public Double Upper_Range_Limit
        {
            get
            {
                return URL;
            }

            set
            {
                URL = value;
            }
        }

        public String Manufacturer
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

        public String Model
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

        public Int16 Signal
        {
            get
            {
                return signalOutput;
            }

            set
            {
                signalOutput = value;
            }
        }

        public Double Calibration_Frequency
        {
            get
            {
                return cal_frequency;
            }

            set
            {
                cal_frequency = value;
            }
        }

        public Double ReCalibration_Tolerance
        {
            get
            {
                return reCalibrationFreq;
            }

            set
            {
                reCalibrationFreq = value;
            }
        }




    }
    public class TemperatureTransmitter : Transmitter
{
        public TemperatureTransmitter()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }

    public class PressureTransmitter : Transmitter
    {
        public PressureTransmitter()
        {

        }
    }
}