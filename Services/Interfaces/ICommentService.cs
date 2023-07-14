using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Entities;
using Blog.Entities.DTOS;

namespace Blog.Services.Interfaces
{
    public interface ICommentService
    {
        IEnumerable<Comment> GetCommentByPostId(Guid posId);
        void CreateComment(CommentDTO comment);
        void UpdateComment(CommentDTO comment);
        void DeleteComment(Guid commentId);
    }
}