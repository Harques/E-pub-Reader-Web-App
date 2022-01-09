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
            _userService.Register(registerUserDTO);
            return Ok("Renk");
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromForm] RegisterUserDTO registerUserDTO)
        {
            var token = _userService.Login(registerUserDTO);
            Response.Cookies.Append("X-Access-Token", token, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Strict });
            if (token == null)
                return Unauthorized();
            return RedirectToAction("Browse", "Home");
        }

        [Authorize]
        [HttpGet]
        [Route("Values")]
        public IActionResult Values()
        {
            return Ok("200");
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("DeleteCookies")]
        public IActionResult DeleteCookies()
        {
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }
            return Ok();
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("AzureTest")]
        public async Task<IActionResult> AzureTestAsync()
        {
            EpubBook temp = await epub.ReadFile();
            return Ok(temp.Content.Html);
        }
    }
}
