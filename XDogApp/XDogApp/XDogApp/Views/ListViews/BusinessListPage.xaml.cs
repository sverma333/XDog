﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XDogApp.Models;
using XDogApp.Utils;
using XDogApp.ViewModels;

namespace XDogApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BusinessListPage : ContentPage
    {
        public BusinessListPage()
        {
            InitializeComponent();
        }
    }
}