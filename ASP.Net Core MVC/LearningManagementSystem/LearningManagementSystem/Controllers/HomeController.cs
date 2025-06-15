using Microsoft.AspNetCore.Mvc;

namespace LearningManagementSystem.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        // Route: / or /home or /home/index
        [HttpGet("")]
        [HttpGet("index")]
        [Route("/")] // maps root URL directly
        public IActionResult Index()
        {
            return View();
        }

        // Route: /home/about
        [HttpGet("about")]
        public IActionResult About()
        {
            return View();
        }

        // Route: /home/contact
        [HttpGet("contact")]
        public IActionResult Contact()
        {
            return View();
        }
    }
}
