using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoFenceX.Models
{
    public class AttendanceData
    {
        public int RecordId { get; set; }

        public string Name { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public double Radius { get; set; }

        public int UserId { get; set; }

        public string TransitionName { get; set; }

        public DateTime TransitionTime { get; set; }
    }
}
