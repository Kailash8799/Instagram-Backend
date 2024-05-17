using AutoMapper;
using Instagram.Services.UserAPI.Models;
using Instagram.Services.UserAPI.Models.Dto;

namespace Instagram.Services.UserAPI.Utils {
    public class MappingConfig : Profile {
        public MappingConfig() {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
        }
    }
}
