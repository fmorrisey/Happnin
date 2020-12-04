using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Event_App.Models
{
    public class PeopleEvents
    {
        [ForeignKey("EventId")]
        public int EventId;
        [ForeignKey("PersonId")]
        public int PersonId;

        public bool HasConfirmed { get; set; }
    }
}
