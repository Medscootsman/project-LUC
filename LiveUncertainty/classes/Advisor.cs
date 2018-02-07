using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveUncertainty
{
    class Advisor
    {
        public double uncertaintyTarget;
        public double reductionPotential;
        public bool feasible;

        public Advisor()
        {

        }

        public void Analyse()
        {

        }

        public void extractFeatures()
        {
            
        }

        public Double Target
        {
            get
            {
                return uncertaintyTarget;
            }
            set
            {
                uncertaintyTarget = value;
            }

        }

        public Double PotentialReduction
        {
            get
            {
                return reductionPotential;
            }

            set
            {
                reductionPotential = value;
            }
        }

        public bool Feasible
        {
            get
            {
                return feasible;
            }

            set
            {
                feasible = value;
            }
        }

    }
}
