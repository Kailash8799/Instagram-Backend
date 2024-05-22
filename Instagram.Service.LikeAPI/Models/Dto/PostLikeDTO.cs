
namespace Instagram.Service.LikeAPI.Models.Dto {
    public class PostLikeDTO {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string PostId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
