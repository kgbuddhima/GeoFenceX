using GeoFenceX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoFenceX.WebServices
{
    public interface IGeoService
    {
        /// <summary>
        /// Get Geo Location List Async
        /// </summary>
        /// <returns></returns>
        Task<List<Place>> GetGeoLocationsAsync();

        /// <summary>
        /// Update user's attendence data by sending them to API
        /// </summary>
        /// <param name="attendenceData"></param>
        /// <returns></returns>
        Task<string> UpdateAttendence(AttendenceData attendenceData);
    }
}
