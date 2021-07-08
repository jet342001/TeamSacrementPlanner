using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Models
{
    public class Meeting
    {
        [Required]
        public int MeetingId { get; set; }
        public DateTime StartAt { get; set; }
        public string Conductor { get; set; }
        public string OpeningSong { get; set; }
        public int OpeningSongNumber { get; set; }
        public string SacramentSong { get; set; }
        public int SacramentSongNumber { get; set; }
        public string ClosingSong { get; set; }
        public int ClosingNumber { get; set; }
        public string IntermediateSong { get; set; }
        public int IntermediateSongNumber { get; set; }
        public string MusicalNumber { get; set; }
        public string OpeningPrayerBy { get; set; }
        public string ClosingPrayerBy { get; set; }
    }
}
