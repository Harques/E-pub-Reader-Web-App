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
using VersOne.Epub;
using Microsoft.AspNetCore.Authorization;

namespace SoftwareEngineering.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Epub _epub = null;
        private EBookApplicationContext _context;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _epub = new Epub();
            _context = new EBookApplicationContext();
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        } 

        [Authorize]
        public async Task<IActionResult> Browse()
        {
            EpubBook[] epubArray = await _epub.ReadAllFiles();
            string[] epubImgString = new string[epubArray.Length];
            for(int i = 0; i< epubArray.Length; i++)
            {
                epubImgString[i] = "data:image/jpg;base64," + Convert.ToBase64String(epubArray[i].CoverImage);
            }
            return View(epubImgString);
        }
        [Authorize]
        public IActionResult Book(int name)
        {
            var books = _context.Books.OrderBy(b => b.Name).ToList();
            ViewBag.url = books[name].BookLink;
            return View();
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

    }
}
