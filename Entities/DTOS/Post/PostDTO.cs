using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Entities.DTOS
{
    public class PostDTO
    {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public int UserId { get; set; }
    public int CategoryId { get; set; }
    public ICollection<CommentDTO> Comments { get; set; }
    }
}