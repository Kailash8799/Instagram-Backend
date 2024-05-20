using AutoMapper;
using Instagram.Services.PostAPI.Data;
using Instagram.Services.PostAPI.Models;
using Instagram.Services.PostAPI.Models.Dto;
using Instagram.Services.PostAPI.Service.IService;
using Instagram.Services.PostAPI.Utils;
using Microsoft.EntityFrameworkCore;

namespace Instagram.Services.PostAPI.Service {
    public class PostService : IPostService {

        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        public PostService(AppDbContext appDbContext,IMapper mapper) {
            _dbContext = appDbContext;
            _mapper = mapper;
        }

        public PostResponseDTO GetPostByID(string postId) {
            Post post = _dbContext.Post.AsNoTracking().FirstOrDefault(p => p.Id == new Guid(postId)) ?? throw new Exception("Not Found Post with this ID");
            PostResponseDTO postResponseDTO = _mapper.Map<PostResponseDTO>(post);
            return postResponseDTO;
        }
        public List<PostResponseDTO> GetPostByUserID(string userId) {
            List<Post> userPosts = [.. _dbContext.Post.AsNoTracking().Where(p=>p.UserId == userId)];
            List<PostResponseDTO> userPostsDto = _mapper.Map<List<PostResponseDTO>>(userPosts);
            return userPostsDto;
        }
        public Task<string> CreatePost(PostRequestDTO post) {
                Post newpost = _mapper.Map<Post>(post);
                var validationResults = ValidationHelper.Validate(newpost);
                if (validationResults.Count > 0) {
                    var errors = string.Join(", ", validationResults.Select(vr => vr.ErrorMessage));
                    return Task.FromResult(errors);
                }
                _dbContext.Post.Add(newpost);
                _dbContext.SaveChanges();
                return Task.FromResult("");
        }

        public async Task<PostResponseDTO> UpdatePost(string Id, UpdatePostRequestDTO postToUpdate) {
                 var post = await _dbContext.Post.AsNoTracking().FirstOrDefaultAsync(u => u.Id == new Guid(Id)) ?? throw new Exception("Post not found");
                 post = _mapper.Map(postToUpdate, post);
                 post.UpdatedAt = DateTime.Now;
                 _dbContext.Post.Update(post);
                 await _dbContext.SaveChangesAsync();
                 PostResponseDTO postResponseDTO = _mapper.Map<PostResponseDTO>(post);
                 return postResponseDTO;
        }

        public bool DeletePost(string postId) {
            Post post = _dbContext.Post.AsNoTracking().FirstOrDefault(p => p.Id == new Guid(postId)) ?? throw new Exception("Post not found with this ID");
            _dbContext.Remove(post);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
