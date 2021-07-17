using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Models
{
    public class Speaker
    {
        [Required]
        public int SpeakerId { get; set; }

        public int MeetingId { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string Subject { get; set; }
        [Required]
        [Range(0, 5)]
        public int Order { get; set; }

        public Meeting Meeting { get; set; }
    }
}
