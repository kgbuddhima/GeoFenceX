using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GeofenceWeb.Models;

namespace GeofenceWeb.ViewModel
{
    public class AttendanceDataViewModel
    {
        public List<AttendanceData> AttendanceDataList { get; set; }

        public AttendanceData Attendance { get; set; }
    }
}