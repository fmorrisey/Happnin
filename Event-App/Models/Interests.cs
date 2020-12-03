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
        public string Music { get; set; }
        public string Food { get; set; }
        public string CommunityEvent { get; set; }
        public string Festival { get; set; }
        public string Party { get; set; }
        public string Football { get; set; }
        public string BasketBall { get; set; }
        public string BaseBall { get; set; }
        public string Running { get; set; }
        public string Biking  { get; set; }
        public string Hiking { get; set; }
        public string Play { get; set; }
        

    }
}
