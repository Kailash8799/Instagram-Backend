using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Instagram.Services.CommentAPI.Models {
    public class Comment{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "UserId is required!")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "PostId is required!")]
        public string PostId { get; set; }
        public string? ParentCommentId { get; set; }
        public string Content { get; set; } = "";
        public int LikesCount { get; set; } = 0;
        public int CommentsCount { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
