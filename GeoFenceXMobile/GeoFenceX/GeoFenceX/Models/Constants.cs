using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoFenceX.Models
{
    public static class Constants
    {
        // URL of REST service
        public static string urlGetLocationList = "http://geofencewebapi20170824065048.azurewebsites.net/api/GeoFenceServices/GetRegionCollection";
        public static string urlUpdateAttendence = "http://geofencewebapi20170824065048.azurewebsites.net/api/GeoFenceServices/UpdateAttendance";
        // Credentials that are hard coded into the REST service
        public static string Username = "Xamarin";
        public static string Password = "Pa$$w0rd";

        public static string S_Exists = "EXIST";
        public static string S_OK = "OK";
        public static string S_NotSuccess = "NOT_SUCCESS";
    }
}
