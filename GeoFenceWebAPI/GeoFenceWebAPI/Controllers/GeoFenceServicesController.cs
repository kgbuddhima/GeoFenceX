using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GeoFenceWebAPI.BusinessEntity;
using Newtonsoft.Json;

namespace GeoFenceWebAPI.Controllers
{
    public class GeoFenceServicesController : ApiController
    {

        public GeoFenceServicesController()
        {

        }

        [HttpGet]
        public HttpResponseMessage GetRegionCollection()
        {
            try
            {
                DataAccess _dal = new DataAccess();

                List<Region> collection = _dal.GetGeoLocations();
                string responseMessage = string.Empty;
                if (collection != null)
                {
                    responseMessage = JsonConvert.SerializeObject(collection);
                    return Request.CreateResponse(HttpStatusCode.OK, collection);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }

            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        public HttpResponseMessage GetAttendanceCollection(int userId)
        {
            try
            {
                DataAccess _dal = new DataAccess();

                List<AttendanceData> collection = _dal.GetAtendanceData(userId);
                string responseMessage = string.Empty;
                if (collection != null)
                {
                    responseMessage = JsonConvert.SerializeObject(collection);
                    return Request.CreateResponse(HttpStatusCode.OK, collection);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }

            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [ActionName("UpdateAttendance")]
        [HttpPost]
        public HttpResponseMessage UpdateAttendance([FromBody]AttendanceData data)
        {
            try
            {
                DataAccess _dal = new DataAccess();

                bool result = _dal.UpdateAttendanceData(data);
                string responseMessage = "Saved";
                if (result)
                {
                    responseMessage = JsonConvert.SerializeObject(responseMessage);
                    return Request.CreateResponse(HttpStatusCode.OK, responseMessage);
                }
                else
                {
                    responseMessage = "Failed";
                    return Request.CreateResponse(HttpStatusCode.NotAcceptable, responseMessage);
                }
            }

            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [ActionName("UpdateGeoLocation")]
        [HttpGet]
        public HttpResponseMessage UpdateGeoLocation(string regionname, double radius, double lat, double lon)
        {
            try
            {
                Region data = new Region()
                {
                    Name =regionname,
                    Radius =radius,
                    Latitude =lat,
                    Longitude =lon
                };
                DataAccess _dal = new DataAccess();

                bool result = _dal.UpdateGeoLocation(data);
                string responseMessage = "Saved";
                if (result)
                {
                    responseMessage = JsonConvert.SerializeObject(responseMessage);
                    return Request.CreateResponse(HttpStatusCode.OK, responseMessage);
                }
                else
                {
                    responseMessage = "Failed";
                    return Request.CreateResponse(HttpStatusCode.NotAcceptable, responseMessage);
                }
            }

            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }

    //AttendanceData att = new AttendanceData()
    //{
    //    UserId=1,
    //    TransitionName="Entered",
    //    TransitionTime = DateTime.UtcNow,
    //    Name= "KesHome2",
    //    Radius=10,
    //    Latitude= 6.791989,
    //    Longitude= 79.949101,
    //    RecordId=0
    //};

    //string attend = JsonConvert.SerializeObject(att);
}
