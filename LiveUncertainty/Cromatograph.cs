using System;
   
/// <summary>
/// Maps a cromatograph for a metering system.
/// </summary>
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
