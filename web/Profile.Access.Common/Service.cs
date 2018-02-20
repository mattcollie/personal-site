using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Profile.Access.Common.Interfaces;

namespace Profile.Access.Common
{
    public class Service<TDto, T> : IService<TDto, T> where TDto : class where T : class
    {
        private IMapper _mapper;

        public Service(IRepository<T> repository)
        {
            Repository = repository;
            MapperConfiguration mapperConfig = new MapperConfiguration(cfg => cfg.CreateMap<T, TDto>());
            _mapper = mapperConfig.CreateMapper();
        }

        protected IRepository<T> Repository { get; set; }

        public bool Delete(long id)
        {
            return Repository.Delete(id);
        }

        public IQueryable<TDto> All()
        {
            IList<T> objects = Repository.All().ToList();
            return objects.Select(o => _mapper.Map<TDto>(o)).ToList().AsQueryable();
        }

        public TDto GetById(long id)
        {
            return Mapper.Map<TDto>(Repository.GetById(id));
        }
    }
}
