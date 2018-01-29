using System;

public class PressureTransmitter
{
    public String tagNum;
    public Double range;
    public Double URL; //Upper Range Limit
    public String manufacturer;
    public String model;
    public Int16 signalOutput;
    public Double cal_frequency; //Calibration Frequency In Months
    public Double reCalibrationFreq; //Recalibration Frequency.
	public PressureTransmitter()
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

    public int Signal
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
