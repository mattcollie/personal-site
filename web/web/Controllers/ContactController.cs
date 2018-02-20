using Microsoft.AspNetCore.Mvc;

namespace web.Controllers
{
    public class ContactController : Controller
    {
        [HttpPost]
        public IActionResult Index(string senderName, string subjectText, string messageText)
        {
            // save the contact request
            return Ok();
        }
    }
}