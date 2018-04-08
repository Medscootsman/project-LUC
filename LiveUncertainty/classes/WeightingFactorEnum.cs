using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveUncertainty.classes
{
    class WeightingFactorEnum : IEnumerator
    {

        // Enumerators are positioned before the first element
        // until the first MoveNext() call.
        int position = -1;
        private List<double> pathWeightingFactors;

        public WeightingFactorEnum(List<double> pathWeightingFactors)
        {
            this.pathWeightingFactors = pathWeightingFactors;
        }

        public bool MoveNext()
        {
            position++;
            return (position < pathWeightingFactors.Count);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public double Current
        {
            get
            {
                try
                {
                    return pathWeightingFactors[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }


    }
}
