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
        [Display(Name = "Start At")]
        public DateTime StartAt { get; set; }
        public string Conductor { get; set; }
        [Display(Name = "Opening Song")]
        public int OpeningSongNumber { get; set; }
        [Display(Name = "Sacramental Song")]
        public int SacramentSongNumber { get; set; }
        [Display(Name = "Closing Song")]
        public int ClosingSongNumber { get; set; }
        [Display(Name = "Intermediate Song")]
        public int? IntermediateSongNumber { get; set; }
        [Display(Name = "Musical Number")]
        public string MusicalNumber { get; set; }
        [Display(Name = "Opening Prayer")]
        public string OpeningPrayerBy { get; set; }
        [Display(Name = "Closing Prayer")]
        public string ClosingPrayerBy { get; set; }
    }
}
