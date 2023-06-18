using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Entities.DTOS
{
    public class UserDTO
    {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public ICollection<PostDTO> Posts { get; set; }
    public ICollection<CommentDTO> Comments { get; set; }
    }
}