using Blog.Data;
using Blog.Entities;
using Blog.Entities.DTOS;
using Blog.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dbContext;

        public UserRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> AddUserAsync(User user)
        {
            await _dbContext.Set<User>().AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;

        }

        public async Task<bool> DeleteUserAsync(User user)
        {
            _dbContext.Set<User>().Remove(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _dbContext.Set<User>().ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id is null");
            }
            return await _dbContext.Set<User>().FirstOrDefaultAsync();
        }

        public async Task<User> GetByNameAsync(string name)
        {
            return await _dbContext.Set<User>().FirstOrDefaultAsync(u => u.Name == name);
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            _dbContext.Set<User>().Update(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _dbContext.Set<User>().FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}