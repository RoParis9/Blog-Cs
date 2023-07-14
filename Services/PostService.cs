using AutoMapper;
using Blog.Entities;
using Blog.Entities.DTOS;
using Blog.Entities.DTOS.Post;
using Blog.Repository.Interfaces;
using Blog.Services.Interfaces;

namespace Blog.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostService(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<CreatePostDTO> CreatePostAsync(CreatePostDTO postDto)
        {
            if (string.IsNullOrWhiteSpace(postDto.Title))
            {
                throw new ArgumentException("Title is required");
            }

            if (string.IsNullOrWhiteSpace(postDto.Content))
            {
                throw new ArgumentException("Title is required");
            }

            var post = _mapper.Map<Post>(postDto);
            var createdPost = await _postRepository.AddPostAsync(post);
            return _mapper.Map<CreatePostDTO>(createdPost);
        }

        public async Task<PostDTO> GetPostByIdAsync(Guid postId)
        {

            var post = await _postRepository.GetPostByIdAsync(postId);
            if (post == null)
            {
                throw new Exception("Post not found");
            }
            return _mapper.Map<PostDTO>(post);
        }

        public async Task<IEnumerable<PostDTO>> GetAllPostsAsync()
        {
            var posts = await _postRepository.GetAllPostsAsync();
            return _mapper.Map<IEnumerable<PostDTO>>(posts);
        }

        public async Task<IEnumerable<PostDTO>> GetPostsByUserIdAsync(Guid userId)
        {
           

            var posts = await _postRepository.GetPostByIdAsync(userId);
            if (posts == null)
            {
                throw new Exception("Posts not found");
            }
            return _mapper.Map<IEnumerable<PostDTO>>(posts);
        }


        public async Task<PostDTO> GetPostByTitleAsync(string title)
        {
            var post = await _postRepository.GetPostByTitleAsync(title);
            return _mapper.Map<PostDTO>(post);
        }

        public async Task<CreatePostDTO> UpdatePostAsync(Guid postId, CreatePostDTO postDto)
        {
            var existingPost = await _postRepository.GetPostByIdAsync(postId);
            if (existingPost == null)
            {
                throw new Exception("Post not found");
            }

            _mapper.Map(postDto, existingPost);
            var updatedPost = await _postRepository.UpdatePostAsync(existingPost);
            return _mapper.Map<CreatePostDTO>(updatedPost);
        }

        public async Task DeletePostAsync(Guid postId)
        {
            var existingPost = await _postRepository.GetPostByIdAsync(postId);
            if (existingPost == null)
            {
                throw new Exception("Post not found");
            }

            await _postRepository.DeletePostAsync(existingPost);
        }
    }
}