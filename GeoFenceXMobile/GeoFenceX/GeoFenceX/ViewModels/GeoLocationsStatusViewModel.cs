using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using GeoFenceX.Helpers;
using Geofence.Plugin.Abstractions;

namespace GeoFenceX
{
    public class GeoLocationsStatusViewModel
    {
        public ObservableCollection<Region> LocationStatusCollection { get; set; }

        public GeoLocationsStatusViewModel()
        {
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
        }

       
    }
}
    