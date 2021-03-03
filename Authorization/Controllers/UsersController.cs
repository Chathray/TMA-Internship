using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Route("/[action]")]
    public class UsersController : Controller
    {
        private readonly DataAdapter _adapter;
        private readonly IMapper _mapper;
        public UsersController(DataContext context, IMapper mapper)
        {
            _adapter = new DataAdapter(context);
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated) 
                return Redirect("/");

            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _adapter.Authenticate(model.Email, model.Password);

                if (user == null)
                    return View();

                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim("FullName", user.First_Name +" " + user.Last_Name),
                    };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTime.UtcNow.AddMinutes(10)
                    });

                return Redirect("/");
            }
            return View();
        }

        public IActionResult Register(RegisterModel model)
        {
            User user = _mapper.Map<User>(model);
            try
            {
                // create user
                _adapter.Create(user, model.Password);
                return Redirect("/Login");
            }
            catch (AppException)
            {
                return View();
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }
    }
}