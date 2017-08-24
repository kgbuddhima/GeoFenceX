using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace GeoFenceWebAPI.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            
        }


        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }


       /* public HttpResponseMessage GetRegionCollection()
        {
            try
            {
               // HttpResponseMessage response = Request.CreateResponse();
                List<Region> collection = _dal.GetGeoLocations();
                string responseMessage = string.Empty;
                if (collection != null)
                {
                    responseMessage = JsonConvert.SerializeObject(collection);
                 //   return Request.CreateResponse(HttpStatusCode.OK, responseMessage);
                }
                else
                {
                    responseMessage = "";
                  //  return Request.CreateResponse(HttpStatusCode.OK, responseMessage);
                }

                /*if (stk.ErrorCode == "10000")

                {

                    return Request.CreateResponse(HttpStatusCode.OK, stk.ResponseMessage);

                }

                else

                {

                    return Request.CreateResponse(HttpStatusCode.OK, stk.ResponseMessage);

                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }*/
    }
}
