using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using GeofenceWeb.ViewModel;
using GeofenceWeb.WebServiceAccess;

namespace GeofenceWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AttendanceView()
        {
            WebService service = new WebService();
            AttendanceDataViewModel model = new AttendanceDataViewModel();
            try
            {
                model.AttendanceDataList = service.GetAttendanceDataList();
            }
            catch (Exception)
            {
                return View("Error");
            }
            // Attendance att = new Attendance();
            //  att.AttendanceCollection = new List<AttendanceData>();          
            return View("AttendanceView", model);
        }
    }
}