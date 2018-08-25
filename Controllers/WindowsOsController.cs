using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Web.Http;
using System.Security.Principal;

namespace OpenDriftApi.Controllers
{
    /// <summary>
    /// This controller helps to manage all types of windows operations.
    /// </summary>
    [RoutePrefix("api/windows")]
    public class WindowsOsController : ApiController
    {
        /// <summary>
        /// Get windows login and OS details
        /// </summary>
        /// <returns></returns>
        [Route("user")]
        [HttpGet]
        public HttpResponseMessage GetWindowsLoginDetails()
        {
            var user = WindowsIdentity.GetCurrent();
            return Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(user.Name));
        }


        /// <summary>
        /// Get system mac address i.e. Physical Address.
        /// </summary>
        /// <returns></returns>
        [Route("mac")]
        [HttpGet]
        public HttpResponseMessage GetSystemMac()
        {
            String firstMacAddress = NetworkInterface
                                        .GetAllNetworkInterfaces()
                                        .Where(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                                        .Select(nic => nic.GetPhysicalAddress().ToString())
                                        .FirstOrDefault();

            return Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(firstMacAddress));
        }
    }
}
