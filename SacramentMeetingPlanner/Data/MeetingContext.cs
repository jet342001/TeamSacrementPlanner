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
    }
}
