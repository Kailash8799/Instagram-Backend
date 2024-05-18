using Instagram.Services.PostAPI.Models.Dto;

namespace Instagram.Services.PostAPI.Service.IService {
    public interface IPostService {
        List<PostResponseDTO>? GetPostByUserID(string userId);
        PostResponseDTO? GetPostByID(string postId);
        Task<string> CreatePost(PostRequestDTO post);
        PostResponseDTO? UpdatePost(PostResponseDTO postToUpdate);
        bool DeletePost(string postId);
    }
}
