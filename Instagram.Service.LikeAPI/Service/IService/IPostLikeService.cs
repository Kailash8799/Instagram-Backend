using Instagram.Service.LikeAPI.Models.Dto;

namespace Instagram.Service.LikeAPI.Service.IService {
    public interface IPostLikeService {
        List<PostLikeDTO> GetAllLikes(string postId);
        bool LikePost(PostLikeRequestDTO postLikeRequestDTO);
        bool DisLikePost(PostLikeRequestDTO postLikeRequestDTO);
    }
}
