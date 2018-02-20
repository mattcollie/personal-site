using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Profile.Access.Common.Interfaces;

namespace Profile.Access.Common
{
    public class Service<TDto, T> : IService<TDto, T> where TDto : class where T : class
    {
        protected IMapper Mapper;

        public Service(IRepository<T> repository)
        {
            Repository = repository;
            MapperConfiguration mapperConfig = new MapperConfiguration(cfg => {
                cfg.CreateMap<T, TDto>();
                cfg.CreateMap<TDto, T>();
            });
            Mapper = mapperConfig.CreateMapper();
            
        }

        protected IRepository<T> Repository { get; set; }

        public bool Delete(long id)
        {
            return Repository.Delete(id);
        }

        public IQueryable<TDto> All()
        {
            IList<T> objects = Repository.All().ToList();
            return objects.Select(o => Mapper.Map<TDto>(o)).ToList().AsQueryable();
        }

        public TDto GetById(long id)
        {
            return AutoMapper.Mapper.Map<TDto>(Repository.GetById(id));
        }
    }
}
