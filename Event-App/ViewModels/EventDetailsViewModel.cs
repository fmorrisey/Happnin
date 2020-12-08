using Event_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event_App.ViewModels
{
    public class EventDetailsViewModel
    {
        public Event EventDetails { get; set; }
        public Person CurrentPerson { get; set; }
        public Interest Interest { get; set; }
        public Address Venue { get; set; }

    }
}
