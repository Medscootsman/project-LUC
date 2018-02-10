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

        public double NPentane
        {
            get
            {
                return nPentane;
            }

            set
            {
                nPentane = value;
            }
        }

        public double NeoPentane
        {
            get
            {
                return neoPentane;
            }

            set
            {
                neoPentane = value;
            }
        }

        public double Hexane
        {
            get
            {
                return hexane;
            }

            set
            {
                hexane = value;
            }
        }
        
        public double Heptane
        {
            get
            {
                return heptane;
            }

            set
            {
                heptane = value;
            }
        }

        public double Octane
        {
            get
            {
                return octane;
            }

            set
            {
                octane = value;
            }
        }

        public double Nonane
        {
            get
            {
                return nonane;
            }
            
            set
            {
                nonane = value;
            }
        }

        public double Decane
        {
            get
            {
                return decane;
            }
            set
            {
                decane = value;
            }
        }

        public double Nitrogen
        {
            get
            {
                return nitrogen;
            }
            set
            {
                nitrogen = value;
            }
        }

        public double CarbonDioxide
        {
            get
            {
                return carbonDioxide;
            }

            set
            {
                carbonDioxide = value;
            }
        }

        public double Air
        {
            get
            {
                return air;
            }

            set
            {
                air = value;
            }
            
        }

        public double HydrogenSulfide
        {
            get
            {
                return hydrogenSulfide;
            }

            set
            {
                hydrogenSulfide = value;
            }
        }

        public double CarbonMonoxide
        {
            get
            {
                return carbonMonoxide;
            }

            set
            {
                carbonMonoxide = value;
            }
        }

        public double Helium
        {
            get
            {
                return helium;
            }

            set
            {
                helium = value;
            }
        }

        public double Oxygen
        {
            get
            {
                return oxygen;
            }

            set
            {
                oxygen = value;
            }
        }

        public double Water
        {
            get
            {
                return water;
            }

            set
            {
                water = value;
            }
        }

        public double Methanol
        {
            get
            {
                return methanol;
            }

            set
            {
                methanol = value;
            }
        }

        public double HexanePlus
        {
            get
            {
                return hexanePlus;
            }

            set
            {
                hexanePlus = value;
            }
        }

        public double Sum
        {
            get
            {
                sum =  Air + CarbonDioxide + CarbonMonoxide + Decane + Ethane + Heptane + Helium + Hexane + HexanePlus + IsoBuntane + Methane + Methanol + NButane + NeoPentane + Octane + Propane + NPentane;

                return sum;
            }
        }





    }
}
