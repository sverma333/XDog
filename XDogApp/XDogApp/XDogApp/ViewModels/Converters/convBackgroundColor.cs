using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XDogApp.ViewModels.Converters
{
    public class convBackgroundColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int iVal = (int)value;
            Color ret = Color.Red;

            if (iVal == 1) ret = Color.White;
            if (iVal == 2) ret = Color.Red;

            return ret;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color cVal= (Color)value;
            int ret = 1;

            if (cVal == Color.White) ret = 1;
            if (cVal == Color.Red) ret = 2;

            return ret;
        }
    }
}
