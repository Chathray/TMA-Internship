﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication
{
    public class EventType
    {
        [Key]
        public string Type { get; set; }
        public string ClassName { get; set; }
        public string Color { get; set; }
    }
}