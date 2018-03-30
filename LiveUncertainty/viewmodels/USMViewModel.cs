using LiveUncertainty.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveUncertainty.viewmodels
{
    public class USMViewModel
    {
        USM meter;

        /// <summary>
        /// Creates a view model for manipulating the object
        /// </summary>
        /// <param name="meter"></param>
        public USMViewModel(USM meter)
        {
            this.meter = meter;
        }

        public bool Updatable
        {
            get;
            set;
        }



    }
}
