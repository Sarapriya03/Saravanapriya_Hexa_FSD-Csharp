using ClientsDirectory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClientsDirectory.Controllers
{
    [Route("Client")]
    public class ClientController : Controller
    {
        public static List<ClientInfo> clients = new List<ClientInfo>
    {
        new ClientInfo{ ClientId = 1, CompanyName = "ABC Corp", WebUrl = "http://abc.com", Email = "contact@abc.com", Category = "Software Services", Standard = "CMMI3" },
        new ClientInfo{ ClientId = 2, CompanyName = "XYZ Solutions", WebUrl = "http://xyz.com", Email = "info@xyz.com", Category = "Network_Management", Standard = "ISO" }
    };

        [Route("All")]
        [Route("/", Name = "ShowAllClientDetails")]
        public IActionResult ShowAllClientDetails()
        {
            return View("ShowAllClientDetails", clients);
        }

        [Route("GetDetailsByClientId/{id}", Name = "GetDetailsByClientId")]
        public IActionResult GetDetailsByClientId(int id)
        {
            var client = clients.FirstOrDefault(c => c.ClientId == id);
            return View("GetDetailsByClientId", client);
        }

        [Route("GetDetailsByCompanyName/{name}", Name = "GetDetailsByCompanyName")]
        public IActionResult GetDetailsByCompanyName(string name)
        {
            var client = clients.FirstOrDefault(c => c.CompanyName == name);
            return View("GetDetailsByCompanyName", client);
        }

        [Route("GetDetailsByEmail/{email}", Name = "GetDetailsByEmail")]
        public IActionResult GetDetailsByEmail(string email)
        {
            var client = clients.FirstOrDefault(c => c.Email == email);
            return View("GetDetailsByEmail", client);
        }

        [Route("GetDetailsByCategory/{category}", Name = "GetDetailsByCategory")]
        public IActionResult GetDetailsByCategory(string category)
        {
            var client = clients.FirstOrDefault(c => c.Category == category);
            return View("GetDetailsByCategory", client);
        }

        [Route("GetDetailsByStandard/{standard}", Name = "GetDetailsByStandard")]
        public IActionResult GetDetailsByStandard(string standard)
        {
            var client = clients.FirstOrDefault(c => c.Standard == standard);
            return View("GetDetailsByStandard", client);
        }

        [Route("AddClient", Name = "AddClient")]
        public IActionResult AddClient()
        {
            LoadCategories();
            LoadStandards();
            return View("AddClient");
        }

        [HttpPost]
        [Route("SaveClient", Name = "SaveClient")]
        public IActionResult AddClient(ClientInfo clientInfo)
        {
            clients.Add(clientInfo);
            return RedirectToRoute("ShowAllClientDetails");
        }

        public void LoadCategories()
        {
            var categories = new List<SelectListItem>
            {
                new SelectListItem { Text = "Low_Level_Managed_IT_Services", Value = "Low_Level_Managed_IT_Services" },
                new SelectListItem { Text = "Mid_Level_Managed_IT_Services", Value = "Mid_Level_Managed_IT_Services" },
                new SelectListItem { Text = "High_Level_Managed_IT_Services", Value = "High_Level_Managed_IT_Services" },
                new SelectListItem { Text = "On-Demand_IT_Services", Value = "On-Demand_IT_Services" },
                new SelectListItem { Text = "Hardware_Support", Value = "Hardware_Support" },
                new SelectListItem { Text = "Software Services", Value = "Software Services"},
                new SelectListItem { Text = "Network_Management ", Value = "Network_Management"}
            };

            ViewBag.Categories = categories;
        }

        public void LoadStandards()
        {
            var standards = new List<SelectListItem>
            {
                new SelectListItem { Text = "CMMI1", Value = "CMMI1" },
                new SelectListItem { Text = "CMMI2", Value = "CMMI2" },
                new SelectListItem { Text = "CMMI3", Value = "CMMI3" },
                new SelectListItem { Text = "CMMI4", Value = "CMMI4" },
                new SelectListItem { Text = "CMMI5", Value = "CMMI5" },
                new SelectListItem { Text = "ISO", Value = "ISO" },
                new SelectListItem { Text = "None", Value = "None" }
            };

            ViewBag.Standards = standards;
        }
    }


}
