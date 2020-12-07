using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event_App.Models
{
    public class EventViewModel : PageModel
    {
        public Event EventEdit { get; set; }
        public Address Address { get; set; }
        public List<Interest> Interests { get; set; }

    }
}
