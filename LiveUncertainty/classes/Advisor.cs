using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.MachineLearning;
using Newtonsoft.Json.Linq;

namespace LiveUncertainty
{
    class Advisor
    {
        public double uncertaintyTarget;
        
        public double reductionPotential;
        public KNearestNeighbors KNN;
        public bool feasible;

        public Advisor()
        {
            KNN = new KNearestNeighbors();
        }

        public void Analyse()
        {

        }

        public void extractFeatures()
        {
            
        }

        public void Train()
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
