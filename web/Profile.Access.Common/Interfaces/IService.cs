using System.Linq;

namespace Profile.Access.Common.Interfaces
{
    public interface IService<out TDto, in T>
    {
        IQueryable<TDto> All();
        TDto GetById(long id);
        bool Delete(long id);
    }
}
