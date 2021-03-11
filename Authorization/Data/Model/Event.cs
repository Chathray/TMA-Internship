using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication
{
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Type { get; set; }

        public string Title { get; set; }

        public string Start { get; set; }

        public string End { get; set; }

        public string EventDescriptionLabel { get; set; }

        public string EventLocationLabel { get; set; }

        public string RepeatField { get; set; }

        public string GestsField { get; set; }

        public string Image { get; set; }


        public string ClassName { get; set; }
        [ForeignKey("ClassName")]
        public EventType EventTypes { get; set; }
    }
}