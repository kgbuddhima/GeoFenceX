using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoFenceX
{
    public class Region
    {
        public Region()
        {

        }

        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Radius { get; set; }
        public DateTime LastEnteredTime { get; set; }
        public DateTime LastExitedTime { get; set; }
        public string Location { get => Latitude.ToString()+" " + Longitude.ToString(); }

    }
}
