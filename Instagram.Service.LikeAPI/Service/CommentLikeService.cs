using AutoMapper;
using Instagram.Service.LikeAPI.Models;
using Instagram.Service.LikeAPI.Models.Dto;
using Instagram.Service.LikeAPI.Service.IService;
using Instagram.Services.LikeAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace Instagram.Service.LikeAPI.Service {
    public class CommentLikeService : ICommentLikeService {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public CommentLikeService(AppDbContext appDbContext, IMapper mapper) {
            _dbContext = appDbContext;
            _mapper = mapper;
        }

        public bool LikeComment(CommentLikeRequestDTO commentLikeRequestDTO) {
            CommentLike? like = _dbContext.CommentLike.AsNoTracking().FirstOrDefault(ll => ll.UserId == commentLikeRequestDTO.UserId && ll.PostId == commentLikeRequestDTO.PostId && ll.CommentId == commentLikeRequestDTO.CommentId);
            if(like != null) {
                throw new Exception("Already liked");
            }
            CommentLike newlike = _mapper.Map<CommentLike>(commentLikeRequestDTO);
            _dbContext.CommentLike.Add(newlike);
            _dbContext.SaveChanges();
            return true;
        }

        public bool DisLikeComment(CommentLikeRequestDTO commentLikeRequestDTO) {
            CommentLike like = _dbContext.CommentLike.AsNoTracking().FirstOrDefault(ll => ll.UserId == commentLikeRequestDTO.UserId && ll.PostId == commentLikeRequestDTO.PostId && ll.CommentId == commentLikeRequestDTO.CommentId) ?? throw new Exception("Not liked");
            _dbContext.CommentLike.Remove(like);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
