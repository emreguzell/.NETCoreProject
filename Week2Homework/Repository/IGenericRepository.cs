using System.Collections.Generic;

namespace Week2Homework.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        void Update(T entity);
        void Insert(T entity);
        void Delete(long Id);
        void DeleteAll();
        T GetById(long Id);
        IEnumerable<T> GetAll();
    }
}
