using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Entities;
using Blog.Entities.DTOS;
using Blog.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;

        }
        [HttpGet]
        public IActionResult GetCommentsByPostId(Guid postId)
        {
            try
            {
                _commentService.GetCommentByPostId(postId);
                return Ok();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateComment(Guid postId, [FromBody] CommentDTO comment)
        {
            try
            {
                _commentService.CreateComment(comment);
                return Ok();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut("{commentId}")]
        public IActionResult UpdateComment(Guid postId, int commentId, [FromBody] CommentDTO comment)
        {
            try
            {
                _commentService.UpdateComment(comment);
                return Ok();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpDelete("{commentId}")]
        public IActionResult DeleteComment(Guid commentId)
        {
            try
            {
                _commentService.DeleteComment(commentId);
                return Ok();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
