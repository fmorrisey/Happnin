using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event_App.Models
{
    public class CreateEventViewModel
    {
        public Event NewEvent { get; set; }
        public Person CurrentPerson { get; set; }
        public SelectList Interests { get; set; }
        public Interest Interest { get; set; }
        public Address Venue { get; set; }

    }
}
