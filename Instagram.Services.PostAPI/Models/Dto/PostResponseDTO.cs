namespace Instagram.Services.PostAPI.Models.Dto {
    public class PostResponseDTO {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }
        public List<string> MediaUrls { get; set; }
        public int LikesCount { get; set; }
        public int CommentsCount { get; set; }
        public List<string> Tags { get; set; }
        public bool IsArchived { get; set; }
        public List<string> Mentions { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
