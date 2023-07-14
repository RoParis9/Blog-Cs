using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Entities.DTOS
{
    public class CommentDTO
    {
        [Required(ErrorMessage = "The 'Content' field is required.")]
        [MaxLength(100, ErrorMessage = "The 'Content' must not exceed 100 characters.")]
        public string Content { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
    }
}