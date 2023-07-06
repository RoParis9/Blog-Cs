using Blog.Entities.DTOS;
using Blog.Entities.DTOS.User;

namespace Blog.Services.Interfaces
{
    public interface IUserService
    {
        Task<ResponseUserDTO> GetUserByIdAsync(int id);
        Task<ResponseUserDTO> GetUserByNameAsync(string name);
        Task<IEnumerable<ResponseUserDTO>> GetAllUsersAsync();
        Task<UserDTO> AddUserAsync(UserDTO user);
        Task<UserDTO> UpdateUserAsync(int id, UserDTO user);
        Task<bool> DeleteUserAsync(int id);
    }
}