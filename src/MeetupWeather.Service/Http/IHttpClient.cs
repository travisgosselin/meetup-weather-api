using MeetupWeather.Model.Http;

namespace MeetupWeather.Service.Http
{
    /// <summary>
    /// Interface to wrap an HttpClient for the purposes if dependency injection and testing.
    /// </summary>
    public interface IHttpClient
    {
        /// <summary>
        /// Performs a GET request on the provided URL and returns the content.
        /// Media request type if application/json.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>Status code and content of the page (body).</returns>
        HttpResultContent GetUrlContent(string url);
    }
}
