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
        public int IntrestId { get; set; }
<<<<<<< HEAD
        public Interests Interests { get; set; }
=======
        public Interests interests { get; set; }
>>>>>>> a31b681bc3699d1bdc76b2cc0892833d007d71a1



    }
}
