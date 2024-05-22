using AutoMapper;
using Instagram.Service.FollowAPI.Models;
using Instagram.Service.FollowAPI.Models.Dto;

namespace Instagram.Services.FollowAPI.Utils {
    public class MappingConfig : Profile {
        public MappingConfig() {
            CreateMap<Follow, FollowResponseDTO>();
            CreateMap<FollowResponseDTO, Follow>();
            CreateMap<Follow, FollowRequestDTO>();
            CreateMap<FollowRequestDTO, Follow>();
        }
    }
}
