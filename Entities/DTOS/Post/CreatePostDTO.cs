
using System.ComponentModel.DataAnnotations;

namespace Blog.Entities.DTOS.Post
{
    public class CreatePostDTO
    {
    [Required(ErrorMessage = "The 'Title' field is required.")]
    [MaxLength(100, ErrorMessage = "The 'Title' field must not exceed 100 characters.")]
    public string Title { get; set; }
    
    [Required(ErrorMessage = "The 'Content' field is required.")]
    public string Content { get; set; }

    }
}