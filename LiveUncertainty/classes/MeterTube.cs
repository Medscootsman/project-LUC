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
        public const double pipeRoughnessNew = 0.03;

        public MeterTube()
        {

        }

        public double MaxFluidVelocity
        {
            get
            {
                return maximumFluidVelocity;
            }

            set
            {
                maximumFluidVelocity = value;
            }
        }

        public double HighStep
        {
            get
            {
                return highStep;
            }

            set
            {
                highStep = value;
            }
        }

        public double StepChangeOver
        {
            get
            {
                return stepChgOver;
            }

            set
            {
                stepChgOver = value;
            }
        }

        public double LowStep
        {
            get
            {
                return lowStep;
            }

            set
            {
                lowStep = value;
            }
        }

        public double LowVelocity
        {
            get
            {
                return lowVelocity;
            }
            
            set
            {
                lowVelocity = value;
            }
        }

        public double StraightLengthsUpstream
        {
            get
            {
                return straightLengthsUpstream;
            }

            set
            {
                straightLengthsUpstream = value;
            }
        }

        public double StraightLengthsDownstream
        {
            get
            {
                return straightLengthsDownstream;
            }

            set
            {
                straightLengthsDownstream = value;
            }
        }

        public double UpstreamFittings
        {
            get
            {
                return upstreamFittings;
            }

            set
            {
                upstreamFittings = value;
            }
        }

        public bool FlowconditionerPresent
        {
            get
            {
                return flowconditionerPresent;
            }

            set
            {
                flowconditionerPresent = value;
            }
        }

        protected bool PtCorrection
        {
            get
            {
                return ptCorrection;
            }

            set
            {
                ptCorrection = value;
            }
        }

        public double InnerSurfaceDeposit
        {
            get
            {
                return innerSurfaceDeposit;
            }

            set
            {
                innerSurfaceDeposit = value;
            }
        }

        public double PipeRoughness
        {
            get
            {
                return pipeRoughness;
            }

            set
            {
                pipeRoughness = value;
            }
        }

    }
}
