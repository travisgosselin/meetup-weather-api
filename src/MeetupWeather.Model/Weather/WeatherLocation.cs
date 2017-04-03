using Newtonsoft.Json;

namespace MeetupWeather.Model.Weather
{
    /// <summary>
    /// A specific weather location with its name.
    /// </summary>
    public class WeatherLocation
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the location identifier.
        /// </summary>
        /// <value>
        /// The location identifier.
        /// </value>
        [JsonProperty("woeid")]
        public int LocationId { get; set; }
    }
}
