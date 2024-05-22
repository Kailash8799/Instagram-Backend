using AutoMapper;
using Instagram.Service.LikeAPI.Models.Dto;
using Instagram.Service.LikeAPI.Models;

namespace Instagram.Services.LikeAPI.Utils {
    public class MappingConfig : Profile {
        public MappingConfig() {
            CreateMap<PostLike, PostLikeRequestDTO>();
            CreateMap<PostLike, PostLikeDTO>();
            CreateMap<PostLikeRequestDTO, PostLike>();
            CreateMap<CommentLike, CommentLikeRequestDTO>();
            CreateMap<CommentLikeRequestDTO, CommentLike>();
        }
    }
}
