using System;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using Profile.Access.Service.Interfaces;
using Profile.Web.Models;

namespace Profile.Web.Controllers
{
    [System.Web.Http.RoutePrefix("Api")]
    public class ContactController : System.Web.Http.ApiController
    {
        private IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public HttpResponseMessage Save(ContactForm data)
        {
            bool success = _contactService.Add(new Data.Objects.Dtos.ContactDto
            {
                From = data.From,
                Subject = data.Subject,
                Message = data.Message
            });

            return Request.CreateResponse<bool>(HttpStatusCode.OK, success);
        }
    }
}