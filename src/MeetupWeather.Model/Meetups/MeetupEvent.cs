using System;

namespace MeetupWeather.Model.Meetups
{
    /// <summary>
    /// Represents a Meetup Event from meetup.com api.
    /// </summary>
    public class MeetupEvent
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the status of the event. eg. "upcoming"
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the group.
        /// </summary>
        /// <value>
        /// The group.
        /// </value>
        public MeetupEventGroup Group { get; set; }

        /// <summary>
        /// Gets or sets the time of the event in epoch MS
        /// </summary>
        /// <value>
        /// The time.
        /// </value>
        public long Time { get; set; }

        /// <summary>
        /// Gets the event date.
        /// </summary>
        /// <value>
        /// The event date.
        /// </value>
        public DateTime EventDate => new DateTime(1970, 1, 1).AddMilliseconds(Time);
    }
}
