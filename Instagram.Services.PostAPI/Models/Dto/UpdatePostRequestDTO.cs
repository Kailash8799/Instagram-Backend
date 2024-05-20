namespace Instagram.Services.PostAPI.Models.Dto {
    public class UpdatePostRequestDTO {
        public string Content { get; set; }
        public List<string> Tags { get; set; }
        public bool IsArchived { get; set; }
        public List<string> Mentions { get; set; }
    }
}
