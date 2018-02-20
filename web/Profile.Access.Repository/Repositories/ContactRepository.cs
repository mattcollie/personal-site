using Profile.Access.Common;
using Profile.Access.Repository.Interfaces;
using Profile.Data.Access.Context;
using Profile.Data.Objects.Objects;

namespace Profile.Access.Repository.Repositories
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        public ContactRepository(ProfileContext context) : base(context)
        {
        }
    }
}
