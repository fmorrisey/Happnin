using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Event_App.Models
{
    public class Interests
    {
        [Key]
        public int InterestId { get; set; }

        [Display(Name = "Interest Description")]
        public string InterestType { get; set; }

    }
}
