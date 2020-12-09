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
        [ForeignKey("Person")]
        public int PersonId1;

        [ForeignKey("Person")]
        public int PersonId2;

        public bool isPending { get; set; }
        public bool isAccepted { get; set; }
    }
}
