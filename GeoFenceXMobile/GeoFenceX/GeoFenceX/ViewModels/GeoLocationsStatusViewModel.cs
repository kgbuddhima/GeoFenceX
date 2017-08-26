using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using GeoFenceX.Helpers;
using Geofence.Plugin.Abstractions;
using GeoFenceX.Models;
using GeoFenceX.WebServices;

namespace GeoFenceX
{
    public class GeoLocationsStatusViewModel
    {
        IGeoService _service;
        public ObservableCollection<Region> LocationStatusCollection { get; set; }

        public GeoLocationsStatusViewModel()
        {
            _service = new GeoService();
            LocationStatusCollection = new ObservableCollection<Region>();

            MessagingCenter.Subscribe<GeofenceLocation>(this, "location", (location) =>
            {
                Region p = new Region()
                {
                    Name = "location",
                    Latitude = location.Latitude,
                    Longitude = location.Longitude,
                    LastEnteredTime = location.Date,
                    LastExitedTime = location.Date
                };
                LocationStatusCollection.Add(p);
            });

            MessagingCenter.Subscribe<GeofenceResult>(this, "region", (region) =>
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
                LocationStatusCollection.Add(p);

                /* AttendanceData att = new AttendanceData()
                 {
                     Name = region.RegionId,
                     Latitude = region.Latitude,
                     Longitude = region.Longitude,
                     TransitionName = region.TransitionName,
                     TransitionTime = region.TransitionName == GeofenceTransition.Exited.ToString() ? p.LastExitedTime : p.LastEnteredTime,
                     UserId = 1
                 };*/
                //  await UpdateAttendanceAsync(att);
            });


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


    }
}
    