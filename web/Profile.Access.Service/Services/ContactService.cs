using Profile.Access.Common;
using Profile.Access.Repository.Interfaces;
using Profile.Access.Service.Interfaces;
using Profile.Data.Objects.Dtos;
using Profile.Data.Objects.Objects;

namespace Profile.Access.Service.Services
{
    public class ContactService : Service<ContactDto, Contact> , IContactService
    {
        public ContactService(IContactRepository repository) : base(repository)
        {
        }
    }
}
