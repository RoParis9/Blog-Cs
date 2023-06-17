using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Entities;
using Blog.Repository.Interfaces;
using Blog.Services.Interfaces;

namespace Blog.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            if(id == 0){
                throw new ArgumentException("Id cannot be empty.");
            }else{
            return await _userRepository.GetByIdAsync(id);
            }
        }

        public async Task<User> GetUserByNameAsync(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name cannot be empty.");
            }
            return await _userRepository.GetByNameAsync(name);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> AddUserAsync(User user)
        {
            if (string.IsNullOrEmpty(user.Name))
            {
                throw new ArgumentException("Name cannot be empty.");
            }

            var existingUser = await _userRepository.GetByNameAsync(user.Name);
            if (existingUser != null)
            {
                throw new InvalidOperationException("Username already exists.");
            }

            return await _userRepository.AddAsync(user);
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            if (string.IsNullOrEmpty(user.Name))
            {
                throw new ArgumentException("Name cannot be empty.");
            }

            var existingUser = await _userRepository.GetByNameAsync(user.Name);
            if (existingUser != null && existingUser.Id != user.Id)
            {
                throw new InvalidOperationException("Name already exists for another user.");
            }

            return await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null.");
            }

            await _userRepository.DeleteAsync(user);
        }

    }
}