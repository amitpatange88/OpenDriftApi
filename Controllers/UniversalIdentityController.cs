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
    /// This controller helps to manage all types of universal identity operations.
    /// </summary>
    [RoutePrefix("api/unniversalidentity")]
    public class UniversalIdentityController : ApiController
    {
        /// <summary>
        /// Get universal IDENTITY as unique id here
        /// </summary>
        /// <returns></returns>
        [Route("uuid")]
        [HttpGet]
        public HttpResponseMessage GetUniversalUniqueIdentityNumber()
        {
            return Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(Guid.NewGuid().ToString()));
        }
    }
}
