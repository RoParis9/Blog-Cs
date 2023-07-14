using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Data;
using Blog.Entities;
using Blog.Repository.Interfaces;

namespace Blog.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DataContext _dbContext;
        public CommentRepository(DataContext dbContext)
        {
            _dbContext = dbContext;

        }
        public void AddComment(Comment comment)
        {
            _dbContext.Comments.Add(comment);
            _dbContext.SaveChanges();
        }

        public void DeleteComment(Guid commentId)
        {
            var comment = _dbContext.Comments.Find(commentId);
            _dbContext.Comments.Remove(comment);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Comment> GetByPostId(Guid postId)
        {
            return _dbContext.Comments.Where(c => c.Post.PostId == postId).ToList();
        }

        public void UpdateComment(Comment comment)
        {
            _dbContext.Comments.Update(comment);
            _dbContext.SaveChanges();
        }
    }
}