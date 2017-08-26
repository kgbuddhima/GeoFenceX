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
using GeoFenceX.WebServices;
using GeoFenceX.Models;

namespace GeoFenceX.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GeoXPage : ContentPage
    {
        List<GeofenceCircularRegion> regionCollectionCircular = new List<GeofenceCircularRegion>();

        GeoLocationsStatusViewModel model;
        ObservableCollection<Region> userPlacesCollection;
        IGeoService _service;

        public GeoXPage()
        {
            InitializeComponent();
            _service = new GeoService();
            model = new GeoLocationsStatusViewModel();
            this.BindingContext = model;

            GetUserregionCollection();
            userPlacesCollection = model.LocationStatusCollection;

            listView.ItemsSource = userPlacesCollection;

           /* MessagingCenter.Subscribe<GeofenceResult>(this, "region", async (region) =>
            {
                await DisplayAlert("Region", region.TransitionName, "OK", "Cancel");
                Region p = new Region()
                {
                    Name = region.TransitionName.ToString() + "|" + region.RegionId,
                    Latitude = region.Latitude,
                    Longitude = region.Longitude,
                    LastEnteredTime = (DateTime)region.LastEnterTime,
                    LastExitedTime = (DateTime)region.LastExitTime
                };
                model.LocationStatusCollection.Add(p);

                AttendanceData att = new AttendanceData()
                {
                    Name = region.RegionId,
                    Latitude = region.Latitude,
                    Longitude = region.Longitude,
                    TransitionName = region.TransitionName,
                    TransitionTime = region.TransitionName== GeofenceTransition.Exited.ToString() ? p.LastExitedTime:p.LastEnteredTime,
                    UserId =1
                };
                await UpdateAttendanceAsync(att);
            });*/
        }

        protected override void OnAppearing()
        {
            
        }

        /// <summary>
        /// Send attendance data to api
        /// </summary>
        /// <param name="attendance"></param>
        private async Task UpdateAttendanceAsync(AttendanceData attendance)
        {
            try
            {
                await _service.UpdateAttendenceAsync(attendance);
            }
            catch (Exception ex)
            {

               // throw;
            }
        }

        /// <summary>
        /// Get Regions to monitor
        /// </summary>
        private async void GetUserregionCollection()
        {
            CrossGeofence.GeofencePriority = GeofencePriority.HighAccuracy;
            List<Region> regions = await _service.GetGeoLocationsAsync();
            foreach (Region r in regions)
            {
                CrossGeofence.Current.StartMonitoring(new GeofenceCircularRegion(r.Name, r.Latitude, r.Longitude, r.Radius)
                {
                    NotifyOnEntry = true,
                    NotifyOnExit = true,
                    ShowEntryNotification = true,
                    ShowExitNotification = true,
                    ShowNotification = true,
                    Persistent = true,
                    NotificationStayMessage = "stay !" + r.Name,
                    NotificationEntryMessage = "entry !"+r.Name,
                    NotificationExitMessage = "exit !"+r.Name,
                    NotifyOnStay = true,
                    StayedInThresholdDuration = TimeSpan.FromSeconds(1)
                });
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                GeofenceResult result = new GeofenceResult()
                {
                    Transition = GeofenceTransition.Exited,
                    RegionId = "Depot",
                    Latitude = 0,
                    Longitude = 0,
                    LastEnterTime = DateTime.Now.AddMinutes(-5),
                    LastExitTime = DateTime.Now                    
                };

                MessagingCenter.Send(result, "region");
                /* AttendanceData att = new AttendanceData()
                 {
                     Name = "Depot",
                     Latitude = 0,
                     Longitude = 0,
                     TransitionName = GeofenceTransition.Exited.ToString(),
                     TransitionTime = DateTime.Now,
                     UserId = 1
                 };
                 await UpdateAttendanceAsync(att);*/

                /*  model.LocationStatusCollection.Clear();

                  IReadOnlyDictionary<string, GeofenceCircularRegion> Regions = CrossGeofence.Current.Regions;
                  foreach (GeofenceCircularRegion g in Regions.Values)
                  {
                      Region p = new Region()
                      {
                          Name = g.Id,
                          Latitude = g.Latitude,
                          Longitude = g.Longitude,
                       //   LastEnteredTime = g..ToString(),
                       //   LastExitedTime = g.LastExitTime.ToString()
                      };
                      model.LocationStatusCollection.Add(p);
                  }*/
            }
            catch (Exception ex)
            {
                await DisplayAlert("",ex.Message,"OK");
            }
        }

        
    }
}

/*
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
            */
