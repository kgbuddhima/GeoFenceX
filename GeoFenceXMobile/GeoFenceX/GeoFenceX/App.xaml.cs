using System;

using Xamarin.Forms;
using Geofence.Plugin;
using Geofence.Plugin.Abstractions;
using System.Collections.Generic;
using System.Diagnostics;
using System.Collections.ObjectModel;
using GeoFenceX.Helpers;

namespace GeoFenceX
{
    public partial class App : Application
    {

        public enum AppState
        {
            Foreground,
            Background
        }

        public App()
        {
            InitializeComponent();

            MainPage = new Views.GeoXPage();
        }

        protected override void OnStart()
        {
            //Application.Current.Properties ["AppState"] = AppState.Foreground;
            //SavePropertiesAsync ();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            //Application.Current.Properties ["AppState"] = AppState.Background;
            //SavePropertiesAsync ();
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
            //Application.Current.Properties ["AppState"] = AppState.Foreground;
            //SavePropertiesAsync ();
        }
    }
}
