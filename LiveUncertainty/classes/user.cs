using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveUncertainty.classes
{
    public class User
    {
        String name;
        String initials;
        String job_Title;

        public User()
        {
            name = "John";
            initials = "JD";
            job_Title = "Measurement Engineer";

        }

        string Name
        {
            get => name;
            set => name = value;
        }

        String Initials
        {
            get => name;
            set => name = value;
        }

        String Job_Title
        {
            get => name;
            set => name = value;
        }
    }
}
