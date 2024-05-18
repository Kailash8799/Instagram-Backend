using AutoMapper;
using Instagram.Services.PostAPI.Models;
using Instagram.Services.PostAPI.Models.Dto;

namespace Instagram.Services.PostAPI.Utils {
    public class MappingConfig : Profile {
        public MappingConfig() {
            CreateMap<Post, PostRequestDTO>();
            CreateMap<PostRequestDTO, Post>();
            CreateMap<Post, PostResponseDTO>();
            CreateMap<PostResponseDTO, Post>();
        }
    }
}
