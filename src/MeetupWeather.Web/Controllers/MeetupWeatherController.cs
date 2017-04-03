using System.Linq;
using MeetupWeather.Service.Meetups;
using MeetupWeather.Service.Weather;
using Microsoft.AspNetCore.Mvc;

namespace MeetupWeather.Web.Controllers
{
    /// <summary>
    /// API for retrieving the weather on event days of a particular meetup.
    /// </summary>
    [Route("[controller]")]
    public class MeetupWeatherController : Controller
    {
        private readonly IMeetupService _meetupService;
        private readonly IWeatherService _weatherService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MeetupWeatherController"/> class.
        /// </summary>
        /// <param name="meetupService">The meetup service.</param>
        /// <param name="weatherService">The weather service.</param>
        public MeetupWeatherController(IMeetupService meetupService, IWeatherService weatherService)
        {
            _meetupService = meetupService;
            _weatherService = weatherService;
        }

        /// <summary>
        /// Gets the specified meetup event URL.
        /// </summary>
        /// <param name="meetupEventUrl">The meetup event URL.</param>
        /// <returns>Event and weather state.</returns>
        [HttpGet]
        [Route("{meetupEventUrl}")]
        public dynamic Get(string meetupEventUrl)
        {
            // find this meetup events if we can
            var events =  _meetupService.GetMeetup(meetupEventUrl);
            if (events == null)
            {
                Response.StatusCode = 404;
                return new {Message = $"Could not found Meetup with URL Name {meetupEventUrl}"};
            }

            // convert the events to weather
            return events.Select(t => new { Event = t, Weather = _weatherService.GetWeatherForLatLong(t.Group.Lat, t.Group.Lon, t.EventDate) ?? "Unavailable" });
        }
    }
}
