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
        public UserController(IUserService userService)
        {
            _userService = userService;
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
            //var token = jwtAuthenticationManager.Authenticate("a", "b");
            if (token == null)
                return Unauthorized();
            return Ok("Yolladım abi" + token);
        }
    }
}
