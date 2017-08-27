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

            try
            {

                GetUserregionCollection();
                userPlacesCollection = model.LocationStatusCollection;
            }
            catch (Exception ex)
            {
                DisplayAlert("Error loading", ex.Message, "OK");
            }


            listView.ItemsSource = userPlacesCollection;

            /// Catch the region status change and send Attendance record to API
           MessagingCenter.Subscribe<GeofenceResult>(this, "region", async (region) =>
            {
               // await DisplayAlert("Region", region.TransitionName, "OK", "Cancel");
                Region p = new Region()
                {
                    Name = region.TransitionName.ToString() + "|" + region.RegionId,
                    Latitude = region.Latitude,
                    Longitude = region.Longitude,
                    LastEnteredTime = (DateTime)region.LastEnterTime,
                    LastExitedTime = (DateTime)region.LastExitTime
                };
                // add region status resut to list
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
                // send record to API
                await UpdateAttendanceAsync(att);
            });
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

        /// <summary>
        /// Send Region change using Messaging Center and then it will be call to API
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            }
            catch (Exception ex)
            {
                await DisplayAlert("",ex.Message,"OK");
            }
        }

        /// <summary>
        /// Show All monitoring Regions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowRegions_Clicked(object sender, EventArgs e)
        {
            try
            {
                IReadOnlyDictionary<string, GeofenceCircularRegion> results =  CrossGeofence.Current.Regions;
                if (results!=null)
                {
                    foreach (GeofenceCircularRegion r in results.Values)
                    {
                        model.LocationStatusCollection.Add(new Region
                        {
                            Name = r.Id,
                            Latitude = r.Latitude, Longitude=r.Longitude,
                            Radius = r.Radius
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("btnShowRegions", ex.Message, "OK");
            }
        }

        /// <summary>
        /// Send Sample atendance record to API
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnSendSample_ClickedAsync(object sender, EventArgs e)
        {
            try
            {
                AttendanceData att = new AttendanceData()
                {
                    Name = "Test Region",
                    Latitude =6.02,
                    Longitude = 79.01,
                    TransitionName = GeofenceTransition.Stayed.ToString(),
                    TransitionTime = DateTime.Now,
                    UserId = 1
                };
                await UpdateAttendanceAsync(att);
            }
            catch (Exception ex)
            {
                await DisplayAlert("btnSendSample", ex.Message, "OK");
            }
        }
    }
}