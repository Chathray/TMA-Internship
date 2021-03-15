using System.ComponentModel.DataAnnotations;

namespace WebApplication
{
    public class Event
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string CreatedDate { get; set; }
        public string GestsField { get; set; }
        public string RepeatField { get; set; }
        public string EventLocationLabel { get; set; }
        public string EventDescriptionLabel { get; set; }
        public string Image { get; set; }
    }
}