using ClientsDirectory.Models;
using Microsoft.AspNetCore.Mvc;

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
            return View("AddClient");
        }

        [HttpPost]
        [Route("AddClient", Name = "AddClientPost")]
        public IActionResult AddClient(ClientInfo clientInfo)
        {
            clients.Add(clientInfo);
            return RedirectToRoute("ShowAllClientDetails");
        }
    }


}
