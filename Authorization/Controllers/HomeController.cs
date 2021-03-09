using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
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

        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            var model = new InternModel(_adapter.GetInterns());
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Index(InternModel model)
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
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Question()
        {
            var model = new QuestionModel(_adapter.GetQuestions());
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}