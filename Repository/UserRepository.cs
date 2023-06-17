using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Entities;
using Blog.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> GetByNameAsync(string name)
        {
            var user = await _dbSet.FirstOrDefaultAsync(u => u.Name == name);
            return user;
            
        }

    }
}