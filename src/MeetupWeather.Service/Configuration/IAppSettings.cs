namespace MeetupWeather.Service.Configuration
{
    /// <summary>
    /// Settings for the application used at runtime.
    /// </summary>
    public interface IAppSettings
    {
        /// <summary>
        /// Gets the meetup API URL.
        /// </summary>
        /// <value>
        /// The meetup API URL.
        /// </value>
        string MeetupApiUrl { get; }

        /// <summary>
        /// Gets the meetup API token.
        /// </summary>
        /// <value>
        /// The meetup API token.
        /// </value>
        string MeetupApiToken { get; }

        /// <summary>
        /// Gets the weather API URL.
        /// </summary>
        /// <value>
        /// The weather API URL.
        /// </value>
        string WeatherApiUrl { get; }
    }
}
