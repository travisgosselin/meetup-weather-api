using System.Net;

namespace MeetupWeather.Model.Http
{
    /// <summary>
    /// Content and status code returned from a url.
    /// </summary>
    public class HttpResultContent
    {
        /// <summary>
        /// Gets or sets the status code.
        /// </summary>
        /// <value>
        /// The status code.
        /// </value>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        public string Content { get; set; }
    }
}
