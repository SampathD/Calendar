
using System.Collections.Generic;

namespace Octet.Calendar.Dto
{
    /// <summary>
    /// Dto which contains subscriber details.
    /// </summary>
    public class SubscriberDto
    {
        /// <summary>
        /// Gets or sets the id of the subscriber.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the subscriber.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email of the subscriber.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets calendars subscribed by the subcriber.
        /// </summary>
        public virtual ICollection<CalendarDto> SubscribedCalendars { get; set; }
    }
}
