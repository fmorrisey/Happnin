using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Event_App.Models
{
    public class UserInterests
    {

        [Key]
        [ForeignKey("PersonId")]
        public int PersonId { get; set; }
        public Person person { get; set; }

        [Key]
        [ForeignKey("InterestId")]
        public int InterestId { get; set; }
        public Interests Interests { get; set; }
       
    }
}
