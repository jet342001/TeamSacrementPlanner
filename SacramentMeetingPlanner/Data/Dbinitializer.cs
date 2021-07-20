using System;
using System.Collections.Generic;
using SacramentMeetingPlanner.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Data
{
    public class Dbinitializer
    {
        public static void Initialize(MeetingContext context)
        {

            // Look for any Meetings.
            if (context.Meeting.Any())
            {
                return;   // DB has been seeded
            }

            var meetings = new Meeting[]
            {
                new Meeting
                {
                    StartAt = DateTime.Parse("2010-09-01"),
                    Conductor = "Brittney Spears",
                    OpeningSongNumber = 1,
                    SacramentSongNumber = 113,
                    ClosingSongNumber = 1,
                    IntermediateSongNumber = 0,
                    OpeningPrayerBy = "Jeffery Epsen",
                    ClosingPrayerBy = "Gislene Maxwell", 
                },
                new Meeting
                {
                    StartAt = DateTime.Parse("2021-07-18"),
                    Conductor = "Alexander Hamilton",
                    OpeningSongNumber = 3,
                    SacramentSongNumber = 118,
                    ClosingSongNumber = 243,
                    IntermediateSongNumber = 12,
                    OpeningPrayerBy = "Benjamin Franklin",
                    ClosingPrayerBy = "James Madison"
                },
                new Meeting
                {
                    StartAt = DateTime.Parse("2021-07-25"),
                    Conductor = "Jeremy Bevin",
                    OpeningSongNumber = 5,
                    SacramentSongNumber = 123,
                    ClosingSongNumber = 32,
                    IntermediateSongNumber = 333,
                    OpeningPrayerBy = "Andrew phelps",
                    ClosingPrayerBy = "Bethany hughs"
                },
                new Meeting
                {
                    StartAt = DateTime.Parse("2021-08-01"),
                    Conductor = "Stephen Gee",
                    OpeningSongNumber = 7,
                    SacramentSongNumber = 99,
                    ClosingSongNumber = 3,
                    IntermediateSongNumber = 342,
                    MusicalNumber = "Sidney Rodrigues Sing your favorite hymn",
                    OpeningPrayerBy = "Gene Higgins",
                    ClosingPrayerBy = "Andrew Brower"
                },

            };


            foreach (Meeting m in meetings)
            {
                context.Meeting.Add(m);
            }
            context.SaveChanges();

            var speakers = new Speaker[]
{
            new Speaker { MeetingId = 1, Name = "Alphonzo Belsnap",  Subject = "Prayer and Fasting", Order = 1, Meeting = meetings[0] },
            new Speaker { MeetingId = 1, Name = "Anna Marie Belsnap",  Subject = "Hope", Order = 2, Meeting = meetings[0] },
            new Speaker { MeetingId = 1, Name = "Alphonzo Belsnap",  Subject = "Meal prep in the apocolypse", Order = 3, Meeting = meetings[0] },
            new Speaker { MeetingId = 2, Name = "Jill Hansen",  Subject = "Breakfast", Order = 1, Meeting = meetings[1] },
            new Speaker { MeetingId = 2, Name = "Poppy seed",  Subject = "Lunch", Order = 2, Meeting = meetings[1] },
            new Speaker { MeetingId = 2, Name = "Albert Reyes",  Subject = "Dinner", Order = 3, Meeting = meetings[1] },
            new Speaker { MeetingId = 3, Name = "Happ Hearted",  Subject = "Never Give uup", Order = 1, Meeting = meetings[2] },
            new Speaker { MeetingId = 3, Name = "Appo Sider",  Subject = "Life water", Order = 2, Meeting = meetings[2] },
            new Speaker { MeetingId = 3, Name = "Perry grin falkin",  Subject = "Meal prep in the apocolypse", Order = 3 , Meeting = meetings[2] },
};

            foreach (Speaker s in speakers)
            {
                context.Speaker.Add(s);
            }
            context.SaveChanges();
        }
    }
}
