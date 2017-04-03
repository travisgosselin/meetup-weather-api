using Microsoft.AspNetCore.Mvc;

namespace MeetupWeather.Web.Controllers
{
    /// <summary>
    /// Up controller handles health monitoring components.
    /// </summary>
    [Route("[controller]")]
    public class UpController : Controller
    {
        /// <summary>
        /// Standard UP status check for automation and health monitoring.
        /// </summary>
        /// <param name="chain">Indicates if integration check should be performed as well.</param>
        /// <returns>Dynamic, with health information. i.e. status: happy </returns>
        [HttpGet]
        public dynamic Get(bool chain = false)
        {
            return new { status = "happy" };
        }
    }
}
