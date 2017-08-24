using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeofenceWeb.Models
{
    public class AttendanceData
    {
        public int RecordId { get; set; }

        public int UserId { get; set; }

        public string TransitionName { get; set; }

        public DateTime TransitionTime { get; set; }
    }


}