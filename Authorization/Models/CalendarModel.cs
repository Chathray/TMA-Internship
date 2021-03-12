using System.Collections.Generic;

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



        public string Title { get; set; }
        public string Type { get; set; }
        public string Deadline { get; set; }
        public string GestsField { get; set; }
        public string RepeatField { get; set; }
        public string EventLocationLabel { get; set; }
        public string EventDescriptionLabel { get; set; }
    }
}
