using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveUncertainty.classes
{
    public class MeterTube
    {
        public double maximumFluidVelocity;
        public double highStep;
        public double stepChgOver;
        public double lowStep;
        public double lowVelocity;
        public double straightLengthsUpstream;
        public double straightLengthsDownstream;
        public double upstreamFittings;
        public bool flowconditionerPresent;
        public bool ptCorrection;
        public double innerSurfaceDeposit;
        public double pipeRoughness;


        public MeterTube()
        {
        }
    }
}
