using Profile.Access.Common;
using Profile.Access.Repository.Interfaces;
using Profile.Access.Service.Interfaces;
using Profile.Data.Objects.Dtos;
using Profile.Data.Objects.Objects;
using AutoMapper;

namespace Profile.Access.Service.Services
{
    public class ContactService : Service<ContactDto, Contact> , IContactService
    {
        public IContactRepository ContactRepository;

        public ContactService(IContactRepository repository) : base(repository)
        {
            ContactRepository = repository;
        }

        public bool Add(ContactDto contact)
        {
            return ContactRepository.Add(Mapper.Map<Contact>(contact));
        }
    }
}
