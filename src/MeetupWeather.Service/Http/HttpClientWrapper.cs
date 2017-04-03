using System;
using System.Net.Http;
using System.Net.Http.Headers;
using MeetupWeather.Model.Http;
namespace MeetupWeather.Service.Http
{
    /// <summary>
    /// Wrapper for functionality in the HttpClient for DI and testing.
    /// </summary>
    /// <seealso cref="IHttpClient" />
    public class HttpClientWrapper : IHttpClient
    {
        /// <summary>
        /// Performs a GET request on the provided URL and returns the content.
        /// Media request type if application/json.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>Status code and content of the page (body).</returns>
        public HttpResultContent GetUrlContent(string url)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var result = client.GetAsync(string.Empty).Result;

                return new HttpResultContent
                {
                    StatusCode = result.StatusCode,
                    Content = result.Content.ReadAsStringAsync().Result
                };
            }
        }
    }
}