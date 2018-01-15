using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XDogApp;

namespace XDogApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SlideMenu : ContentView
    {
        public SlideMenu()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            MyListView.ItemsSource = new ObservableCollection<string>{"Item 1","Item 2","Item 3","Item 4","Item 5"};
        }


        // DefaultHeight bindable property
        public static readonly BindableProperty DefaultHeightProperty = BindableProperty.Create(nameof(DefaultHeight), typeof(double), typeof(SlideMenu), default(double), BindingMode.TwoWay, propertyChanged: DefaultHeightChanged);
        public double DefaultHeight { get { return (double)base.GetValue(DefaultHeightProperty); } set { base.SetValue(DefaultHeightProperty, value); } }
        // end of DefaultHeight bindable property

        // DefaultWidth bindable property
        public static readonly BindableProperty DefaultWidthProperty = BindableProperty.Create(nameof(DefaultWidth), typeof(double), typeof(SlideMenu), default(double), BindingMode.TwoWay, propertyChanged: DefaultWidthChanged);
        public double DefaultWidth { get { return (double)base.GetValue(DefaultWidthProperty); } set { base.SetValue(DefaultWidthProperty, value); } }
        // end of DefaultWidth bindable property

        // IsSlideOpen bindable property
        public static readonly BindableProperty IsSlideOpenProperty = BindableProperty.Create(nameof(IsSlideOpen), typeof(bool), typeof(SlideMenu), default(bool), BindingMode.TwoWay, propertyChanged: IsSlideOpenClose);
        public bool IsSlideOpen { get { return (bool)base.GetValue(IsSlideOpenProperty); } set { base.SetValue(IsSlideOpenProperty, value); } }
        // end of IsSlideOpen bindable property

        // Mode bindable property
        public static readonly BindableProperty ModeProperty = BindableProperty.Create(nameof(Mode), typeof(string), typeof(SlideMenu), default(string), BindingMode.TwoWay, propertyChanged: ModeChanged);
        public string Mode { get { return (string)base.GetValue(ModeProperty); } set { base.SetValue(ModeProperty, value); } }
        // end of Mode bindable property

        // Items bindable property
        public static readonly BindableProperty ItemsProperty = BindableProperty.Create(nameof(Items), typeof(ObservableCollection<string>), typeof(SlideMenu), default(ObservableCollection<string>), BindingMode.TwoWay, propertyChanged: ItemsChanged);
        public ObservableCollection<string> Items { get { return (ObservableCollection<string>)base.GetValue(ItemsProperty); } set { base.SetValue(ItemsProperty, value); } }
        // end of Items bindable property

        private static void ItemsChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //TODO Implement method
        }




        private static void ModeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            SlideMenu m = bindable as SlideMenu;
            if (m == null) return;

            if (newValue.ToString() == "Top")
            {
                m.HeightRequest = 600;
                m.MainStackLayout.HorizontalOptions = LayoutOptions.FillAndExpand;
                m.MainStackLayout.VerticalOptions = LayoutOptions.End;
                m.slideLength = 400;
                m.slideSpeed = 400;
                m.easingStyleIn = m.easingStyleOut = Easing.SpringOut;
            }
            else if (newValue.ToString() == "Bottom")
            {
                m.HeightRequest = 600;
                m.MainStackLayout.HorizontalOptions = LayoutOptions.FillAndExpand;
                m.MainStackLayout.VerticalOptions = LayoutOptions.End;
                m.slideLength = 400;
                m.slideSpeed = 400;
                m.easingStyleIn = m.easingStyleOut = Easing.SpringOut;
            }
            else if (newValue.ToString() == "Left")
            {
                m.WidthRequest = 600;
                m.MainStackLayout.HorizontalOptions = LayoutOptions.Start;
                m.MainStackLayout.VerticalOptions = LayoutOptions.FillAndExpand;
                m.slideLength = 400;
                m.slideSpeed = 400;
                m.easingStyleIn = m.easingStyleOut = Easing.SpringOut;
            }
            else if (newValue.ToString() == "Message")
            {
                m.HeightRequest = 80;
                m.slideLength = 300;
                m.slideSpeed = 250;
                m.easingStyleIn = Easing.SinInOut;
                m.easingStyleOut = Easing.SinInOut;

            }
        }




        private int slideLength = 400;
        private uint slideSpeed = 250;
        private Easing easingStyleIn = Easing.CubicInOut;
        private Easing easingStyleOut = Easing.CubicInOut;

        private static async void IsSlideOpenClose(BindableObject bindable, object oldValue, object newValue)
        {
            SlideMenu m = bindable as SlideMenu;
            if (m == null) return;

            if (m.Mode == "Top")
            {
                if ((bool)newValue)
                {
                    m.IsVisible = true;
                    await m.TranslateTo(0, App.ScreenHeight - m.slideLength, m.slideSpeed, m.easingStyleIn);
                    newValue = false;
                }
                else
                {
                    await m.TranslateTo(0, App.ScreenHeight, m.slideSpeed, m.easingStyleOut);
                    m.IsVisible = false;
                    newValue = true;

                }
            }
            else if (m.Mode == "Bottom")
            {
                if ((bool)newValue)
                {
                    m.IsVisible = true;
                    await m.TranslateTo(0, App.ScreenHeight - m.slideLength, m.slideSpeed, m.easingStyleIn);
                    newValue = false;
                }
                else
                {
                    await m.TranslateTo(0, App.ScreenHeight, m.slideSpeed, m.easingStyleOut);
                    m.IsVisible = false;
                    newValue = true;

                }
            }
            else if (m.Mode == "Left")
            {
                if ((bool)newValue)
                {
                    m.IsVisible = true;
                    await m.TranslateTo(App.ScreenWidth - m.slideLength, 0, m.slideSpeed, m.easingStyleIn);
                    newValue = false;
                }
                else
                {
                    await m.TranslateTo(App.ScreenWidth, m.slideSpeed, 0, m.easingStyleOut);
                    m.IsVisible = false;
                    newValue = true;

                }

            }

        }


        private static void DefaultWidthChanged(BindableObject bindable, object oldValue, object newValue)
        {
            SlideMenu m = bindable as SlideMenu;
            if (m == null) return;

            m.IsVisible = false;
            m.TranslationX = (double)newValue;
        }


        private static void DefaultHeightChanged(BindableObject bindable, object oldValue, object newValue)
        {
            SlideMenu m = bindable as SlideMenu;
            if (m == null) return;

            m.IsVisible = false;
            m.TranslationY = (double)newValue;

        }
    }
}