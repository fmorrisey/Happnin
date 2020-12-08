using Microsoft.AspNetCore.Identity;
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

        [ForeignKey("Person")]
        public int PersonId { get; set; }
        public Person Person { get; set; }

        [Display(Name = "Event Name")]
        public string EventName { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }

        [ForeignKey("Interest")]
        public int InterestId { get; set; }
        public Interest Interest { get; set; }

        [Display(Name = "Event Date")]
        [DisplayFormat(DataFormatString = "{0:MMM dd ddd h:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime? EventDate { get; set; }

        [Display(Name = "Event Description")]
        public string EventDescription { get; set; }

        public bool IsPrivate { get; set; }

        public bool IsVirtual { get; set; }

        [NotMapped]
        public List<Interest> Interests { get; set; }

        [NotMapped]
        public List<Event> Events { get; set; }



    }
}
