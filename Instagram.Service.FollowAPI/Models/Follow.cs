using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Instagram.Service.FollowAPI.Models {
    public class Follow {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "FollowingId is required!")]
        public required string FollowingId { get; set; }

        [Required(ErrorMessage = "FolllowerId is required!")]
        public required string FolllowerId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
