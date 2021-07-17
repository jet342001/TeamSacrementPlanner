using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SacramentMeetingPlanner.Models
{
    public class Meeting
    {
        [Required]
        public int MeetingId { get; set; }
        
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy - MM - dd}" )]
        [Display(Name = "Start At")]
        public DateTime StartAt { get; set; }

        [Required]
        public string Conductor { get; set; }
        
        [Required]
        [Display(Name = "Opening Song")]
        [Range(1, 342)]
        public int OpeningSongNumber { get; set; }

        [Required]
        [Display(Name = "Sacramental Song")]
        [Range(1, 342)]
        public int SacramentSongNumber { get; set; }

        [Required]
        [Display(Name = "Closing Song")]
        [Range(1, 342)]
        public int ClosingSongNumber { get; set; }
        
        [Display(Name = "Intermediate Song")]
        [Range(1, 341)]
        public int? IntermediateSongNumber { get; set; }
        
        [Display(Name = "Musical Number")]
        public string MusicalNumber { get; set; }
        
        [Required]
        [Display(Name = "Opening Prayer")]
        public string OpeningPrayerBy { get; set; }
        
        [Required]
        [Display(Name = "Closing Prayer")]
        public string ClosingPrayerBy { get; set; }

        public ICollection<Speaker> Speakers { get; set; }

    }
}
