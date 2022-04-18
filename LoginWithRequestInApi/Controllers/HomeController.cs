using LoginWithRequestInApi.Client;
using LoginWithRequestInApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LoginWithRequestInApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private CustomHttpClient _client;

        public HomeController(ILogger<HomeController> logger, CustomHttpClient client)
        {
            _logger = logger;
            _client = client;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpPost("Logar")]
        [Route("Home/Logar")]
        public bool Logar(UserLogin data)
        {
            _client.Request(data);

            return true;
        }

    }
}