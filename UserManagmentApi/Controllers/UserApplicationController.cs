using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Services;

namespace UserManagmentApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Model;
    using Model.dto;

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddUser([FromBody] UserInfoDto user, [FromQuery] string password)
        {

            var result = await _userService.AddUserAsync(user, password);
            if (result)
                return Ok(true);
            return BadRequest("Failed to add user.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var user = await _userService.LoginAsync(loginRequest.Login, loginRequest.Password);
            if (user != null)
            {
                return Ok(user);
            }
            return Unauthorized("Invalid credentials.");
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }
    }

    public class LoginRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }

}

