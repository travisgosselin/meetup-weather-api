using System.Collections.Generic;
using MeetupWeather.Model.Meetups;

namespace MeetupWeather.Service.Meetups
{
    /// <summary>
    /// Interface for looking meetup.com information.
    /// </summary>
    public interface IMeetupService
    {
        /// <summary>
        /// Gets the meetup based on the URL Name (meetup url name).
        /// </summary>
        /// <param name="urlName">Name of the URL.</param>
        /// <returns>Meetup information.</returns>
        IList<MeetupEvent> GetMeetup(string urlName);
    }
}
