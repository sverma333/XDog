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
            Color ret = Color.Red;
            if (value is int)
            {
                int iVal = (int)value;

                if (iVal == 1) ret = Color.White;
                if (iVal == 2) ret = Color.Red;
            }

            if (value is bool)
            {
                bool bVal = (bool)value;

                if (bVal == false) ret = Color.White;
                if (bVal == true) ret = Color.Red;
            }

            return ret;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color cVal= (Color)value;

            if (targetType ==typeof(int))
            {
                int iRet = 1;

                if (cVal == Color.White) iRet = 1;
                if (cVal == Color.Red) iRet = 2;

                return iRet;
            }

            if (targetType ==typeof(bool))
            {
                bool bRet = false;
                if (cVal == Color.White) bRet = false;
                if (cVal == Color.Red) bRet = true;

                return bRet;
            }

            return 1;
        }
    }
}
