using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Entities;

namespace Blog.Repository.Interfaces
{
    public interface ICommentRepository
    {
        void AddComment(Comment comment);
        void DeleteComment(Guid commentId);
        void UpdateComment(Comment comment);
        IEnumerable<Comment> GetByPostId(Guid postId);
    }
}