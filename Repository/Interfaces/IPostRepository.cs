using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Entities;

namespace Blog.Repository.Interfaces
{
    public interface IPostRepository
    {
        Task<Post> GetPostByIdAsync(int postId);
        Task<IEnumerable<Post>> GetAllPostsAsync();
        Task<Post> GetPostByTitleAsync(string title);
        Task<Post> AddPostAsync(Post post);
        Task<Post> UpdatePostAsync(Post post);
        Task DeletePostAsync(Post post);
    }
}