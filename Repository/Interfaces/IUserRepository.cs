

using Blog.Entities;

namespace Blog.Repository.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {   
        Task<User> GetByNameAsync(string name);
    }
}