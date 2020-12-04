using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Event_App.Models
{
    public class Friends
    {
        [ForeignKey("IdentityUserId")]
        public int IdentityUserId;

        [ForeignKey("PersonId")]
        public int PersonId;

        public bool isPending { get; set; }
        public bool isAccepted { get; set; }
    }
}
