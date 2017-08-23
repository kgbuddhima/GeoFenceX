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
        public ObservableCollection<Place> LocationStatusCollection { get; set; }

        public GeoLocationsStatusViewModel()
        {
            LocationStatusCollection = new ObservableCollection<Place>();

            

            MessagingCenter.Subscribe<GeofenceLocation>(this, "location", (location) =>
            {
                Place p = new Place()
                {
                    Name = "location",
                    Latitude = location.Latitude,
                    Longitude = location.Longitude,
                    LastEnteredTime = location.Date.ToString(),
                    LastExitedTime = location.Date.ToString()
                };
                LocationStatusCollection.Add(p);
            });
        }

       
    }
}
    