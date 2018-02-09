using System;
using System.Collections.Generic;
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
        public double methane;
        public double ethane;
        public double propane;
        public double nButane;
        public double isoButane;
        public double nPentane;
        public double neoPentane;
        public double hexane;
        public double heptane;
        public double octane;
        public double nonane;
        public double decane;
        public double nitrogen;
        public double carbonDioxide;
        public double air;
        public double hydrogenSulfide;
        public double carbonMonoxide;
        public double helium;
        public double oxygen;
        public double water;
        public double methanol;
        public double hexanePlus;
        public double sum;

        public GasComposition()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public double Methane
        {
            get
            {
                return methane;
            }

            set
            {
                methane = value;
            }
        }

        public double Ethane
        {
            get
            {
                return ethane;
            }
            set
            {
                ethane = value;
            }
        }

        public double Propane
        {
            get
            {
                return propane;
            }

            set
            {
                propane = value;
            }
        }

        public double NButane
        {
            get
            {
                return nButane;
            }

            set
            {
                nButane = value;
            }
        }

        public double IsoBuntane
        {
            get
            {
                return isoButane;
            }
            set
            {
                isoButane = value;
            }
        }
    }
}
