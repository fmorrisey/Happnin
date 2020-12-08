using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event_App.Models
{
    public class EventViewModel : PageModel
    {
        
        public Person Host { get; set; }
        public List<Event> Events { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Interest> Interests { get; set; }

    }
}
