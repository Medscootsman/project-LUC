using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace LiveUncertainty.classes.Converters
{
    class DoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
     {
            if(value.ToString().EndsWith("."))
            {
                return ".";
            }
            else if(value.ToString().EndsWith("0"))
            {
                return "0" + value;
            }
            else
            {
                return value;
            }
        }
    }
}
