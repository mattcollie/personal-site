﻿using System;
using System.Linq;
using System.Data.Entity;
using Profile.Access.Common.Interfaces;
using Profile.Data.Access.Context;

namespace Profile.Access.Common
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected ProfileContext Context { get; private set; }

        public Repository(ProfileContext context)
        {
            Context = context;
            Context.Configuration.LazyLoadingEnabled = false;
            Context.Configuration.ProxyCreationEnabled = false;
        }

        public IQueryable<T> All()
        {
            return Context.Set<T>();
        }

        public bool Delete(long id)
        {
            T item = Context.Set<T>().Find(id);

            if (item == null) throw new NullReferenceException($"No matching {typeof(T).Name} record found.");

            Context.Entry(item).State = EntityState.Deleted;

            return SaveChanges() > 0;
        }

        public T GetById(long id)
        {
            return Context.Set<T>().Find(id);
        }

        public bool Add(T item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            Context.Set<T>().Add(item);

            return SaveChanges() > 0;
        }

        private int SaveChanges()
        {
            return Context.SaveChanges();
        }
    }
}
