using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event_App.Models
{
    interface IEventFeedRepository
    {
        Event GetEvent(int Id);
        
    }
}
