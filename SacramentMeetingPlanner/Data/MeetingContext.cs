using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Data
{
    public class MeetingContext : DbContext
    {
        public MeetingContext (DbContextOptions<MeetingContext> options)
            : base(options)
        {
        }

        public DbSet<Meeting> Meeting { get; set; }

        public DbSet<Speaker> Speaker { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Speaker>().ToTable("Speaker");
            modelBuilder.Entity<Meeting>().ToTable("Meeting");

            //modelBuilder.Entity<Speaker>()
            //    .HasKey(c => new { c.SpeakerId, c.MeetingId });

            modelBuilder.Entity<Meeting>().HasMany(m => m.Speakers).WithOne(s=> s.Meeting);
        }
    }
}
