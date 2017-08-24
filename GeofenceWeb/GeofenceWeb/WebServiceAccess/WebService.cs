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
                string url =string.Format("{0}{1}", rootUrl, "GetAttendanceCollection");
                /*HttpClient client = new HttpClient();
                
                HttpResponseMessage response = null;
                response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    col = JsonConvert.DeserializeObject<List<AttendanceData>>(response.Content.ToString());
                }
                else
                {
                    col = null;
                }*/
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
    }
}