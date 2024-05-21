
namespace Instagram.Services.CommentAPI.Models.Dto {
    public class CommentResponseDTO {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string PostId { get; set; }
        public string? ParentCommentId { get; set; }
        public string Content { get; set; } = "";
        public int LikesCount { get; set; } = 0;
        public int CommentsCount { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
