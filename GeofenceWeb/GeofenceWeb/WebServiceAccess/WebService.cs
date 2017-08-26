using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GeofenceWeb.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Configuration;
using System.Net;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.IO;

namespace GeofenceWeb.WebServiceAccess
{
    public class WebService
    {
        const string rootUrl = "http://geofencewebapi20170824065048.azurewebsites.net/api/GeoFenceServices/";

        public WebService()
        {

        }

        public List<AttendanceData> GetAttendanceDataList()
        {
            List<AttendanceData> col = null;
            try
            {
                string url =string.Format("{0}{1}{2}", rootUrl, "GetAttendanceCollection?userId=","1");
                string rt;

                WebRequest request = WebRequest.Create(url);
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                rt = reader.ReadToEnd();


                if (!string.IsNullOrWhiteSpace(rt))
                {
                    col = JsonConvert.DeserializeObject<List<AttendanceData>>(rt);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return col;
        }

        public bool RegionSaved(Region region)
        {
            bool result = false;
            try
            {
                string url = string.Format("{0}{1}", rootUrl,
                    string.Format("UpdateGeoLocation?regionname={0}&radius={1}0&lat={2}&lon={3}",
                    region.Name,region.Radius,region.Latitude,region.Longitude));
                string rt;

                WebRequest request = WebRequest.Create(url);
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                rt = reader.ReadToEnd();
                string rt2 = string.Empty;
                if (!string.IsNullOrWhiteSpace(rt))
                {
                    rt2 = JsonConvert.DeserializeObject<string>(rt);
                    rt2 = Convert.ToString(rt2).Replace("\"","");
                }

                if (rt2 == "Saved")
                {
                    result = true;
                }

            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
    }
}