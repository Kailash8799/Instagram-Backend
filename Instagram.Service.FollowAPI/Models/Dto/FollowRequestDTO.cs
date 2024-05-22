using System.ComponentModel.DataAnnotations;

namespace Instagram.Service.FollowAPI.Models.Dto {
    public class FollowRequestDTO {
        public required string FollowingId { get; set; }
        public required string FolllowerId { get; set; }
    }
}
