using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OpenDriftApi.Controllers
{
    /// <summary>
    /// This controller helps to manage all types of datetime operations.
    /// Here first we are getting all timezone dates based on specified datetime.
    /// </summary>
    [RoutePrefix("api/datetime")]
    public class DateTimeController : ApiController
    {
        /// <summary>
        /// Get all timezone list here
        /// </summary>
        /// <returns></returns>
        [Route("timezones")]
        [HttpGet]
        public HttpResponseMessage GetTimeZoneList()
        {
            List<TimeZone> timeZones = new List<TimeZone>();
            var localtime = DateTime.Now;
            foreach (TimeZoneInfo z in TimeZoneInfo.GetSystemTimeZones())
            {
                var dataTimeByZoneId = TimeZoneInfo.ConvertTime(localtime, TimeZoneInfo.Local, TimeZoneInfo.FindSystemTimeZoneById(z.Id.ToString()));
                timeZones.Add(new TimeZone { ID = z.Id, DisplayName = z.DisplayName, BaseUtcOffset = z.BaseUtcOffset.ToString(), TIMESTAMP = dataTimeByZoneId.ToString() });
            }

            return Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(timeZones));
        }
    }

    /// <summary>
    /// TimeZone class
    /// </summary>
    public class TimeZone
    {
        [JsonProperty("ID")]
        public string ID { get; set; }

        [JsonProperty("DisplayName")]
        public string DisplayName { get; set; }

        [JsonProperty("UTCOffset")]
        public string BaseUtcOffset { get; set; }

        [JsonProperty("Timestamp")]
        public string TIMESTAMP { get; set; }
    }
}
