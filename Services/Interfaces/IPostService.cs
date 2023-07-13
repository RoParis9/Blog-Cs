using Blog.Entities.DTOS;
using Blog.Entities.DTOS.Post;

namespace Blog.Services.Interfaces
{
    public interface IPostService
    {
        Task<PostDTO> GetPostByIdAsync(int postId);
        Task<IEnumerable<PostDTO>> GetAllPostsAsync();
        Task<PostDTO> GetPostByTitleAsync(string title);
        Task<CreatePostDTO> CreatePostAsync(CreatePostDTO postDTO);
        Task<CreatePostDTO> UpdatePostAsync(int postId, CreatePostDTO postDTO);
        Task DeletePostAsync(int postId);
    }
}