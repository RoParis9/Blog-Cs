using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Entities;
using Blog.Entities.DTOS;
using Blog.Entities.DTOS.User;

namespace Blog.Mapping
{
    public class MappingProfile: Profile
    {
        
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<Post, PostDTO>();
            CreateMap<Comment, CommentDTO>();
            CreateMap<User, ResponseUserDTO>();
        }

    }
}