using Microsoft.EntityFrameworkCore;

namespace AspTest.Domain.Repositories
{
    public interface IRepository<T> where T : class
    {
        public T GetById(int id);
        public IQueryable<T> GetAll();
        public void Delete(T entity);
        public void Insert(T entity);
    }
}
