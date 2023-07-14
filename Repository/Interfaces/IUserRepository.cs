using Blog.Entities;

namespace Blog.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByNameAsync(string name);
        Task<User> GetByIdAsync(int id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<bool> DeleteUserAsync(User user);
        Task<User> AddUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task<User> GetByEmailAsync(string Email);

    }
}