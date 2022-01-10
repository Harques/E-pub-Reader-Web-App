using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftwareEngineering.IService;
using SoftwareEngineering.Models.DTOs;
using System.IO;
using System.Threading.Tasks;
using VersOne.Epub;

namespace SoftwareEngineering.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService = null;
        Epub epub = null;
        public UserController(IUserService userService)
        {
            _userService = userService;
            epub = new Epub();
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register([FromForm] RegisterUserDTO registerUserDTO)
        {
            var token = _userService.Register(registerUserDTO);
            if (token == null)
                return RedirectToAction("Register", "Home", new { isRegistered = false });
            Response.Cookies.Append("X-Access-Token", token, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Strict });
            return RedirectToAction("Browse", "Home");
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromForm] LoginUserDTO loginUserDTO)
        {
            var token = _userService.Login(loginUserDTO);
            if (token == null)
                return RedirectToAction("Index", "Home", new { isLogged = false });
            Response.Cookies.Append("X-Access-Token", token, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Strict });
            return RedirectToAction("Browse", "Home");
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("LogOut")]
        public IActionResult LogOut()
        {
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }
            return RedirectToAction("Index", "Home");
        }

    }
}
