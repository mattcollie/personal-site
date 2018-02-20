using System.Linq;

namespace Profile.Access.Common.Interfaces
{
    public interface IRepository<out T>
    {
        IQueryable<T> All();
        T GetById(long id);
        bool Delete(long id);
    }
}
