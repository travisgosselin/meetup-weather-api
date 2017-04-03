using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using MeetupWeather.Model.Weather;
using MeetupWeather.Service.Configuration;
using MeetupWeather.Service.Http;
using Newtonsoft.Json;

namespace MeetupWeather.Service.Weather
{
    /// <summary>
    /// Weather lookup by lat long location and a specified time.
    /// </summary>
    /// <seealso cref="MeetupWeather.Service.Weather.IWeatherService" />
    public class WeatherService : IWeatherService
    {
        private readonly IHttpClient _httpClient;
        private readonly IAppSettings _appSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherService"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="settings">The settings.</param>
        public WeatherService(IHttpClient client, IAppSettings settings)
        {
            _httpClient = client;
            _appSettings = settings;
        }

        /// <summary>
        /// Gets the weather for lat long at a specified time..
        /// </summary>
        /// <param name="lat">The lat.</param>
        /// <param name="lon">The lon.</param>
        /// <param name="date">The date.</param>
        /// <returns>
        /// The weather state string name.
        /// </returns>
        public string GetWeatherForLatLong(decimal lat, decimal lon, DateTime date)
        {
            // first, determien if there is an associated location with the lat lon
            var primaryLocation = GetLocation(lat, lon);
            if (primaryLocation == null)
            {
                return null;
            }

            // if we have a location then find the weather for it.
            var weather = GetWeather(primaryLocation.LocationId, date);
            return weather?.StateName;
        }

        /// <summary>
        /// Gets the location.
        /// </summary>
        /// <param name="lat">The lat.</param>
        /// <param name="lon">The lon.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        private WeatherLocation GetLocation(decimal lat, decimal lon)
        {
            // find the first location for this lat long (closest)
            var meetupUrl = $"{_appSettings.WeatherApiUrl}/search/?lattlong={ lat },{ lon }";
            var response = _httpClient.GetUrlContent(meetupUrl);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                // null is indication on the contract this does not exist for this lat lon
                return null;
            }

            // if the results failed for any other reason, no idea what happened.
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception($"Unknown error occurred processing weather location request. Status code: { response.StatusCode } with content: { response.Content }");
            }

            // if here, then the response was good, lets parse it.
            var listOfLocations = JsonConvert.DeserializeObject<List<WeatherLocation>>(response.Content);
            return listOfLocations.FirstOrDefault();
        }

        /// <summary>
        /// Gets the weather.
        /// </summary>
        /// <param name="locationId">The location identifier.</param>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        private WeatherInformation GetWeather(int locationId, DateTime date)
        {
            // find the first location for this lat long (closest)
            var meetupUrl = $"{_appSettings.WeatherApiUrl}/{ locationId }/{ date.Year }/{ date.Month }/{ date.Day }";
            var response = _httpClient.GetUrlContent(meetupUrl);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                // null is indication on the contract this does not exist for this lat lon
                return null;
            }

            // if the results failed for any other reason, no idea what happened.
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception($"Unknown error occurred processing weather at this date time. Status code: { response.StatusCode } with content: { response.Content }");
            }

            // if here, then the response was good, lets parse it.
            var weatherInformation = JsonConvert.DeserializeObject<List<WeatherInformation>>(response.Content);
            return weatherInformation.FirstOrDefault();
        }
    }
}
