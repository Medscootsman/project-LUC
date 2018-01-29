using System;

public class USM
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

    public USM()
	{
	}
}
