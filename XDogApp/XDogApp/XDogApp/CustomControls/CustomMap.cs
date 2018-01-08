using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace XDogApp
{
    public class CustomMap : Map
    {

        // Route bindable property
        public static readonly BindableProperty RouteProperty = BindableProperty.Create(nameof(Route), typeof(ObservableCollection<Position>), typeof(CustomMap), new ObservableCollection<Position>(), BindingMode.OneWay, propertyChanged: RouteChanged);
        public ObservableCollection<Position> Route { get { return (ObservableCollection<Position>)base.GetValue(RouteProperty); }
            set { base.SetValue(RouteProperty, value); Route.CollectionChanged += NotifyCollectionChanged;} }
        // end of Route bindable property

        // IsRecording bindable property
        public static readonly BindableProperty IsRecordingProperty = BindableProperty.Create(nameof(IsRecording), typeof(bool), typeof(CustomMap), default(bool), BindingMode.TwoWay, propertyChanged: IsRecordingChanged);
        public bool IsRecording { get { return (bool)base.GetValue(IsRecordingProperty); } set { base.SetValue(IsRecordingProperty, value); } }
        // end of IsRecording bindable property

        private static void IsRecordingChanged(BindableObject bindable, object oldValue, object newValue)
        {
            handleChange(bindable as CustomMap);
        }



        private static void RouteChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var m = bindable as CustomMap;
            m.Route.CollectionChanged += m.NotifyCollectionChanged;

            handleChange(bindable as CustomMap);
        }

        private  void NotifyCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            handleChange(this);
        }

        private static void handleChange(CustomMap m)
        {
            if (m == null) return;

            m.Pins.Clear();
            if (m.Route.Count > 0)
            {
                m.MoveToRegion(MapSpan.FromCenterAndRadius(m.Route.Last(), Distance.FromMiles(1.0)));
                m.Pins.Add(new Pin() { Position = m.Route.First(), Label = "Starting Point" });
            }

            if (m.Route.Count > 1)
                m.Pins.Add(new Pin() { Position = m.Route.Last(), Label = (m.IsRecording ? "Current Location" : "Ending Point") });
        }


        //public List<Position> RouteCoordinates { get; set; }


        public CustomMap ()
        {
            //Route = new List<Position> ();
            //Pins = new List<Pin> ();
        }

        //protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    base.OnPropertyChanged(propertyName);
        //    if (propertyName =="RouteCoordinates")
        //        if (RouteCoordinates.Count > 0)
        //            MoveToRegion (MapSpan.FromCenterAndRadius (RouteCoordinates.Last(), Distance.FromMiles (1.0)));
        //}

    }
}
