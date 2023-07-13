using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Entities
{
    public class Post
    {
        public Guid PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        public User Author { get; set; }

        public ICollection<Comment> Comments { get; set; }


    }
}
