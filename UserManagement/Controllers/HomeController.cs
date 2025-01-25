using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using UserManagement.Model;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace UserManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;

        public HomeController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult Index()
        {


            return View();
        }

        public async Task<IActionResult> AddUser()
        {
          
              return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
