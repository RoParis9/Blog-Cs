using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Entities.DTOS
{
    public class UserDTO 
    {
        [Required(ErrorMessage = "The 'Name' field is required")]
        public string Name { get; set; }
        
        [EmailAddress(ErrorMessage = "Invalid email adress")]
        public string Email { get; set; }

        [MinLength(8, ErrorMessage = "The password must be at least 8 characters long.")]
        public string Password { get; set; }
    }
}
