using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TranslationManagement.Api;
using TranslationManagement.DAL;
using TranslationManagement.DAL.Entities;

namespace TranslationManagement.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        public AppDbContext _appDbContext;
        public DbSet<T> _entities;


        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _entities = _appDbContext.Set<T>();
        }

        public virtual List<T> GetAll()
        {
            return _entities.ToList();
        }
        public virtual T Get(int id)
        {
            return _entities.SingleOrDefault(x => x.Id == id);
        }
        public virtual bool Add(T entity)
        {
            _entities.Add(entity);
            return _appDbContext.SaveChanges() > 0;
        }
        public virtual bool Remove(int id)
        {
            var entityForRemove = _entities.FirstOrDefault(x => x.Id == id);
            if(entityForRemove is not null)
            {
                _entities.Remove(entityForRemove);
                _appDbContext.SaveChanges();
                return true;
            }
            return false;
        }
        public virtual T Update(T entity)
        {
            var entityForUpdate = _entities.First(x => x.Id == entity.Id);
            if (entityForUpdate is not null)
            {
                _entities.Update(entityForUpdate);
                _appDbContext.SaveChanges();
                entityForUpdate = entity;
            }
            return entity;
        }
    }
}
