using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoFenceX.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace GeoFenceX.WebServices
{
    public class GeoService:IGeoService
    {
        HttpClient client;

        public GeoService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        /// <summary>
        /// Get Geo Location List Async from API
        /// </summary>
        /// <returns></returns>
        public async Task<List<Place>> GetGeoLocationsAsync()
        {
            List<Place> col = new List<Place>();
            try
            {
                string strContent = "GetRegionList";
                var json = JsonConvert.SerializeObject(strContent);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await client.PostAsync(Constants.urlUpdateAttendence, content);

                if (response.IsSuccessStatusCode)
                {
                    // result = Constants.S_OK;
                    col = JsonConvert.DeserializeObject<List<Place>>(Convert.ToString(response.Content));
                }
                else
                {
                   // result = Constants.S_NotSuccess;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return col;
        }

        /// <summary>
        /// Update user's attendence data by sending them to API
        /// </summary>
        /// <param name="attendenceData"></param>
        /// <returns></returns>
        public async Task<string> UpdateAttendence(AttendenceData attendenceData)
        {
            string result = Constants.S_NotSuccess;
            try
            {
                
                var json = JsonConvert.SerializeObject(attendenceData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await client.PostAsync(Constants.urlUpdateAttendence, content);

                if (response.IsSuccessStatusCode)
                {
                    result = Constants.S_OK;
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
