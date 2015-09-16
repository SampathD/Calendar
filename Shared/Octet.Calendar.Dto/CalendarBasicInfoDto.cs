
namespace Octet.Calendar.Dto
{
    /// <summary>
    /// Dto whcih contains basic info about calendar.
    /// </summary>
    public class CalendarBasicInfoDto
    {
        /// <summary>
        /// Gets or sets the id of the calendar.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the calendar.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Base64 string of the icon which represents the calendar.
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// Gets or sets count of the subcribers subscribed to the calendar.
        /// </summary>
        public int SubscriberCount { get; set; }
    }
}
