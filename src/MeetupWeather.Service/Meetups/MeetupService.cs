using System;
using System.Collections.Generic;
using System.Net;
using System.Security;
using MeetupWeather.Model.Meetups;
using MeetupWeather.Service.Configuration;
using MeetupWeather.Service.Http;
using Newtonsoft.Json;

namespace MeetupWeather.Service.Meetups
{
    /// <summary>
    /// Meetup service provides access to Meetup.com information given an API key.
    /// </summary>
    public class MeetupService : IMeetupService
    {
        private readonly IHttpClient _httpClient;
        private readonly IAppSettings _appSettings;

        public MeetupService(IHttpClient client, IAppSettings settings)
        {
            _httpClient = client;
            _appSettings = settings;
        }

        /// <summary>
        /// Gets the meetup based on the URL Name (meetup url name).
        /// </summary>
        /// <param name="urlName">Name of the URL.</param>
        /// <returns>Meetup information.</returns>
        public IList<MeetupEvent> GetMeetup(string urlName)
        {
            // validate the parameters
            if (string.IsNullOrWhiteSpace(urlName))
            {
                throw new ArgumentNullException(nameof(urlName));
            }

            // find the meetup if it exists
            var meetupUrl = $"{_appSettings.MeetupApiUrl}/{urlName}/events/?key={_appSettings.MeetupApiToken}";
            var response = _httpClient.GetUrlContent(meetupUrl);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                // null is indication on the contract this does not exist for URL name.
                return null;
            }

            // determine if this was not properly authorized
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new SecurityException("Provided meetup.com key returned an unauthorized response: 401.");
            }

            // if the results failed for any other reason, no idea what happened.
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception($"Unknown error occurred processing meetup.com request. Status code: { response.StatusCode } with content: { response.Content }");
            }

            // if here, then the response was good, lets parse it.
            return JsonConvert.DeserializeObject<List<MeetupEvent>>(response.Content);
        }
    }
}
