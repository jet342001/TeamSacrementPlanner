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
        public string Name { get; set; }
        public string Subject { get; set; }
        public int Order { get; set; }
    }
}
