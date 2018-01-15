using XDogApp;
using XDogApp.UWP;
using System.Collections.Generic;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml.Controls.Maps;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.UWP;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace XDogApp.UWP
{
    public class CustomMapRenderer : MapRenderer
    {
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            var formsMap = (CustomMap)sender;
            DrawLines(formsMap);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                // Unsubscribe
            }

            if (e.NewElement != null)
            {
                var formsMap = (CustomMap)e.NewElement;
                DrawLines(formsMap);
            }
        }

        private void DrawLines(CustomMap formsMap)
        {

            var nativeMap = Control as MapControl;
            if (formsMap.Route.Count == 0)
            {
                nativeMap.MapElements.Clear();
                return;
            }

            var coordinates = new List<BasicGeoposition>();
            foreach (var position in formsMap.Route)
                coordinates.Add(new BasicGeoposition() { Latitude = position.Latitude, Longitude = position.Longitude });

            var polyline = new MapPolyline();
            polyline.StrokeColor = Windows.UI.Color.FromArgb(128, 255, 0, 0);
            polyline.StrokeThickness = 5;
            polyline.Path = new Geopath(coordinates);
            nativeMap.MapElements.Add(polyline);
        }


    }
}
