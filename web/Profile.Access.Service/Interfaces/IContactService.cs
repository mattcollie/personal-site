using Profile.Access.Common.Interfaces;
using Profile.Data.Objects.Dtos;
using Profile.Data.Objects.Objects;

namespace Profile.Access.Service.Interfaces
{
    public interface IContactService : IService<ContactDto, Contact>
    {
    }
}
