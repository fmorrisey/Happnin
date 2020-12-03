using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollectorWebApp.Models.Calendar
{
    public class Day
    {
        [Key]
        public int Id { get; set; }
        public string WeekDay { get; set; }
    }
}
