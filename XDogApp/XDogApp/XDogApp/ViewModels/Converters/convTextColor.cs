using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XDogApp.ViewModels.Converters
{
    public class convTextColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int iVal = (int)value;
            Color ret = Color.White;

            if (iVal == 1) ret = Color.Black;
            if (iVal == 2) ret = Color.White;

            return ret;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color cVal = (Color)value;
            int ret = 1;

            if (cVal == Color.Black) ret = 1;
            if (cVal == Color.White) ret = 2;

            return ret;
        }
    }
}
