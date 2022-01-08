using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using BCryptNet = BCrypt.Net.BCrypt;
using SoftwareEngineering.Models;
using SoftwareEngineering.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SoftwareEngineering.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Index()
        {
            //using (var ctx = new EBookApplicationContext())
            //{
            //    var result = ctx.Users.Where(x => x.Email == "erdem").FirstOrDefault<User>().Email;
            //    ViewBag.gokce = result;
            //};
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
