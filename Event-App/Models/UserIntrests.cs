using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Event_App.Models
{
    public class UserIntrests
    {

        [Key]
        [ForeignKey("PersonId")]
        public int PersonId { get; set; }
        public Person person { get; set; }

        [Key]
        [ForeignKey("IntrestId")]
        public int IntrestId { get; set; }
        public Intrest intrest { get; set; }



    }
}
