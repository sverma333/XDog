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
            Color ret = Color.White;

            if (value is int)
            {
                int iVal = (int)value;

                if (iVal == 1) ret = Color.Black;
                if (iVal == 2) ret = Color.White;

                return ret;
            }

            if (value is bool)
            {
                bool bVal = (bool)value;

                if (bVal == false) ret = Color.Black;
                if (bVal == true) ret = Color.White;

                return ret;
            }

            return ret;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color cVal = (Color)value;
            if (targetType ==typeof(int))
            {
                int ret = 1;

                if (cVal == Color.Black) ret = 1;
                if (cVal == Color.White) ret = 2;

                return ret;
            }

            if (targetType ==typeof(bool))
            {
                bool bRet = false;

                if (cVal == Color.Black) bRet = false;
                if (cVal == Color.White) bRet = true;

                return bRet;
            }

            return 1;
        }
    }
}
