using Instagram.Services.PostAPI.Models.Dto;

namespace Instagram.Services.PostAPI.Service.IService {
    public interface IPostService {
        List<PostResponseDTO> GetPostByUserID(string userId);
        PostResponseDTO GetPostByID(string postId);
        Task<string> CreatePost(PostRequestDTO post);
        Task<PostResponseDTO> UpdatePost(string Id, UpdatePostRequestDTO postToUpdate);
        bool DeletePost(string postId);
    }
}
