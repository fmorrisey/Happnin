using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Event_App.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [ForeignKey("Interest")]
        public int InterestId { get; set; }

        [ForeignKey("IdentityUser")]
        public int IdentityUserId { get; set; }

        [ForeignKey("Address")]
        public string Venue { get; set; }

        [Display(Name = "Event Type")]
        public string EventType { get; set; }

        [Display(Name = "Event Date")]
        [DisplayFormat(DataFormatString = "{0:MMMM dd ddd h:mm t}", ApplyFormatInEditMode = true)]
        public DateTime? EventDate { get; set; }

        public string EventDescription { get; set; }

        public bool IsPrivate { get; set; }

        public bool IsVirtual { get; set; }

        public string City { get; set; }




    }
}
