using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication
{
    public class EventType
    {
        [Key]
        [MaxLength(50)]
        public string Name { get; set; }
        public string ClassName { get; set; }
        public string Color { get; set; }
    }
}