using Newtonsoft.Json;

namespace MeetupWeather.Model.Weather
{
    /// <summary>
    /// Weather information expected for a given location.
    /// </summary>
    public class WeatherInformation
    {
        /// <summary>
        /// Gets or sets the name of the state.
        /// </summary>
        /// <value>
        /// The name of the state.
        /// </value>
        [JsonProperty("weather_state_name")]
        public string StateName { get; set; }

        /// <summary>
        /// Gets or sets the maximum temperature.
        /// </summary>
        /// <value>
        /// The maximum temperature.
        /// </value>
        [JsonProperty("max_temp")]
        public decimal MaxTemperature { get; set; }
    }
}
