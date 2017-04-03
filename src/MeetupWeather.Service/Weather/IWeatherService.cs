using System;

namespace MeetupWeather.Service.Weather
{
    /// <summary>
    /// Allows lookup of weather information by lat long / and date.
    /// </summary>
    public interface IWeatherService
    {
        /// <summary>
        /// Gets the weather for lat long at a specified time..
        /// </summary>
        /// <param name="lat">The lat.</param>
        /// <param name="lon">The lon.</param>
        /// <param name="date">The date.</param>
        /// <returns>The weather state string name.</returns>
        string GetWeatherForLatLong(decimal lat, decimal lon, DateTime date);
    }
}
