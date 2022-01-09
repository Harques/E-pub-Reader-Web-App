using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftwareEngineering.IService;
using SoftwareEngineering.Models.DTOs;

namespace SoftwareEngineering.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService = null;
        private readonly IJWTAuthenticationManager jwtAuthenticationManager;
        //public UserController(IUserService userService)
        //{
        //    _userService = userService;
        //}
        public UserController(IJWTAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;  
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register([FromForm] RegisterUserDTO registerUserDTO)
        {
            string a = registerUserDTO.Email;
            return Ok("Renk");
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public IActionResult Login()
        {
            var token = jwtAuthenticationManager.Authenticate("a", "b");
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
    }
}
