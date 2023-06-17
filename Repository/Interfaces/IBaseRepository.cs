
namespace Blog.Repository.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
         Task<T> AddAsync(T entity);
         Task DeleteAsync(T entity);
         Task<IEnumerable<T>> GetAllAsync();
         Task<T> GetByIdAsync(int id);
         Task<T> UpdateAsync(T entity);
         
    }

   
}