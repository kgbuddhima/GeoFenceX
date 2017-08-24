using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeofenceWeb.Models
{
    public class Region
    {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Radius { get; set; }
    }

    public class Regions:Region
    {
        public List<Region> RegionCollection { get; set; }
    }
}