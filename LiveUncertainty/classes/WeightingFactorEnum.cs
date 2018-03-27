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
        public double[] _factors;

        // Enumerators are positioned before the first element
        // until the first MoveNext() call.
        int position = -1;
        private List<double> pathWeightingFactors;

        public WeightingFactorEnum(double[] list)
        {
            _factors = list;
        }

        public WeightingFactorEnum(List<double> pathWeightingFactors)
        {
            this.pathWeightingFactors = pathWeightingFactors;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _factors.Length);
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
                    return _factors[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }


    }
}
