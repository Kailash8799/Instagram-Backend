using System.ComponentModel.DataAnnotations;

namespace Instagram.Services.PostAPI.Models.Dto {
    public class PostRequestDTO {

      /*  [Required(ErrorMessage = "UserId is required!")]*/
        public string UserId { get; set; }
        public string Content { get; set; }

       /* [Required(ErrorMessage = "MediaUrls are required!")]
        [MinLength(1, ErrorMessage = "At least one media URL is required.")]*/
        public List<string> MediaUrls { get; set; }
        public List<string> Tags { get; set; }
        public List<string> Mentions { get; set; }
    }
}
