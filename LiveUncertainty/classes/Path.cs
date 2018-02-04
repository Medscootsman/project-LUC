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
        public Double Offset;
        public Double x;
        public Double Angle;
        public bool weightingFactorUse;
        public double weightingFactor;
        public int bounces;

        public Path()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}