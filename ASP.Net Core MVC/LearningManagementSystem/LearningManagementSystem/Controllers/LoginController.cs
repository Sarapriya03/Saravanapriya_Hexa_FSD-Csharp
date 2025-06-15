using Microsoft.AspNetCore.Mvc;

namespace LearningManagementSystem.Controllers
{
    [Route("login")]
    public class LoginController : Controller
    {
        [HttpGet("admin")]
        public IActionResult Admin()
        {
            return View(); 
        }
    }
}
