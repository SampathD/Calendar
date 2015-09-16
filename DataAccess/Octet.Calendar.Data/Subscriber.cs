
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Octet.Calendar.Data
{
    /// <summary>
    /// Entity which represensts a subscriber.
    /// </summary>
    [Table("Subscribers")]
    public class Subscriber
    {
        /// <summary>
        /// Gets or sets the id of the subscriber.
        /// </summary>
        [Key]
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
        public virtual ICollection<Calendar> SubscribedCalendars { get; set; }

    }
}
