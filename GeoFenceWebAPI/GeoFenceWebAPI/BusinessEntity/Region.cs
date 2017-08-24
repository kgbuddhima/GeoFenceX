using System;
using System.Collections.Generic;
using System.Text;

namespace GeoFenceWebAPI.BusinessEntity
{
    public class Region
    {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Radius { get; set; }
    }
}
