using Instagram.Service.LikeAPI.Models.Dto;

namespace Instagram.Service.LikeAPI.Service.IService {
    public interface ICommentLikeService {
        bool LikeComment(CommentLikeRequestDTO commentLikeRequestDTO);
        bool DisLikeComment(CommentLikeRequestDTO commentLikeRequestDTO);
    }
}
