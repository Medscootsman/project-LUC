using EO.Internal;
using LiveUncertainty.classes.EntityModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// gas mol compositions class.
/// </summary>
namespace LiveUncertainty.classes
{
    public class GasComposition

    {
        public List<Gas> gases;
        public double sum;

        //Molecular Weights (constants)
        //I am not sure how i am going to do this, so for now i will do this by hardcoding them. Using a database may be more effort than it's worth.
        //constants also ensure data integrity too, i guess.
        public const double methaneWeight = 16.043;
        public const double ethaneWeight = 30.07;
        public const double propaneWeight = 44.097;
        public const double nbutaneWeight = 58.123;
        public const double isobutaneWeight = 58.123;
        public const double npentaneWeight = 72.15;
        public const double isopentaneWeight = 72.15;
        public const double neopentaneWeight = 72.15;
        public const double hexaneWeight = 86.177;
        public const double heptaneWeight = 100.204;
        public const double octaneWeight = 114.231;
        public const double nonaneWeight = 128.258;
        public const double decaneWeight = 142.285;
        public const double hydrogenWeight = 2.0159;
        public const double hydrogensulfideWeight = 34.082;
        public const double carbonmonoxideWeight = 28.01;
        public const double heliumWeight = 4.0026;
        public const double nitrogenWeight = 28.0135;
        public const double oxygenWeight = 31.9988;
        public const double carbondioxideWeight = 44.01;
        public const double airWeight = 28.9626;
        public const double waterWeight = 18.0153;
        public const double methanolWeight = 32.042;
        public const double hexaneplusWeight = 86.177;

        //sqrt b of each gas type
        public const double methaneSqrtb = 0.0447;
        public const double ethaneSqrtb = 0.0922;
        public const double propaneSqrtb = 0.1338;
        public const double nbutaneSqrtb = 58.123;
        public const double isobuntaneSqrtb = 0.179;
        public const double npentaneSqrtb = 0.251;
        public const double isopentaneSqrtb = 0.228;
        public const double neopentaneSqrtb = 0.2121;
        public const double hexaneSqrtb = 0.295;
        public const double heptaneSqrtb = 0.3661;
        public const double octaneSqrtb = 0.445;
        public const double nonaneSqrtb = 0.5385;
        public const double decaneSqrtb = 0.645;
        public const double hydrogenSqrtb = -0.0048;
        public const double hydrogensulfideSqrtb = 0.1;
        public const double carbonmonoxideSqrtb = 0.0224;
        public const double heliumSqrtb = 0.0002;
        public const double nitrogenSqrtb = -0.0048;
        public const double oxygenSqrtb = 0.0283;
        public const double carbondioxideSqrtb = 0.0748;
        public const double airSqrtb = 0;
        public const double waterSqrtb = 0.2345;
        public const double methanolSqrtb = 0.3578;
        public const double hexaneplusSqrtb = 0.295;


        public GasComposition()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public void AddGas(Gas gas)
        {
            gases.Add(gas);
        }

        public List<Gas> Gases
        {
            get
            {
                return gases;
            }

        }

        public double Sum
        {
            get
            {
                using(var gas = gases.GetEnumerator())
                {
                    while(gas.MoveNext())
                    {
                        sum += gas.Current.Composition;
                    }
                }

                return sum;
            }
        }


        //divide the total by 100 to see if it equals 1, if it doesn't then it is not at 100;
        public double CheckTotal()
        {
            double chk = this.Sum / 100;
            return chk;
        }

        public List<double> CalculateXi() //used in some methods.
        {
            //get a list of all gas compositions.
            List<double> Xi = new List<double>();

            foreach(Gas gas in Gases)
            {
                double value = gas.Composition / Sum;
                Xi.Add(value);
            }

            return Xi;

        }

        public double CalculateCHI()
        {
            double chi = 0;

            foreach(double xi in CalculateXi())
            {
                chi += xi;
            }

            return chi;
        }

        public double getFraction() //fraction of gas comp.
        {
            double fraction = 0;
            foreach (Gas gas in gases)
            {
                fraction += gas.Composition / sum;
            }

            return fraction;
        }

        public List<double> getGaValues() //AGA8 Ga values 
        {
            List<double> Ga = new List<double>();

            AGA8Table4Container data = new AGA8Table4Container();

            var tables = (from a in data.Table5 select a);

            foreach(Table5 entry in tables)
            {
                Ga.Add(double.Parse(entry.Ga));
            }

            return Ga;


        }







    }
}
