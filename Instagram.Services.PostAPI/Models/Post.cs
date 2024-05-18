using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Instagram.Services.PostAPI.Models {
    public class Post{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="UserId is required!")]
        public string UserId { get; set; }
        public string Content { get; set; } = "";

        [Required(ErrorMessage = "MediaUrls are required!")]
        [MinLength(1, ErrorMessage = "At least one media URL is required.")]
        public List<string> MediaUrls { get; set; } = [];
        public int LikesCount { get; set; } = 0;
        public int CommentsCount { get; set; } = 0;
        public List<string> Tags { get; set; } = [];
        public string Location { get; set; } = "From earth";
        public bool IsArchived { get; set; } = false;
        public List<string> Mentions { get; set; } = [];
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
