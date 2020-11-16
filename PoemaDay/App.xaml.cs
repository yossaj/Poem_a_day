﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PoemaDay
{
    
    public partial class App : Application
    {
        public static string DatabaseLocation = string.Empty;
        public App(string databaseLocation)
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = (Color)App.Current.Resources["secondaryColor"]
            };
            DatabaseLocation = databaseLocation;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
