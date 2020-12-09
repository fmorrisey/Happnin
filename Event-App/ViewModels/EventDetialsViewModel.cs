using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event_App.Models
{
    public class EventDetialsViewModel
    {
        public Event deatilEvent { get; set; }
        public Person host { get; set; }
        public Interest interest { get; set; }
        public Address address { get; set; }
        public List<Interest> Interests { get; set; }

    }
}
