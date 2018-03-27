using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LiveUncertainty.classes
{
    //<summary>
    //USM Meter Object.
    //</summary>
    public class UltraSonicMeter
    {
        protected Int64 manufacturer_id;
        protected Int64 model_id;
        private string model_name;
        private string manufacturer_name;
        private string tag;
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

        //metrology temperature
        public double metrologyTemp;

        public string rho;
        //Most static variables are kept on this class.

        protected double elasticity = 210 * Math.Pow(10, 9); // Mod of elasticity
        private double coeff = 1.2 * Math.Pow(10, 5); //Coeff. of Linear Exp. (/°C)
        public const double thermalExpansion = 0.000011;
        private const double tmet = 20;

        //deg is 0.017
        private const double deg = 0.017;

        //this is the pipework restraint expansion factor.
        private const double Ftax = 0.25;

        //Universal Gas Constant
        private double Ro = 8.314510 * Math.Pow(10, 3);

        //Associated objects that will be taken in the frontend
        public OperatingConditions opconditions;
        public GasComposition gascomp;
        public PressureTransmitter pressure;
        public TemperatureTransmitter temperature;

        //these are used for calculating the chords and getting arrays, etcc.
        public List<Path> paths;
        public List<Double> pathLengthsL;
        public List<Double> pathLengths;
        public List<Double> pathXvals;
        public List<Double> pathChords;
        public List<Double> pathChordsX;
        public List<Double> pathWeightingFactors;
        public List<Double> pathAngles;
        public List<Double> pathAngles_DegreeMultiplied;
        public List<uint> pathBounces;

        //Uncertainty values that can be changed.

        //Uncertainty in electronics due to ambient temperature variation
        double electronicsStabilityUncertainty = 0.01;

        //Stability Of Timing Circuit Resolution
        double stabilityOfTime = 4 * Math.Pow(10, 9);

        //Meter Uncertainty from mathematical model.
        double meterUncertainty_mathmodel = 0.04;

        //Meter Uncertainty from long term drift. (Eydrift)
        double longtermdrift = 0.1;

        //Resolution of the meter tube bore. (Ddry)
        public double metertubeboreResolution_mm = 0.058;

        double metertubeboreResolution = 0.058 * Math.Pow(10, -3);

        //Path legnth uncertainty (Ldry)
        double pathlengthResolution = 0.058 * Math.Pow(10, -3);

        //Axial Path Length Uncertainty (xDry)
        double axialPathResolution = 0.058 * Math.Pow(10, -3);

        //Assumed depth 
        double innersurfacedepth = 0;





        public UltraSonicMeter()
        {

        }

        public string Tag
        {
            get
            {
                return tag;
            }

            set
            {
                tag = value;
            }
        }
        public string Name
        {
            get
            {
                return model_name;
            }

            set
            {
                model_name = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return manufacturer_name;
            }

            set
            {
                manufacturer_name = value;
            }
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

        protected Int16 PathsTotal
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

        protected List<Path> Paths
        {
            get
            {
                return paths;
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

        protected double Calibration_Frequency
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

        public OperatingConditions OperatingConditions
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

        public double MetrologyTemperature
        {
            get => metrologyTemp;

            set => metrologyTemp = value;

        }

        //meter tube bore is calculated by dividing the internal diameter by 1000. (Mathcad reference: dDry)
        public double CalculateMeterTubeBore()
        {
            double dDry = this.internalDiameter / 1000;
            return dDry;
        }

        public double CalculateLongTermDrift()
        {
            return longtermdrift / 12 * Calibration_Frequency;
        }

        //NOTE: outerdiameter and meterwallthickness can be 0, but 1 has to be filled in at one time.

        //Mathcad reference tw
        public double CalculateMeterWallThickness()
        {

            double tw = 0; //metertubewallthickness
            if (wallThickness != 0)
            {
                tw = wallThickness / 1000;
            }
            else
            {
                //tw is outerDiameter multiplied by 10 to the power of 3 taken away by the metertubebore divided by 2.

                tw = (outerDiameter * Math.Pow(10, 3)) - this.CalculateMeterTubeBore() / 2;
            }

            return tw;
        }

        public double calculateOuterDiameter()
        {
            double dOut = 0; //true outer diameter.
            if (outerDiameter != 0)
            {
                //this is bore plus 2 multiplied by meterwallthickness or tw
                dOut = CalculateMeterTubeBore() + 2 * CalculateMeterWallThickness();
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

        public void AddPathLengthsL()
        {
            pathLengthsL.Clear();
            foreach (Path pathobj in paths)
            {
                pathLengthsL.Add(pathobj.Length * Math.Pow(10, 3));
            }
        }

        public void AddPathLengths()
        {
            pathLengths.Clear();
            foreach (Path pathobj in paths)
            {
                pathLengths.Add(pathobj.Length);
            }
        }


        //0z
        public void AddPathAngles_Degrees()
        {
            pathAngles_DegreeMultiplied.Clear();
            foreach (Path pathobj in paths)
            {
                pathAngles_DegreeMultiplied.Add(pathobj.Angle * deg);
            }
        }

        //0x
        public void AddPathAngles()
        {
            pathAngles.Clear();
            foreach (Path pathobj in paths)
            {
                pathAngles.Add(pathobj.Angle);
            }
        }

        public void AddPathChords() //offsets
        {
            pathChords.Clear();
            foreach (Path pathobj in paths)
            {
                pathChords.Add(pathobj.offset);
            }

        }

        public void AddPathChordsDividedbydDdry() //offsets
        {
            pathChords.Clear();
            foreach (Path pathobj in paths)
            {
                pathChords.Add(pathobj.offset * (this.CalculateMeterTubeBore() / 2));
            }

        }

        public void AddPathWeightingFactors()
        {
            pathWeightingFactors.Clear();
            foreach (Path pathobj in paths)
            {
                pathWeightingFactors.Add(pathobj.weightingFactor);
            }
        }

        public void AddPathXValues()
        {
            pathXvals.Clear();
            foreach (Path pathobj in paths)
            {
                pathXvals.Add(pathobj.x * Math.Pow(10, 3));
            }
        }

        public void AddNoOfBounces()
        {
            pathBounces.Clear();
            foreach (Path pathobj in paths)
            {
                pathBounces.Add(pathobj.Bounces);
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
            double correctMetTemperature = this.metrologyTemp + 273.15;
            return correctMetTemperature;
        }

        //This is for calculating the radical pressure corrected. It is known as Fβs in the mathcad sheets.
        public double CalculateRadicalPressureCorrection()
        {
            //Pull the values you will need. This makes for cleaner code.
            double dOutSquared = Math.Pow(this.calculateOuterDiameter(), 2);

            double dDrySquared = Math.Pow(this.CalculateMeterTubeBore(), 2);

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

        public double CalculateCtswr()
        {
            double ctswr = 1 + coeff * (this.Calibration_Temperature - tmet);
            return ctswr;
        }

        public double CalculateCtsfa()
        {
            double ctsfa = 1 + Ftax * coeff * (this.opconditions.OperatingTemperature - tmet);
            return ctsfa;
        }

        public double CalculateCtswa()
        {
            double ctswa = 1 + Ftax * coeff * (this.opconditions.OperatingTemperature - tmet);
            return ctswa;
        }

        public List<double> ReCalculateWeightingFactors() //This is done using the annulus rule.
        {
            List<double> Aand_d = new List<double>();

            foreach (double chord in this.pathChords)
            {
                double recalculatedweightingfactor = Math.PI * ((Math.Pow((this.CalculateMeterTubeBore() / 2), 2)) - (Math.Pow(chord, 2)));

                Aand_d.Add(recalculatedweightingfactor);
            }
            return Aand_d;
        }

        //continuation after getting recalculated weighting factors
        public List<double> ReCalculateRwd()
        {
            List<double> rwd = new List<double>();
            double sum = 0;

            //get the sum of the ReCalculated Weighting Factors

            foreach (double path in this.ReCalculateWeightingFactors())
            {
                sum += path;
            }

            foreach (double pathval in this.ReCalculateWeightingFactors())
            {

                double newvalue = pathval / sum;
                rwd.Add(newvalue);
            }
            return rwd;
        }

        //TODO: Add function that checks boolean once you figure out what it actually is from a proper datasheet.
        public List<uint> GetSumofBounces()
        {
            List<uint> sum = new List<uint>();

            foreach (uint val in pathBounces)
            {
                sum.Add(val);
            }
            return sum;
        }

        //steel wall thickness calculation. Needs bounces for it to work properly.
        public List<double> CalculateSteelWallThickness()
        {
            //check if number of bounces (nob) is more than one.
            List<uint> sumlist = GetSumofBounces();

            List<double> swt = new List<double>();

            foreach (uint sum in sumlist)
            {
                if (sum > 0)
                {
                    swt.Add(2 * CalculateMeterWallThickness());
                }
                else
                {
                    swt.Add(CalculateMeterWallThickness());
                }
            }

            return swt;
        }

        public List<double> CalculateSteelWallThickness_X2()
        {

            //check if number of bounces (nob) is more than one.
            List<double> newswt = new List<double>();

            foreach (double swt in CalculateSteelWallThickness())
            {
                newswt.Add(swt * 2);
            }

            return newswt;
        }

        //Calculate the distance between transducers if it's a clamp-on meter.
        public List<double> CalculateTransducerDistance_Clampmeters()
        {
            List<double> tdl = new List<double>();
            foreach (double val in pathBounces)
            {
                tdl.Add(this.transducerDistance / val + 1); //need to ask why mike adds 1 in his sheet.
            }
            return tdl;

        }


        //goes with the first IF statement only if no of bounces > 0 otherise multiply the steel wall thickness calculation by two;
        public List<double> CalculatePathAngle_ClampMeters()
        {
            List<double> Zerotdl = new List<double>();

            List<uint> sumlist = GetSumofBounces();

            using (var tdval = CalculateTransducerDistance_Clampmeters().GetEnumerator())
            using (var swt = CalculateSteelWallThickness().GetEnumerator())
            using (var sum = sumlist.GetEnumerator())
            {
                while (tdval.MoveNext() && swt.MoveNext() && sum.MoveNext())
                {
                    if (sum.Current > 0)
                    {

                        double value = Math.Atan(((CalculateMeterTubeBore() + swt.Current) / tdval.Current));
                        Zerotdl.Add(value);


                    }
                    else
                    {
                        double value = Math.Atan(((CalculateMeterTubeBore() + swt.Current) / tdval.Current));
                        Zerotdl.Add(value);
                    }

                }
            }
            return Zerotdl;
        }

        public bool checkAnglesHaveValues()
        {
            double sum = 0;

            bool hasvalues;

            foreach (double val in pathAngles_DegreeMultiplied)
            {
                sum += val;
            }

            if (sum > 0)
            {
                hasvalues = true;
            }
            else
            {
                hasvalues = false;
            }


            return hasvalues;
        }

        //If there is path angles more than 0 we use the clamp on meter result. This is the Path angles (Radians) Calculation.
        public List<double> SelectPathAngleRadians()
        {
            bool hasvalues = checkAnglesHaveValues();

            if (hasvalues)
            {
                return CalculatePathAngle_ClampMeters();
            }
            else
            {
                return this.pathAngles_DegreeMultiplied;
            }
        }

        //this calculates the Ultrasonic path chords. (ψdry)
        public List<double> CalculateUltraSonicPathChord()
        {

            List<double> chordDry = new List<double>();
            List<double> chords = this.pathChordsX;
            List<uint> noOfBounces = this.pathBounces;
            List<double> angles = new List<double>();
            //check if there's values in the path angles
            if (checkAnglesHaveValues())
            {
                angles = pathAngles_DegreeMultiplied;
            }

            else
            {
                angles = CalculatePathAngle_ClampMeters();
            }

            double valuetoadd = 0;

            //loop through each bounce and check if it's 0, 1, or 2. bounces can NEVER be more than 2 so that MUST be validated. 

            //since foreach hates if you try to loop 2 at once, we made our own. 
            using (var bounce = noOfBounces.GetEnumerator())
            using (var chord = noOfBounces.GetEnumerator())
            using (var radianPathangle = angles.GetEnumerator())
            {
                while (chord.MoveNext() && bounce.MoveNext())
                {
                    if (bounce.Current == 0 || bounce.Current == 1)
                    {
                        valuetoadd = 2 * (Math.Sqrt(Math.Pow(this.CalculateMeterTubeBore() / 2, 2) - (Math.Pow(chord.Current, 2))));
                    }

                    else if (bounce.Current == 2)
                    {
                        valuetoadd = (Math.Cos(radianPathangle.Current / 2)) * this.CalculateMeterTubeBore();
                    }

                    chordDry.Add(valuetoadd);
                }

                //When we get around to implementing the database i will need to add code here that does a calculation if the selected usmt meter is "7".
                //it should be the first if statement
            }

            return chordDry;

        }

        //This calculate the Axial Path Length.

        public List<double> CalculateAxialPathLength()
        {
            List<double> dryX = new List<double>();

            //check the angles again.
            List<double> angles = new List<double>();

            if (checkAnglesHaveValues())
            {
                angles = pathAngles_DegreeMultiplied;
            }

            else
            {
                angles = CalculatePathAngle_ClampMeters();
            }

            //get lists for ultrasonic path chords and radian path angles
            List<double> chordDry = CalculateUltraSonicPathChord();

            using (var chords = chordDry.GetEnumerator())
            using (var radianpathangles = angles.GetEnumerator())
            {
                while (chords.MoveNext() && radianpathangles.MoveNext())
                {
                    double dry = chords.Current / Math.Tan(radianpathangles.Current);
                    dryX.Add(dry);
                }
            }

            //Now that you have the dry values, do the full calculation.
            //define a new list for the new dryvalues.
            List<double> dryX2 = new List<double>();

            //get sum off pathanglesx
            double sum = pathLengthsL.Sum(x => x);

            using (var bounces = pathBounces.GetEnumerator())
            using (var dryval = dryX.GetEnumerator())
            {
                while (bounces.MoveNext() && dryval.MoveNext())
                {
                    if (bounces.Current > 0 || this.metrologyData == false || sum > 0)
                    {
                        double val = dryval.Current * bounces.Current + 1;
                        dryX2.Add(val);
                    }
                    else
                    {
                        dryX2.Add(dryval.Current);
                    }
                }
            }
            return dryX2;

        }

        public List<double> calculateSteelBeamLength()
        {
            double tw = CalculateMeterWallThickness();

            List<double> swp = new List<double>();
            foreach (double path in SelectPathAngleRadians())
            {
                double val = tw / Math.Sin(path);
                swp.Add(val);

            }
            return swp;
        }

        public List<double> CalculateSteelAxialLength()
        {

            double tw = CalculateMeterWallThickness();

            List<double> swx = new List<double>();

            foreach (double path in SelectPathAngleRadians())
            {
                double val = tw / Math.Cos(path);
                swx.Add(val);
            }

            return swx;
        }

        public List<double> CalculateFluidPathLength()
        {
            //part 1 metertube bore divided the the sin value of the path angle.

            double dDry = CalculateMeterTubeBore();

            List<double> fpl = new List<double>();

            foreach (double path in SelectPathAngleRadians())
            {
                double val = dDry / Math.Sin(path);
                fpl.Add(val);
            }

            //Part 2: fpl multiplied the the nop.

            List<double> newFPL = new List<double>();

            using (var fpl1 = fpl.GetEnumerator())
            using (var nob = pathBounces.GetEnumerator())
            {
                while (fpl1.MoveNext() && nob.MoveNext())
                {
                    double val = fpl1.Current * (nob.Current + 1);
                    newFPL.Add(val);
                }

            }

            return newFPL;
        }

        public List<double> Calculateb90() //Calculate Path Length for Panametrics Bias 90 Flare Gas meter
        {
            return null;
        }

        public List<double> CalculatePathLength() //1dry
        {
            List<double> _1Dry = new List<double>();

            //get the required lists
            List<uint> bounces = pathBounces;
            List<double> swt = CalculateSteelWallThickness();
            List<double> tdl = CalculateTransducerDistance_Clampmeters();
            double dDry = CalculateMeterTubeBore();
            List<double> swp = calculateSteelBeamLength();
            List<double> Ldryz = pathLengthsL;
            List<double> fpl = CalculateFluidPathLength();

            //set up an enumerator for each.
            using (var Bounces = bounces.GetEnumerator())
            using (var Tdl = tdl.GetEnumerator())
            using (var Swp = swp.GetEnumerator())
            using (var Swt = swt.GetEnumerator())
            using (var ldryz = pathLengthsL.GetEnumerator())
            using (var FPL = fpl.GetEnumerator())
            {
                while (Bounces.MoveNext() && Tdl.MoveNext() && Swp.MoveNext() && ldryz.MoveNext() && Swt.MoveNext() && FPL.MoveNext())
                {
                    double val = 0;

                    if (this.transducerDistance > 0)
                    {
                        val = Math.Sqrt
                            (
                            Math.Pow((Tdl.Current * Bounces.Current + 1), 2) + Math.Pow((dDry + Swt.Current * Bounces.Current + 1), 2)
                            );
                        _1Dry.Add(val);
                    }

                    else if (metrologyData == false)
                    {
                        val = FPL.Current + 2 * Swp.Current;

                        _1Dry.Add(val);
                    }

                    else
                    {
                        val = ldryz.Current / Bounces.Current + 1;
                        _1Dry.Add(val);
                    }
                }
            }
            // Now multiply it by the number of bounces + 1 depending on the conditions.
            List<double> new1dry = new List<double>();
            using (var oneDry = _1Dry.GetEnumerator())
            using (var bounces2 = pathBounces.GetEnumerator())
            {
                while (bounces2.MoveNext() && oneDry.MoveNext())
                {
                    double val = 0;
                    if (bounces2.Current > 0 || metrologyData == false)
                    {
                        val = oneDry.Current * bounces2.Current + 1;
                        new1dry.Add(val);
                    }

                    else
                    {
                        new1dry.Add(oneDry.Current);
                    }
                }

            }

            return new1dry;

        }

        public double CalculateDf()
        {
            double Df = CalculateMeterTubeBore() * CalculateCtsfr() * CalculateCpsf();

            return Df;
        }

        public List<double> CalculateXf()
        {
            List<double> Xf = new List<double>();
            List<double> Xdry = CalculateAxialPathLength();

            double Ctsfa = CalculateCtsfa();

            foreach (double val in Xdry)
            {
                double xf = val * Ctsfa;

                Xf.Add(xf);
            }

            return Xf;
        }

        public List<double> CalculateXwet()
        {
            List<double> Xwet = new List<double>();
            List<double> Xdry = CalculateAxialPathLength();

            double Ctswa = CalculateCtswa();

            foreach (double val in Xdry)
            {
                double xf = val * Ctswa;

                Xwet.Add(xf);
            }

            return Xwet;
        }

        public List<double> CalculateBay()
        {
            List<double> fpl = new List<double>();
            List<double> bay = new List<double>();

            List<double> XDry = CalculateAxialPathLength();
            List<double> LDry = CalculatePathLength();
            List<double> pathradians = SelectPathAngleRadians();

            using (var _XDry = XDry.GetEnumerator())
            using (var _pathradians = pathradians.GetEnumerator())
            {
                while (_XDry.MoveNext() && _pathradians.MoveNext())
                {
                    double val = _XDry.Current / Math.Cos(_pathradians.Current);
                    fpl.Add(val);
                }
            }

            //calculate bay
            using (var ldry = LDry.GetEnumerator())
            using (var FPL = fpl.GetEnumerator())
            {
                while (ldry.MoveNext() && FPL.MoveNext())
                {
                    double val = (ldry.Current - FPL.Current) / 2;
                    bay.Add(val);
                }
            }
            return bay;
        }

        public List<double> CalculateChordWidthDry()
        {
            List<double> chordwidth = new List<double>();
            List<double> pathradians = SelectPathAngleRadians();
            List<double> XDry = CalculateAxialPathLength();

            using (var path = pathradians.GetEnumerator())
            using (var xdry = XDry.GetEnumerator())
            {
                while (xdry.MoveNext() && path.MoveNext())
                {
                    double val = Math.Tan(path.Current) * xdry.Current;
                    chordwidth.Add(val);
                }
            }

            return chordwidth;
        }

        public List<double> CalculateChordWidthf()
        {
            List<double> ChordF = new List<double>();
            List<double> chordwidth = CalculateChordWidthDry();
            double Ctsfr = CalculateCtsfr();
            double Cpsf = CalculateCpsf();

            foreach (double chord in chordwidth)
            {
                double val = chord * Ctsfr * Cpsf;
                ChordF.Add(val);
            }
            return ChordF;
        }

        public List<double> CalculateChordWet() //ChordWet
        {
            List<double> chordWet = new List<double>();
            List<double> chordWidth = CalculateChordWidthDry();
            double Ctswr = CalculateCtswr();
            double Cpsw = CalculateCpsw();

            foreach (double chord in chordWidth)
            {
                double val = chord * Ctswr * Cpsw;
            }

            return chordWet;
        }

        public List<double> CalculatePathAngleAfterPressure() //0f This is in RADIANS.
        {
            List<double> zeroF = new List<double>();
            List<double> chordf = CalculateChordWidthf();
            List<double> Xf = CalculateXf();

            // chord divided by xf
            using (var chord = chordf.GetEnumerator())
            using (var xf = Xf.GetEnumerator())
            {
                while (chord.MoveNext() && xf.MoveNext())
                {
                    var val = Math.Atan(chord.Current / xf.Current);
                    zeroF.Add(val);
                }
            }
            return zeroF;
        }

        public List<double> CalculatePathAngleTemperature() // 0Wet
        {
            List<double> Zerowet = new List<double>();
            List<double> chordwet = CalculateChordWet();
            List<double> xwet = CalculateXwet();

            using (var Chord = chordwet.GetEnumerator())
            using (var Xwet = xwet.GetEnumerator())
            {
                while (Chord.MoveNext() && Xwet.MoveNext())
                {
                    double val = Math.Atan(Chord.Current / Xwet.Current);
                    Zerowet.Add(val);
                }
            }

            return Zerowet;
        }

        public List<double> CalculatePathLengthPostPressure() //Lf, I assume.
        {
            List<double> Lf = new List<double>();

            List<double> Xf = CalculateXf();

            List<double> ZeroF = CalculatePathAngleAfterPressure();

            List<double> Bay = CalculateBay();

            using (var _Xf = Xf.GetEnumerator())
            using (var _ZeroF = ZeroF.GetEnumerator())
            using (var _Bay = Bay.GetEnumerator())
            {
                while (_Xf.MoveNext() && _ZeroF.MoveNext() && _Bay.MoveNext())
                {
                    double val = (_Xf.Current / Math.Cos(_ZeroF.Current)) + 2 * _Bay.Current;
                    Lf.Add(val);
                }
            }
            return Lf;
        }

        public List<double> PathLengthTemperatureCorrected()
        {
            List<double> Lwet = new List<double>();

            List<double> Xf = CalculateXf();

            List<double> ZeroWet = CalculatePathAngleTemperature();

            List<double> Bay = CalculateBay();

            using (var _Xf = Xf.GetEnumerator())
            using (var _ZeroWet = ZeroWet.GetEnumerator())
            using (var _Bay = Bay.GetEnumerator())
            {
                while (_Xf.MoveNext() && _ZeroWet.MoveNext() && _Bay.MoveNext())
                {
                    double val = (_Xf.Current / Math.Cos(_ZeroWet.Current)) + 2 * _Bay.Current;
                    Lwet.Add(val);
                }
            }
            return Lwet;
        }


        public double CalculateBaseCompressibility()
        {
            if (GetSumofBounces()[0] == 0) //replace with an rho check in the near future.
            {
                return opconditions.baseCompressibility;
            }
            else
            {
                //get the sum of xi
                double sum = 0;
                using (var xienum = gascomp.CalculateXi().GetEnumerator())
                using (var gasenum = gascomp.Gases.GetEnumerator())
                {
                    while (xienum.MoveNext() && gasenum.MoveNext())
                    {
                        double newsum = Math.Pow(xienum.Current * gasenum.Current.SqrtB, 2);
                        sum += newsum;
                    }
                }

                double returnval = 1 - sum;

                return returnval;
            }
        }

        public double CalculateRelativeMolarMass() //MW mathcad reference.
        {
            double relativemolarmass = 0;

            using (var xienum = gascomp.CalculateXi().GetEnumerator())
            using (var gasenum = gascomp.Gases.GetEnumerator())
            {
                while (xienum.MoveNext() && gasenum.MoveNext())
                {
                    relativemolarmass += xienum.Current * gasenum.Current.MolWeight;
                }
            }
            return relativemolarmass;
        }

        public double CalculateBaseDensity()
        {
            double Pref = opconditions.CalculateSIAbsoluteOperatingPressureConverted();
            double MW = CalculateRelativeMolarMass();
            double Tref = opconditions.CalculateSIAbsoluteReferenceTemperature();
            double zb = CalculateBaseCompressibility();
            double ro = this.Ro;

            double basedensity = (Pref * MW) / (zb * ro * Tref);

            return basedensity;

        }

        public double CalculateRelativeDensity()
        {
            return CalculateBaseDensity() / 1.22541;
        }

        public List<double> CalculateIndividualPathVelocities() //this might not be done correctly. 
        {
            List<double> IPV = new List<double>();

            var weightingfactorenum = new WeightingFactorEnum(pathWeightingFactors);
            using (var IVenum = OperatingConditions.CalculateViv().GetEnumerator())
            {
                while (weightingfactorenum.MoveNext() && weightingfactorenum.MoveNext())
                {
                    double val = weightingfactorenum.Current * IVenum.Current;

                    IPV.Add(val);

                    if(weightingfactorenum.MoveNext() == false)
                    {
                        weightingfactorenum.Reset();
                    }
                }
            }

            return IPV;
        }

        public List<double> CalculateActualGrossObservedFlowRate()
        {
            List<double> gov = new List<double>();

            foreach (double val in OperatingConditions.CalculateViv())
            {
                double addedval = val * (Math.PI * Math.Pow(CalculateMeterTubeBore(), 2)) / 4;

                gov.Add(addedval);
            }

            return gov;
        }

        private List<double> CalculateGrossObservedFlowRateInTonnes()
        {
            List<double> gov = new List<double>();

            foreach (double val in CalculateActualGrossObservedFlowRate())
            {
                double returnval = val * 3600;
                gov.Add(returnval);
            }

            return gov;
        }

        public List<double> CalculateGrossObservedFlowRateInMetrics()
        {
            List<double> gov = new List<double>();

            foreach (double val in CalculateGrossObservedFlowRateInTonnes())
            {
                double returnval = val * this.OperatingConditions.OperatingPressure / 1000;

                gov.Add(returnval);
            }

            return gov;
        }
        /// <summary>
        /// This is known as qsv.h in mathcad.
        /// </summary>
        /// <returns></returns>

        public List<double> CalculateGrossObservedMassFlowInMassFlow()
        {
            List<double> gov = new List<double>();

            foreach (double val in CalculateGrossObservedFlowRateInMetrics())
            {
                double returnval = val * Math.Pow(10, 3) / this.OperatingConditions.BaseDensity;
                gov.Add(returnval);
            }

            return gov;
        }

        public List<double> CalculateGrossObservedMassFlowMMSCFD()
        {
            List<double> gov = new List<double>();

            foreach (double val in CalculateGrossObservedMassFlowInMassFlow())
            {
                double returnval = val * 35.3147 * (24 / Math.Pow(10, 6));
                gov.Add(returnval);
            }

            return gov;
        }

        public List<double> CalculateTransitTimesDownwards()
        {
            //define a list that is as long as the amount of steps.
            List<double> Dwn = new List<double>();

            //enumerators for our pathvalues.
            var Lfenum = this.pathLengths.GetEnumerator();
            var Xfenum = this.CalculateXf().GetEnumerator();
            var vivenum = this.OperatingConditions.CalculateViv().GetEnumerator();
            //get the size of the viv list
            int vivSize = OperatingConditions.CalculateViv().Count;


            //get the maximum number

            while (vivenum.MoveNext())
            {
                while (Lfenum.MoveNext() && Xfenum.MoveNext())
                {
                    double val = Lfenum.Current / (OperatingConditions.CalculateVelocityofSound() + vivenum.Current * (Lfenum.Current / Xfenum.Current));
                    Dwn.Add(val);
                }
            }


            return Dwn;

        }

        public List<double> CalculateTransitTimeUpwards()
        {
            //define a list that is as long as the amount of steps.
            List<double> Tup = new List<double>();

            //enumerators for our pathvalues.
            var Lfenum = this.pathLengths.GetEnumerator();
            var Xfenum = this.CalculateXf().GetEnumerator();
            var vivenum = this.OperatingConditions.CalculateViv().GetEnumerator();
            //get the size of the viv list
            int vivSize = OperatingConditions.CalculateViv().Count;


            //get the maximum number

            while (vivenum.MoveNext())
            {
                while (Lfenum.MoveNext() && Xfenum.MoveNext())
                {
                    double val = Lfenum.Current / (OperatingConditions.CalculateVelocityofSound() - vivenum.Current * (Lfenum.Current / Xfenum.Current));
                    Tup.Add(val);
                }
            }


            return Tup;
        }

        /// <summary>
        /// gets the difference betweens the transit times.
        /// </summary>
        /// <returns></returns>
        public List<double> CalculateTransitTimeDifference()
        {
            List<double> tDiff = new List<double>();

            var tupenum = CalculateTransitTimeUpwards().GetEnumerator();

            var tdwnenum = CalculateTransitTimesDownwards().GetEnumerator();

            while (tupenum.MoveNext() && tdwnenum.MoveNext())
            {
                var value = tupenum.Current - tdwnenum.Current;
                tDiff.Add(value);
            }

            return tDiff;
        }

        //Some Uncertainties are calculated here

        /// <summary>
        /// Calculates the uncertainty of the meter tube bore. (EDry)
        /// </summary>
        /// <returns></returns>
        public double CalculateMeterTubeBoreUncertainty()
        {
            return (this.metertubeboreResolution / CalculateMeterTubeBore()) * 100;

        }

        public List<double> CalculatePathLengthUncertainty()
        {
            List<double> pathLengthUncertainty = new List<double>();

            foreach (double val in pathLengths) //pathlengths = lf.
            {
                pathLengthUncertainty.Add((pathlengthResolution / val) * 100);
            }

            return pathLengthUncertainty;
        }

        /// <summary>
        /// Calculates the uncertainty values of the axial paths (Xf)
        /// </summary>
        /// <returns></returns>

        public List<double> CalculateAxialPathLengthUncertainty()
        {
            List<double> pathAxialLengthUncertainty = new List<double>();

            foreach (double val in CalculateXf())
            {
                pathAxialLengthUncertainty.Add((pathlengthResolution / val) * 100);
            }

            return pathAxialLengthUncertainty;
        }

        public double CalculateAssumedDepth()
        {
            return innersurfacedepth / 1000;
        }

        public List<double> CalculateGrossObservedVolumeWithSurfaceDeposition()
        {
            List<double> GOVisd = new List<double>();
            List<double> Viv = OperatingConditions.CalculateViv();

            foreach (double val in Viv)
            {
                GOVisd.Add((Math.PI * Math.Pow(CalculateMeterTubeBore() - 2 * CalculateAssumedDepth(), 2)) / 4);
            }

            return GOVisd;

        }

        public List<double> CalculateGOVWithSurfaceDespositionUncertainty() //govisdv
        {
            List<double> Eisd = new List<double>();

            var qgovivEnum = CalculateGrossObservedFlowRateInTonnes().GetEnumerator();

            var qgovisdEnum = CalculateGrossObservedVolumeWithSurfaceDeposition().GetEnumerator();

            while (qgovisdEnum.MoveNext() && qgovivEnum.MoveNext())
            {
                Eisd.Add((qgovivEnum.Current - qgovisdEnum.Current / qgovivEnum.Current) * 100);
            }

            return Eisd;

        }

        public double CalculateMetrologyTemperatureUncertainty()
        {
            double absoluteTempError = 0.2;

            double tUncertainty = absoluteTempError / CalculateSIAbsoluteCalibratedTemperature() * 100;

            return tUncertainty;
        }

        /// <summary>
        /// Calculates the pipe diameter uncertain at each gov speed. (Edf)
        /// </summary>
        /// <returns></returns>

        public List<double> CalculatePipeDiameterUncertainty()
        {
            List<double> PipeDiameterUncertainty = new List<double>();

            double edry = CalculateMeterTubeBoreUncertainty();

            List<double> Eisd = CalculateGOVWithSurfaceDespositionUncertainty();

            foreach (double val in Eisd)
            {
                double calculatedval = Math.Sqrt(Math.Pow(edry, 2) + Math.Pow(val, 2));

                PipeDiameterUncertainty.Add(calculatedval);
            }

            return PipeDiameterUncertainty;
        }

        public List<double> CalculateAxialBeamTraverseUncertainty()
        {
            List<double> Exdry = CalculateAxialPathLengthUncertainty();

            List<double> eXf = new List<double>();

            foreach (double val in Exdry)
            {
                double calculatedval = Math.Sqrt(Math.Pow(val, 2));

                eXf.Add(calculatedval);
            }

            return eXf;
        }

        public List<double> CalculateBeamLengthUncertainty()
        {
            List<double> eLdry = CalculatePathLengthUncertainty();
            List<double> eLf = new List<double>();

            foreach (double val in eLdry)
            {
                double calculatedval = Math.Sqrt(Math.Pow(val, 2));

                eLf.Add(calculatedval);
            }

            return eLf;

        }

        /// <summary>
        /// Calculates the uncertainty of transit times.
        /// </summary>
        /// <param name="isupstream"> used to determine what transit list to use (downwards/upwards)</param>
        /// <returns>A list</returns>
        public List<double> CalculateTransitTimingUncertainty(bool isupstream)
        {
            FixedUncertainties fixeduncerts = new FixedUncertainties();
            List<double> Ef = new List<double>();

            double atv = fixeduncerts.MeterElectronics;

            double cydt = fixeduncerts.TransducerDistance;

            List<double> transitlist = new List<double>();
            if (isupstream)
            {
                transitlist = CalculateTransitTimeUpwards();
            }
            else
            {
                transitlist = CalculateTransitTimesDownwards();
            }

            //stability of time divided by each transit time multiplied by 100.

            foreach (double val in transitlist)
            {
                double returnval = Math.Sqrt(Math.Pow(stabilityOfTime / val * 100, 2) + Math.Pow(atv, 2) + Math.Pow(cydt, 2));
                Ef.Add(returnval);
            }

            return Ef;

        }

        /// <summary>
        /// Otherwise known as erau on the mathcad sheet.
        /// </summary>
        /// <returns></returns>

        public List<double> CalculateTotalTransitTimesUncertainty()
        {
            //Enumerator definitions go here.
            List<double> Erau = new List<double>();

            var transitTimesUpwardsEnum = CalculateTransitTimeUpwards().GetEnumerator();
            var transitTimesDownwardsEnum = CalculateTransitTimesDownwards().GetEnumerator();
            var transitTimesUncertaintyDownwardsEnum = CalculateTransitTimingUncertainty(false).GetEnumerator();
            var transitTimesUncertaintyUpwardsEnum = CalculateTransitTimingUncertainty(true).GetEnumerator();

            while (transitTimesDownwardsEnum.MoveNext() && transitTimesDownwardsEnum.MoveNext() && transitTimesUncertaintyDownwardsEnum.MoveNext() && transitTimesUncertaintyUpwardsEnum.MoveNext())
            {
                double val = Math.Sqrt(
                                        Math.Pow(transitTimesDownwardsEnum.Current / transitTimesUpwardsEnum.Current - transitTimesDownwardsEnum.Current, 2) * (Math.Pow(transitTimesUncertaintyUpwardsEnum.Current, 2))
                                        + Math.Pow(transitTimesUpwardsEnum.Current / transitTimesUpwardsEnum.Current - transitTimesDownwardsEnum.Current, 2) * (Math.Pow(transitTimesUncertaintyDownwardsEnum.Current, 2))
                                        );
                Erau.Add(val);
            }

            return Erau;
        }

        public List<double> CalculateTotalFlowUncertainty()
        {
            List<double> Evf = new List<double>();

            FixedUncertainties uncertainties = new FixedUncertainties();

            //Lists we will be using.

            var Elf = CalculateBeamLengthUncertainty().GetEnumerator();

            var Exf = CalculateAxialBeamTraverseUncertainty().GetEnumerator();

            var Erau = CalculateTotalTransitTimesUncertainty().GetEnumerator();

            //Fixed values we will be using.

            double env = uncertainties.FlowCalibrationUncertainty;

            double usn = uncertainties.NoiseInterfence;

            double pwc = uncertainties.Distortion;

            double calc = uncertainties.ComputerCalculation;

            double psu = uncertainties.PowerSupplyVariation;

            double drift = CalculateLongTermDrift();

            double fs = uncertainties.FlowProfileCorrectionFactor;

            while(Elf.MoveNext() && Exf.MoveNext() && Erau.MoveNext())
            {
                double returnval = Math.Sqrt(
                                             (Math.Pow(Elf.Current, 2) + Math.Pow(Exf.Current, 2)) + Math.Pow(Erau.Current, 2) +
                                             (Math.Pow(env, 2) + Math.Pow(usn, 2) + Math.Pow(psu, 2) + Math.Pow(calc, 2)) +
                                             (Math.Pow(fs, 2) + Math.Pow(pwc, 2) + Math.Pow(drift, 2))
                                             );

                Evf.Add(returnval);

            }

            return Evf;


        }

        public List<double>CalculateFluidVelocityUncertainty()
        {
            var evm = new List<double>();
            var uncertainties = new FixedUncertainties();

            var vip = CalculateIndividualPathVelocities().GetEnumerator();
            var weightingfactors = new WeightingFactorEnum(pathWeightingFactors);
            var viv = OperatingConditions.CalculateViv().GetEnumerator();
            var evf = CalculateTotalFlowUncertainty().GetEnumerator();

            double mm = uncertainties.MathModel;
            

            while(vip.MoveNext() && weightingfactors.MoveNext() && viv.MoveNext() && evf.MoveNext())
            {
                double returnval = Math.Sqrt(
                    Math.Pow((weightingfactors.Current * vip.Current / viv.Current), 2) * (Math.Pow(mm, 2) + Math.Pow(evf.Current, 2))
                    );

                evm.Add(returnval);

                if(weightingfactors.MoveNext() == false)
                {
                    weightingfactors.Reset();
                }
            }

            return evm;

        }

        /// <summary>
        /// Calculates the uncertainty of the meter's Gross Observed Volume.
        /// </summary>
        /// <returns>Uncertainty values of the gross observed volume</returns>
        public List<double> CalculateGOVUncertainty() //AT LONG LAST!!!
        {
            var GOVuncertainty = new List<double>();

            var fixedUncertainties = new FixedUncertainties();

            var evmenum = CalculateFluidVelocityUncertainty().GetEnumerator();
            var edfenum = CalculatePipeDiameterUncertainty().GetEnumerator();
            double Emf = Math.Pow(fixedUncertainties.FlowCalibrationUncertainty, 2); //do it once rather than many times.

            while(evmenum.MoveNext() && edfenum.MoveNext())
            {
                double returnval = Math.Sqrt(Math.Pow(evmenum.Current, 2) + Math.Pow(edfenum.Current, 2) + Emf);

                GOVuncertainty.Add(returnval);
            }

            return GOVuncertainty;

        }
    





    }
}