using System;

namespace MeetupWeather.Service.Configuration
{
    /// <summary>
    /// Settings for the application used at runtime.
    /// </summary>
    public class AppSettings : IAppSettings
    {
        /// <summary>
        /// Gets the meetup API URL.
        /// </summary>
        /// <value>
        /// The meetup API URL.
        /// </value>
        public string MeetupApiUrl => GetEnvironmentValue("MeetupApiUrl") ?? "https://api.meetup.com";

        /// <summary>
        /// Gets the meetup API token.
        /// </summary>
        /// <value>
        /// The meetup API token.
        /// </value>
        public string MeetupApiToken => GetEnvironmentValue("MeetupApiToken");

        /// <summary>
        /// Gets the weather API URL.
        /// </summary>
        /// <value>
        /// The weather API URL.
        /// </value>
        public string WeatherApiUrl => GetEnvironmentValue("WeatherApiUrl") ?? "https://www.metaweather.com/api/location";

        /// <summary>
        /// Gets the environment value provided the key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        /// Null if does not exist.
        /// </returns>
        public string GetEnvironmentValue(string key)
        {
            return Environment.GetEnvironmentVariable(key);
        }
    }
}
