using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftwareEngineering.IService;

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
        public IActionResult Register()
        {
            return Ok("Renk");
        }
        public IActionResult Get()
        {
            return Ok("Dans");
        }
    }
}
