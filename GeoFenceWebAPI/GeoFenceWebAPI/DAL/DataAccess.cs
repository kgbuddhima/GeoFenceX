using System;
using System.Collections.Generic;
using System.Text;
using GeoFenceWebAPI.BusinessEntity;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace GeoFenceWebAPI
{
    public class DataAccess
    {
        public string _connectionString;
        IDbConnection conn { get; set; }

        public DataAccess()
        {
            _connectionString = ConfigurationManager.AppSettings["GeoFenceConString"];
        }

        public IDbConnection ConnectionDB
        {
            get
            {
                if (conn == null)
                    return new SqlConnection(_connectionString);
                return conn;
            }
        }

        /// <summary>
        /// Gel regions
        /// </summary>
        /// <returns></returns>
        public List<Region> GetGeoLocations()
        {
            List<Region> col = null;
            try
            {
                using (IDbConnection cn = ConnectionDB)
                {
                    cn.Open();
                    col = cn.Query<Region>("GetGeoRegions", commandType: CommandType.StoredProcedure).AsList();
                }
            }
            catch (Exception EX)
            {
                //  throw EX;
            }
            return col;
        }

        /// <summary>
        /// Get attendance data
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<AttendanceData> GetAtendanceData(int userId)
        {
            List<AttendanceData> col = null;
            try
            {
                using (IDbConnection cn = ConnectionDB)
                {
                    cn.Open();
                    col = cn.Query<AttendanceData>("GetAttendanceData", new { UserId = userId }, commandType: CommandType.StoredProcedure).AsList();
                }
            }
            catch (Exception ex)
            {
                // throw ex;
            }
            return col;
        }

        /// <summary>
        /// update attendance data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool UpdateAttendanceData(AttendanceData data)
        {
            try
            {
                int result = 0;
                using (IDbConnection cn = ConnectionDB)
                {
                    result = cn.Execute("UpdateAttendanceData",
                         new
                         {
                             UserId = data.UserId,
                             TransitionName = data.TransitionName,
                             Name = data.Name,
                             TransitionTime = data.TransitionTime
                         },
                         commandType: CommandType.StoredProcedure);
                }
                return Convert.ToBoolean(result);
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// add or update geo location
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool UpdateGeoLocation(Region data)
        {
            try
            {
                int result = 0;
                using (IDbConnection cn = ConnectionDB)
                {
                    result = cn.Execute("UpdateGeoLocation",
                         new
                         {
                             Name = data.Name,
                             Latitude = data.Latitude,
                             Longitude = data.Longitude,
                             Radius = data.Radius
                         },
                         commandType: CommandType.StoredProcedure);
                }
                return Convert.ToBoolean(result);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
