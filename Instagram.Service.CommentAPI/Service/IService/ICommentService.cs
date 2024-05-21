using Instagram.Services.CommentAPI.Models.Dto;

namespace Instagram.Service.CommentAPI.Service.IService {
    public interface ICommentService {
        Task<CommentResponseDTO> AddComment(CommentRequestDTO comment);
        List<CommentResponseDTO> GetCommentByPostId(string postId);
        List<CommentResponseDTO> GetCommentByUserId(string userId);
        bool DeleteCommentByCommentId(string commentId);
        bool DeleteCommentByUserId(string userId);
        bool DeleteCommentByPostId(string postId);
    }
}
