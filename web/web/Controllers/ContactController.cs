using Microsoft.AspNetCore.Mvc;
using Profile.Access.Service.Interfaces;

namespace web.Controllers
{
    public class ContactController : Controller
    {
        private IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost]
        public IActionResult Index(string senderName, string subjectText, string messageText)
        {
            // save the contact request
            return Ok();
        }
    }
}