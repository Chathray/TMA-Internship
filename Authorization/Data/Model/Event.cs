using System;
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
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(100)]
        public string Type { get; set; }
        [MaxLength(15)]
        public string Start { get; set; }
        [MaxLength(15)]
        public string End { get; set; }
        public bool AllDay { get; set; }
        [MaxLength(100)]
        public string GestsField { get; set; }
        [MaxLength(100)]
        public string RepeatField { get; set; }
        [MaxLength(100)]
        public string EventLocationLabel { get; set; }
        [MaxLength(250)]
        public string EventDescriptionLabel { get; set; }


        //
        public string Image { get; set; }

        public string ClassName { get; set; }
        [ForeignKey("ClassName")]
        public EventType EventTypes { get; set; }
    }
}