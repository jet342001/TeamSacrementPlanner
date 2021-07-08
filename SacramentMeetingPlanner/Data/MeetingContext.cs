using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public DbSet<SacramentMeetingPlanner.Models.Meeting> Meeting { get; set; }

        public DbSet<SacramentMeetingPlanner.Models.Speaker> Speaker { get; set; }
    }
}
