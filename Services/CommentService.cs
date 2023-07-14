using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Entities;
using Blog.Entities.DTOS;
using Blog.Repository.Interfaces;
using Blog.Services.Interfaces;

namespace Blog.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public CommentService(IMapper mapper, ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;

        }
        public void CreateComment(CommentDTO commentDTO)
        {
            if (commentDTO == null)
            {
                throw new ArgumentNullException(nameof(commentDTO), "Comment cannot be null");
            }

            if (string.IsNullOrWhiteSpace(commentDTO.Content))
            {
                throw new ArgumentException("Comment content is required.", nameof(commentDTO.Content));
            }

            var comment = _mapper.Map<Comment>(commentDTO);

            _commentRepository.AddComment(comment);

        }

        public void DeleteComment(Guid commentId)
        {
            _commentRepository.DeleteComment(commentId);
        }

        public IEnumerable<Comment> GetCommentByPostId(Guid postId)
        {
            return _commentRepository.GetByPostId(postId);

        }

        public void UpdateComment(CommentDTO commentDTO)
        {
            if (commentDTO == null)
            {
                throw new ArgumentNullException(nameof(commentDTO), "Comment DTO cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(commentDTO.Content))
            {
                throw new ArgumentException("Comment content is required.", nameof(commentDTO.Content));
            }


            var comment = _mapper.Map<Comment>(commentDTO);
            _commentRepository.UpdateComment(comment);
        }
    }
}