using System.Collections.Generic;
using Android.Gms.Maps.Model;
using XDogApp;
using XDogApp.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using System.Linq;
using Android.Content;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace XDogApp.Droid
{
    public class CustomMapRenderer : MapRenderer
    {
        public CustomMapRenderer(Context context) : base (context)
        {

        }

        List<Position> routeCoordinates;

        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                // Unsubscribe
            }

            if (e.NewElement != null)
            {
                var formsMap = (CustomMap)e.NewElement;
                routeCoordinates = formsMap.Route.ToList();
                Control.GetMapAsync(this);
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            var formsMap = (CustomMap)sender;
            routeCoordinates = formsMap.Route.ToList();
            Control.GetMapAsync(this);
        }

        protected override void OnMapReady(Android.Gms.Maps.GoogleMap map)
        {
            base.OnMapReady(map);

            var polylineOptions = new PolylineOptions();
            polylineOptions.InvokeColor(0x66FF0000);

            foreach (var position in routeCoordinates)
            {
                polylineOptions.Add(new LatLng(position.Latitude, position.Longitude));
            }

            NativeMap.AddPolyline(polylineOptions);
        }
    }

}