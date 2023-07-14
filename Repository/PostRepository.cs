using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Data;
using Blog.Entities;
using Blog.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly DataContext _dbContext;

        public PostRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Post> GetPostByIdAsync(Guid postId)
        {
            return await _dbContext.Posts.FindAsync(postId);
        }

        public async Task<IEnumerable<Post>> GetAllPostsAsync()
        {
            return await _dbContext.Set<Post>().ToListAsync();
        }

        public async Task<Post> GetPostByTitleAsync(string title)
        {
            return await _dbContext.Posts.FirstOrDefaultAsync(p => p.Title == title);
        }

        public async Task<Post> AddPostAsync(Post post)
        {
            await _dbContext.Set<Post>().AddAsync(post);
            await _dbContext.SaveChangesAsync();
            return post;
        }

        public async Task<Post> UpdatePostAsync(Post post)
        {

            _dbContext.Set<Post>().Update(post);
            await _dbContext.SaveChangesAsync();
            return post;
        }

        public async Task DeletePostAsync(Post post)
        {
            _dbContext.Set<Post>().Remove(post);
            await _dbContext.SaveChangesAsync();
        }

    }
}