using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using WebApplication.Models;

namespace WebApplication.Controllers
{
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

        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            var model = new IndexModel(_adapter.GetInterns());

            ShiftTopMenuData();
            return View(model);
        }

        [Authorize]
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
            // shift data to view
            model = new IndexModel(_adapter.GetInterns());

            ShiftTopMenuData();
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public string InternLeave(int id)
        {
            return _adapter.InternLeave(id);
        }

        public IActionResult Contact()
        {
            return View();
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult Question()
        {
            var model = _adapter.GetQuestions();
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}