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
        public async Task<List<Region>> GetGeoLocationsAsync()
        {
            List<Region> col = new List<Region>();
            try
            {
                HttpResponseMessage response = null;
                response = await client.GetAsync(Constants.urlGetLocationList);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    col = JsonConvert.DeserializeObject<List<Region>>(content);
                }
                else
                {
                    col = null;
                }
            }
            catch (Exception ex)
            {
               // throw;
            }
            return col;
        }

        /// <summary>
        /// Update user's attendence data by sending them to API
        /// </summary>
        /// <param name="attendenceData"></param>
        /// <returns></returns>
        public async Task<string> UpdateAttendenceAsync(AttendanceData attendenceData)
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
