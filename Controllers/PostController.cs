using Blog.Entities.DTOS;
using Blog.Entities.DTOS.Post;
using Blog.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;

        }
        
        [HttpGet("{postId}")]
        public async Task<IActionResult> GetPostById([FromBody] Guid postId)
        {
            try
            {
                var post = await _postService.GetPostByIdAsync(postId);
                if (post == null)
                {
                    return NotFound();
                }

                return Ok(post);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving the post: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            try
            {
                var posts = await _postService.GetAllPostsAsync();
                return Ok(posts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving the posts: {ex.Message}");
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostDTO postDto)
        {
            try
            {
                var createdPost = await _postService.CreatePostAsync(postDto);
                return Ok(createdPost);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while creating the post: {ex.Message}");
            }
        }

        [HttpPut("update/{postId}")]
        public async Task<IActionResult> UpdatePost([FromHeader] Guid postId, [FromBody] CreatePostDTO postDto)
        {
            try
            {
                var updatedPost = await _postService.UpdatePostAsync(postId, postDto);
                if (updatedPost == null)
                {
                    return NotFound();
                }

                return Ok(updatedPost);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the post: {ex.Message}");
            }
        }

        [HttpDelete("delete/{postId}")]
        public async Task<IActionResult> DeletePost(Guid postId)
        {
            try
            {
                await _postService.DeletePostAsync(postId);
                return Ok("Post deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting the post: {ex.Message}");
            }
        }
    }
}