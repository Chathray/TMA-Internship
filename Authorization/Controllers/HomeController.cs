using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataAdapter _adapter;
        private readonly IMapper _mapper;

        public HomeController(DataContext context, ILogger<HomeController> logger, IMapper mapper)
        {
            _adapter = new DataAdapter(context);
            _mapper = mapper;
            _logger = logger;

        }

        private void ShiftTopMenuData()
        {
            ViewData["email"] = User.Claims.ElementAt(0).Value;
            ViewData["fullname"] = User.Claims.ElementAt(1).Value;
            ViewData["status"] = User.Claims.ElementAt(2).Value;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new IndexModel(_adapter.GetInterns());

            ShiftTopMenuData();
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(IndexModel model)
        {
            Intern intern = _mapper.Map<Intern>(model);
            try
            {
                _adapter.CreateIntern(intern);
            }
            catch (AppException)
            {
                Response.StatusCode = -1;
            }

            model = new IndexModel(_adapter.GetInterns());

            ShiftTopMenuData();
            return View(model);
        }

        [HttpPost]
        public string InternLeave(int id)
        {
            return _adapter.InternLeave(id);
        }

        public IActionResult Contact()
        {
            return View();
        }

        [AcceptVerbs("GET")]
        public IActionResult Question()
        {
            var model = _adapter.GetQuestions();
            
            ShiftTopMenuData();
            return View(model);
        }

        [AcceptVerbs("GET")]
        public IActionResult Calendar()
        {
            var even = _adapter.GetEvents();
            var eventype = _adapter.GetEventTypes();
            var model = new CalendarModel(eventype, even)
            {
                Creator = User.Claims.ElementAt(1).Value
            };

            ShiftTopMenuData();
            return View(model);
        }

        [AcceptVerbs("POST")]
        public IActionResult CreateEvent(CalendarModel model)
        {
            Event even = _mapper.Map<Event>(model);
            even.Image = "../img/frontapp.svg";           

            _adapter.CreateEvent(even);

            return RedirectToAction("/");
        }

        [AllowAnonymous]
        public IActionResult GetEvents()
        {
            return Json(_adapter.GetEvents());
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}