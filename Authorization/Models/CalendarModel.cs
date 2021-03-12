using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using WebApplication.Models;
using Newtonsoft.Json;

namespace WebApplication.Models
{
    public class CalendarModel
    {
        public CalendarModel() { }
        public CalendarModel(IList<EventType> a, IList<User> b)
        {
            EvenTypes = a;
            Usesr = b;
        }
        public IList<EventType> EvenTypes { get; set; }
        public IList<User> Usesr { get; set; }

        public string Creator { get; set; }


        public string Title { get; set; }
        public string Type { get; set; }
        public string Deadline { get; set; }
        public string RepeatField { get; set; }
        public string GestsField { get; set; }
        public string EventLocationLabel { get; set; }
        public string EventDescriptionLabel { get; set; }


        public string GetUserList()
        {
            return JsonConvert.SerializeObject(Usesr);
        }
    }   
}