using AutoMapper;
using Blog.Entities;
using Blog.Entities.DTOS;
using Blog.Entities.DTOS.User;
using Blog.Repository.Interfaces;
using Blog.Services.Interfaces;

namespace Blog.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository,IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task<ResponseUserDTO> GetUserByIdAsync(int id)
        {
            if(id <=0)
            {
                throw new ArgumentException("Invalid User Id");
            }
            
            User user = await _userRepository.GetByIdAsync(id);

            if(user == null)
            {
                throw new Exception("User not found");
            }

            return _mapper.Map<ResponseUserDTO>(user);
        }
        public async Task<IEnumerable<ResponseUserDTO>> GetAllUsersAsync()
        {
            IEnumerable<User> users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ResponseUserDTO>>(users);
        }

        public async Task<UserDTO> AddUserAsync(UserDTO userCreateDTO)
        {
            if(string.IsNullOrWhiteSpace(userCreateDTO.Name))
            {
                throw new ArgumentException("Name is required");
            }

            User newUser = new User
            {
                Name = userCreateDTO.Name,
                Email = userCreateDTO.Email,
                Password = userCreateDTO.Password
            };

            User createUser = await _userRepository.AddAsync(newUser);

            return _mapper.Map<UserDTO>(createUser);
                
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            if(id <= 0)
            {
                throw new Exception("Invalid user id.");
            }

            User user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                throw new Exception("User not found");
            }
            await _userRepository.DeleteAsync(user);

            return true;
        }

        public async Task<ResponseUserDTO> GetUserByNameAsync(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name is required.");
            }
            User user = await _userRepository.GetByNameAsync(name);

            if(user == null)
            {
                throw new Exception("User not found");
            }
            return _mapper.Map<ResponseUserDTO>(user);
        }

        public async Task<UserDTO> UpdateUserAsync(int id, UserDTO userUpdate)
        {
            if(userUpdate == null)
            {
                throw new ArgumentNullException(nameof(userUpdate), "User info is null");
            }

            if(string.IsNullOrWhiteSpace(userUpdate.Name))
            {
                throw new ArgumentNullException("Name is required");
            }

            if(string.IsNullOrWhiteSpace(userUpdate.Email))
            {
                throw new ArgumentNullException("Email is required");
            }

            if(string.IsNullOrWhiteSpace(userUpdate.Password))
            {
                throw new ArgumentNullException("Password is required");
            }

            User existingUser = await _userRepository.GetByIdAsync(userUpdate.Id);

            if(existingUser == null)
            {
                throw new Exception("User not found");
            }
            existingUser.Name = userUpdate.Name;
            existingUser.Email = userUpdate.Email;
            existingUser.Password= userUpdate.Password;

            await _userRepository.UpdateAsync(existingUser);    

            return _mapper.Map<UserDTO>(existingUser);

        }
    }
}
