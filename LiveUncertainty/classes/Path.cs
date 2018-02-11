using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// USM Path. Can only be initialized by a USM object.
/// </summary>
/// 
namespace LiveUncertainty.classes
{
    public class Path
    {
        public int path_number;
        public Double length;
        public Double offset;
        public Double x;
        public Double angle;
        public bool weightingFactorUse;
        public double weightingFactor;
        public uint bounces;

        public Path()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int Pathnum
        {
            get
            {
                return path_number;
            }

            set
            {
                if (value > 6) {
                    path_number = 6;
                }
                else
                {
                    path_number = value;
                }
            }
        }

        public double Length
        {
            get
            {
                return length;
            }

            set
            {
                length = value;
            }
        }

        public double Offset
        {
            get
            {
                return offset;
            }

            set
            {
                offset = value;
            }
        }

        public double X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public double Angle
        {
            get
            {
                return angle;
            }

            set
            {
                angle = value;
            }
        }

        public bool WeightingFactorUse
        {
            get
            {
                return weightingFactorUse;
            }

            set
            {
                weightingFactorUse = value;
            }
        }

        public double WeightingFactor
        {
            get
            {
                return weightingFactor;
            }

            set
            {
                weightingFactor = value;
            }
        }

        public uint Bounces
        {
            get
            {
                return bounces;
            }

            set
            {
                if (value > 2)
                {
                    bounces = 2;
                }
                
                else
                {
                    bounces = value;
                }
            }
        }

    }
}