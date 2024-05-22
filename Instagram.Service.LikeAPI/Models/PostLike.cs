using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Instagram.Service.LikeAPI.Models {
    public class PostLike{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "UserId is required!")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "PostId is required!")]
        public string PostId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
