using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveUncertainty.classes
{
    public class Gas
    {
        private int ID;
        private string name;
        private string code; //not really relevant
        private double comp;
        private double molWeight;
        private double sqrtB;

        public Gas(string name, string code, double comp, double weight, double sqrtB)
        {
            this.name = name;
            this.code = code;
            this.comp = comp;
            molWeight = weight;
            this.sqrtB = sqrtB;
        }

        public int id
        {
            get
            {
                return id;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Code
        {
            get
            {
                return code;
            }

            set
            {
                code = value;
            }
        }

        public double MolWeight
        {
            get
            {
                return molWeight;
            }

            set
            {
                molWeight = value;
            }
        }

        public double Composition
        {
            get
            {
                return comp;
            }

            set
            {
                comp = value;
            }
        }

        public double SqrtB
        {
            get
            {
                return sqrtB;
            }

            set
            {
                sqrtB = value;
            }
        }
    }
}
