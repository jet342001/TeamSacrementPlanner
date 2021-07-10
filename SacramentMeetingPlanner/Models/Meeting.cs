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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy - MM - dd}" )]
        [Display(Name = "Start Time")]
        public DateTime StartAt { get; set; }
        public string Conductor { get; set; }
        [Required]
        [Display(Name = "Opening Song")]
        public string OpeningSong { get; set; }
        [Required]
        [Display(Name = "Opening Song Number")]
        [Range(0, 342)]
        public int OpeningSongNumber { get; set; }
        [Required]
        [Display(Name = "Sacrament Song")]
        public string SacramentSong { get; set; }
        [Display(Name = "Sacrament Song Number")]
        [Range(0, 342)]
        public int SacramentSongNumber { get; set; }
        [Display(Name = "Closing Song")]
        public string ClosingSong { get; set; }
        [Display(Name = "Closing Song Number")]
        [Range(0, 342)]
        public int ClosingNumber { get; set; }
        [Display(Name = "Intermediate Song")]
        public string IntermediateSong { get; set; }
        [Display(Name = "Intermediate Song Number")]
        [Range( 0, 341)]
        public int? IntermediateSongNumber { get; set; }
        [Display(Name = "Musical Number")]
        public string MusicalNumber { get; set; }
        [Required]
        [Display(Name = "Opening Prayer")]
        public string OpeningPrayerBy { get; set; }
        [Required]
        [Display(Name = "Closing Prayer")]
        public string ClosingPrayerBy { get; set; }
    }
}
