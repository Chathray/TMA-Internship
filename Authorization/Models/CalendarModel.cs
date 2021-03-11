using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class CalendarModel
    {
        public CalendarModel() { }
        public CalendarModel(IList<EventType> a, IList<Event> b)
        {
            ET = a;
            E = b;
        }
        public IList<EventType> ET { get; set; }
        public IList<Event> E { get; set; }

        public string Creator { get; set; }

    }
}
