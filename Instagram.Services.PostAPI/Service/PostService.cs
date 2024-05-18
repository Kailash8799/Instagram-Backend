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

        public PostResponseDTO? GetPostByID(string postId) {
            throw new NotImplementedException();
        }
        public List<PostResponseDTO>? GetPostByUserID(string userId) {
            throw new NotImplementedException();
        }
        public Task<string> CreatePost(PostRequestDTO post) {
            try {
                Post newpost = _mapper.Map<Post>(post);
                var validationResults = ValidationHelper.Validate(newpost);
                if (validationResults.Count > 0) {
                    var errors = string.Join(", ", validationResults.Select(vr => vr.ErrorMessage));
                    return Task.FromResult(errors);
                }
                _dbContext.Post.Add(newpost);
                _dbContext.SaveChanges();
                return Task.FromResult("");
            } catch(Exception ex) {
                return Task.FromResult(ex.Message.ToString());
            }
        }

        public PostResponseDTO? UpdatePost(PostResponseDTO postToUpdate) {
            try {
                /* var user = await _dbContext.Post.FirstOrDefaultAsync(u => u.Id == userPatchDTO.Id);
                 if (user == null) {
                     return "";
                 }
                 _mapper.Map(userPatchDTO, user);
                 user.UpdatedAt = DateTime.Now;
                 _dbContext.User.Update(user);
                 await _dbContext.SaveChangesAsync();
                 return user.ProfilePictureUrl;*/
                return null;
            } catch (Exception ex) {
                Console.WriteLine(ex);
                return null;
            }
        }

        public bool DeletePost(string postId) {
            throw new NotImplementedException();
        }



    }
}
