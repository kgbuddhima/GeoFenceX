using Geofence.Plugin;
using Geofence.Plugin.Abstractions;
using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geofence;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace GeoFenceX.Helpers
{
    //Class to handle geofence events such as start/stop monitoring, region state changes and errors.
    public class CrossGeofenceListener : IGeofenceListener
    {

        public void OnAppStarted()
        {
            //  Debug.WriteLine(string.Format("{0}", CrossGeofence.Id));
        }

        public void OnMonitoringStarted(string region)
        {
           // Debug.WriteLine(string.Format("{0} - {1}: {2}", CrossGeofence.Id, "Monitoring in region", region));
        }

        public void OnMonitoringStopped()
        {
          //  Debug.WriteLine(string.Format("{0} - {1}", CrossGeofence.Id, "Monitoring stopped for all regions"));
        }

        public void OnMonitoringStopped(string identifier)
        {
           // Debug.WriteLine(string.Format("{0} - {1}: {2}", CrossGeofence.Id, "Monitoring stopped in region", identifier));
        }

        public void OnError(string error)
        {
           // Debug.WriteLine(string.Format("{0} - {1}: {2}", CrossGeofence.Id, "Error", error));
        }

        public void OnRegionStateChanged(GeofenceResult result)
        {
            // The problem is this event firing does not work.. -- buddhima
            if (result.Transition == GeofenceTransition.Exited || result.Transition == GeofenceTransition.Entered)
            {
                // If this event fires, it will send the region resut using messaging center
                MessagingCenter.Send(result, "region");
            }
        }

        public void OnLocationChanged(GeofenceLocation location)
        {
            //  Debug.WriteLine(string.Format("{0} la-{1} Lo={2}", CrossGeofence.Id, location.Latitude,location.Longitude));
          //  MessagingCenter.Send(location, "location");
          
        }
    }
}
