using ContactsDirectory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ContactsDirectory.Controllers
{
    [Route("contacts")]
    public class ContactController : Controller
    {
        
        public static List<ContactInfo> contacts = new List<ContactInfo>
        {
        new ContactInfo { ContactId = 1, FirstName = "Saravanapriya", LastName = "T", CompanyName = "ABC Technologies", EmailId = "priya@abc.com", MobileNo = 9876543210, Designation = "Manager" },
        new ContactInfo { ContactId = 2, FirstName = "Thrisha", LastName = "S", CompanyName = "XYZ Solutions", EmailId = "thrisha@xyz.com", MobileNo = 9123456780, Designation = "Team Lead" }
        };
[Route("/")]
        [Route("ShowContacts", Name = "ShowContacts")]
        public IActionResult ShowContacts()
        {
            return View("ShowContacts", contacts);
        }

        
        [Route("AddContact", Name = "AddContact")]
        public IActionResult AddContact()
        {
            LoadDesignations();
            return View();
        }

        
        [HttpPost]
        [Route("SaveContact", Name = "SaveContact")]
        public IActionResult AddContact(ContactInfo contactInfo)
        {
            contactInfo.ContactId = contacts.Count > 0 ? contacts.Max(c => c.ContactId) + 1 : 1;
            contacts.Add(contactInfo);
            return RedirectToRoute("ShowContacts");
        }

        
        [Route("GetContactById/{id}", Name = "GetContactById")]
        public IActionResult GetContactById(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);
            if (contact == null)
                return NotFound();
            return View("GetContactById", contact);
        }

        public void LoadDesignations()
        {
            var designations = new List<SelectListItem>
            {
                new SelectListItem { Text = "Manager", Value = "Manager" },
                new SelectListItem { Text = "Developer", Value = "Developer" },
                new SelectListItem { Text = "HR", Value = "HR" },
                new SelectListItem { Text = "Analyst", Value = "Analyst" },
                new SelectListItem { Text = "Team Lead", Value = "Team Lead" }
            };

            ViewBag.Designations = designations;
        }

    }
}
