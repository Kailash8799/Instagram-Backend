using System.ComponentModel.DataAnnotations;

namespace Instagram.Service.FollowAPI.Models.Dto {
    public class FollowResponseDTO {
        public string Id { get; set; }
        public string FollowingId { get; set; }
        public string FolllowerId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
