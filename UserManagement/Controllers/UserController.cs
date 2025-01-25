using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [ApiController]
        [Route("api/[controller]")]
        public class UserApiTriggerController : ControllerBase
        {
            private readonly HttpClient _httpClient;

            public UserApiTriggerController(HttpClient httpClient)
            {
                _httpClient = httpClient;
            }

            [HttpPost("add-user")]
            public async Task<IActionResult> AddUser([FromBody] object userPayload, [FromQuery] string password)
            {
                string apiUrl = "https://localhost:5165/api/User/add"; // Update with actual UserController API URL

                var requestContent = new StringContent(JsonSerializer.Serialize(userPayload), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"{apiUrl}?password={password}", requestContent);

                if (response.IsSuccessStatusCode)
                {
                    
                    return Ok(await response.Content.ReadAsStringAsync());
                }

                return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
            }

            [HttpPost("login")]
            public async Task<IActionResult> Login([FromBody] object loginPayload)
            {
                string apiUrl = "https://localhost:5001/api/User/login"; // Update with actual UserController API URL

                var requestContent = new StringContent(JsonSerializer.Serialize(loginPayload), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(apiUrl, requestContent);

                if (response.IsSuccessStatusCode)
                {
                    return Ok(await response.Content.ReadAsStringAsync());
                }

                return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
            }

            [HttpGet("get-users")]
            public async Task<IActionResult> GetAllUsers()
            {
                string apiUrl = "https://localhost:5001/api/User/users"; // Update with actual UserController API URL

                var response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    return Ok(await response.Content.ReadAsStringAsync());
 
                }

                return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
            }
        }
    }
}

