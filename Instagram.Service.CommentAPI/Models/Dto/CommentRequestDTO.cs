
namespace Instagram.Services.CommentAPI.Models.Dto {
    public class CommentRequestDTO {
        public string UserId { get; set; }
        public string PostId { get; set; }
        public string? ParentCommentId { get; set; }
        public string Content { get; set; }
    }
}
