using System;
using System.Collections.Generic;
using System.Text;

namespace GeoFenceWebAPI.BusinessEntity
{
    public class AttendanceData : Region
    {
        public int RecordId { get; set; }

        public int UserId { get; set; }

        public string TransitionName { get; set; }

        public DateTime TransitionTime { get; set; }

    }
}
