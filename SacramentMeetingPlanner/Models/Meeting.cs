﻿using System;
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
        [Display(Name = "Start At")]
        public DateTime StartAt { get; set; }
        [Required]
        public string Conductor { get; set; }
        [Required]
        [Display(Name = "Opening Song")]
        [Range(1, 342)]
        public int OpeningSongNumber { get; set; }
        [Display(Name = "Sacramental Song")]
        [Range(1, 342)]
        public int SacramentSongNumber { get; set; }
        [Display(Name = "Closing Song")]
        [Range(1, 342)]
        public int ClosingNumber { get; set; }
        [Display(Name = "Intermediate Song")]
        [Range(1, 341)]
        public int? IntermediateSongNumber { get; set; }
        [Display(Name = "Closing Song")]
        public int ClosingSongNumber { get; set; }
        [Display(Name = "Intermediate Song")]
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
