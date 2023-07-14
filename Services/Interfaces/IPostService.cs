using Blog.Entities.DTOS;
using Blog.Entities.DTOS.Post;

namespace Blog.Services.Interfaces
{
    public interface IPostService
    {
        Task<PostDTO> GetPostByIdAsync(Guid postId);
        Task<IEnumerable<PostDTO>> GetAllPostsAsync();
        Task<PostDTO> GetPostByTitleAsync(string title);
        Task<CreatePostDTO> CreatePostAsync(CreatePostDTO postDTO);
        Task<CreatePostDTO> UpdatePostAsync(Guid postId, CreatePostDTO postDTO);
        Task DeletePostAsync(Guid postId);
    }
}