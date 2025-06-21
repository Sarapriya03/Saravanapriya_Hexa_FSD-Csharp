using DAL.DataAccess;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace UIApp.Controllers
{
    [Route("Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminInfoRepo<AdminInfo> _adminInfoRepo;
        public AdminController(IAdminInfoRepo<AdminInfo> adminInfoRepo)
        {
            this._adminInfoRepo = adminInfoRepo;
        }

        [Route("/")]
        [Route("Login", Name = "Login")]
        public IActionResult LoginPage()
        {
            return View();
        }

        [HttpPost]
        [Route("ValidateAdmin", Name = "ValidateAdmin")]
        public IActionResult LoginPage(AdminInfo adminInfo)
        {
            var isValidated = _adminInfoRepo.ValidateAdmin(adminInfo);
            if (isValidated != null)
            {
                return RedirectToRoute("ProductList");
            }
            else
            {
                ViewBag.error = "Incorrect Email Id or Password";
                return View();
            }
        }
    }
}
