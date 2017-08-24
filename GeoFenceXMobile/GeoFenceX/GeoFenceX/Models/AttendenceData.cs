using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoFenceX.Models
{
    public class AttendanceData:Region
    {
        public int UserId { get; set; }

        public string TransitionName { get; set; }

        public DateTime TransitionTime { get; set; }
    }
}
