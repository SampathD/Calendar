using System.Data.Entity;

namespace Octet.Calendar.Data
{
    public class CalendarContext : DbContext
    {
        public CalendarContext()
            : base("CalendarDBConnectionString")
        {
            Database.SetInitializer<CalendarContext>(new CreateDatabaseIfNotExists<CalendarContext>());
            Configuration.LazyLoadingEnabled = false;

        }

        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Calendar>()
                   .HasMany(c => c.Subscribers)
                   .WithMany(s => s.SubscribedCalendars)
                   .Map(cs =>
                   {
                       cs.MapLeftKey("CalendarRefId");
                       cs.MapRightKey("SubscriberRefId");
                       cs.ToTable("CalendarSubscribs");
                   });
        }
    }
}
