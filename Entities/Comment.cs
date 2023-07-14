using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Entities
{
    public class Comment
    {
        public Guid CommentId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }

        public User Author { get; set; }

        public Post Post { get; set; }


    }
}
