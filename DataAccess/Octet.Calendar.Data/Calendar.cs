using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Octet.Calendar.Data
{
    /// <summary>
    /// Entity which represensts a calendar.
    /// </summary>
    [Table("Calendars")]
    public class Calendar
    {
        /// <summary>
        /// Gets or sets the id of the calendar.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the calendar.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Base64 string of the icon which represents the calendar.
        /// </summary>
        [Required]
        public string Icon { get; set; }

        /// <summary>
        /// Gets or sets whether calendar is active or not.
        /// </summary>
        [Required]
        [DefaultValue(true)]
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets subcribers subscribed to the calendar.
        /// </summary>
        public virtual ICollection<Subscriber> Subscribers { get; set; }
    }
}
