﻿
namespace Instagram.Service.LikeAPI.Models.Dto {
    public class CommentLikeRequestDTO {
        public string UserId { get; set; }
        public string PostId { get; set; }
        public string CommentId { get; set; }
    }
}
