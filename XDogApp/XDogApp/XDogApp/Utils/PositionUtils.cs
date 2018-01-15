using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace XDogApp.Utils
{
    public static class PositionUtils
    {

        public static double DistanceBetween(Position p1, Position p2, bool bUseMetric)
        {
            return distance(p1.Latitude, p1.Longitude, p2.Latitude, p2.Longitude, (bUseMetric ? 'K' : 'M'));
        }

        public static double TotalDistanceBetween(List<Position> lstPos, bool bUseMetric)
        {
            double ret = 0;
            for (int i = 1; i < lstPos.Count; i++)
                ret += DistanceBetween(lstPos[i - 1], lstPos[i], bUseMetric);

            return ret;
        }


        #region calc code
        //  unit = 'M' is miles (default), 'K' is km, 'N' is nautical miles
        //  http://www.geodatasource.com/developers/c-sharp
        private static double distance(double lat1, double lon1, double lat2, double lon2, char unit)
        {
            double theta = lon1 - lon2;
            double dist = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta));
            dist = Math.Acos(dist);
            dist = rad2deg(dist);
            dist = dist * 60 * 1.1515;

            if (unit == 'K')
                dist = dist * 1.609344;
            else if (unit == 'N')
  	            dist = dist * 0.8684;

            return dist;
        }

        private static double deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        private static double rad2deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }
        #endregion
    }
}
