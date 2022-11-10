using System.Collections.Generic;
using TranslationManagement.DAL.Entities;

namespace TranslationManagement.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        List<T> GetAll();
        T Get(int id);
        bool Add(T entity);
        bool Remove(int id);
        T Update(T entity);
    }
}
