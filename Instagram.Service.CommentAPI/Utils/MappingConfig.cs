using AutoMapper;
using Instagram.Services.CommentAPI.Models;
using Instagram.Services.CommentAPI.Models.Dto;

namespace Instagram.Services.CommentAPI.Utils {
    public class MappingConfig : Profile {
        public MappingConfig() {
            CreateMap<Comment, CommentRequestDTO>();
            CreateMap<CommentRequestDTO, Comment>();
            CreateMap<Comment, CommentResponseDTO>();
            CreateMap<CommentResponseDTO, Comment>();
            CreateMap<CommentResponseDTO, CommentRequestDTO>();
            CreateMap<CommentRequestDTO, CommentResponseDTO>();
        }
    }
}
