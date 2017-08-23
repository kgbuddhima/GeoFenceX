using Geofence.Plugin.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using Geofence.Plugin;
using System.Collections.ObjectModel;

namespace GeoFenceX.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GeoXPage : ContentPage
    {
        List<GeofenceCircularRegion> regionCollectionCircular = new List<GeofenceCircularRegion>();

        GeoLocationsStatusViewModel model;
        ObservableCollection<Place> userPlacesCollection;


        public GeoXPage()
        {
            InitializeComponent();

            model = new GeoLocationsStatusViewModel();
            this.BindingContext = model;

            GetUserregionCollection();

            userPlacesCollection = model.LocationStatusCollection;

            CrossGeofence.Current.StartMonitoring(regionCollectionCircular);
            CrossGeofence.GeofencePriority = GeofencePriority.HighAccuracy;
            listView.ItemsSource = userPlacesCollection;


            MessagingCenter.Subscribe<GeofenceResult>(this, "region", (region) =>
            {
                DisplayAlert("Region", region.TransitionName, "OK","Cancel");
                Place p = new Place()
                {
                    Name = region.TransitionName + "|" + region,
                    Latitude = region.Latitude,
                    Longitude = region.Longitude,
                    LastEnteredTime = region.LastEnterTime.ToString(),
                    LastExitedTime = region.LastExitTime.ToString()
                };
                model.LocationStatusCollection.Add(p);
            });
        }

        protected override void OnAppearing()
        {
            
        }

            /// <summary>
            /// Get Regions to monitor
            /// </summary>
            private void GetUserregionCollection()
        {
            regionCollectionCircular.Add(new GeofenceCircularRegion("KesHome1", 6.79145087, 79.9490901, 10, true, true, true, true, true, true, true)
            {
                NotificationStayMessage = "stay message!",
                NotificationEntryMessage = "entry message!",
                NotificationExitMessage = "exit message!",
                NotifyOnStay = true,
                StayedInThresholdDuration = TimeSpan.FromSeconds(5)
            });

            regionCollectionCircular.Add(new GeofenceCircularRegion("KesHome2", 6.791989, 79.949101, 10, true, true, true, true, true, true, true)
            {
                NotificationStayMessage = "stay message!",
                NotificationEntryMessage = "entry message!",
                NotificationExitMessage = "exit message!",
                NotifyOnStay = true,
                StayedInThresholdDuration = TimeSpan.FromSeconds(5)
            });

            regionCollectionCircular.Add(new GeofenceCircularRegion("Depot", 6.791989, 79.948155, 10, true, true, true, true, true, true, true)
            {
                NotificationStayMessage = "stay message!",
                NotificationEntryMessage = "entry message!",
                NotificationExitMessage = "exit message!",
                NotifyOnStay = true,
                StayedInThresholdDuration = TimeSpan.FromSeconds(5)
            });
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {

                model.LocationStatusCollection.Clear();

                IReadOnlyDictionary<string, GeofenceCircularRegion> Regions = CrossGeofence.Current.Regions;
                foreach (GeofenceCircularRegion g in Regions.Values)
                {
                    Place p = new Place()
                    {
                        Name = g.Id,
                        Latitude = g.Latitude,
                        Longitude = g.Longitude,
                     //   LastEnteredTime = g..ToString(),
                     //   LastExitedTime = g.LastExitTime.ToString()
                    };
                    model.LocationStatusCollection.Add(p);
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("",ex.Message,"OK");
            }
          

        }

        
    }
}