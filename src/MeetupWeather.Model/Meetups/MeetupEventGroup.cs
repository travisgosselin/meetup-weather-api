namespace MeetupWeather.Model.Meetups
{
    /// <summary>
    /// Meetup.com reference to the group used for a location.
    /// </summary>
    public class MeetupEventGroup
    {
        /// <summary>
        /// Gets or sets the lat.
        /// </summary>
        /// <value>
        /// The lat.
        /// </value>
        public decimal Lat { get; set; }

        /// <summary>
        /// Gets or sets the lon.
        /// </summary>
        /// <value>
        /// The lon.
        /// </value>
        public decimal Lon { get; set; }
    }
}
