using AutoMapper;
using Instagram.Service.LikeAPI.Models;
using Instagram.Service.LikeAPI.Models.Dto;
using Instagram.Service.LikeAPI.Service.IService;
using Instagram.Services.LikeAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace Instagram.Service.LikeAPI.Service {
    public class PostLikeService : IPostLikeService {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public PostLikeService(AppDbContext appDbContext, IMapper mapper) {
            _dbContext = appDbContext;
            _mapper = mapper;
        }
        public List<PostLikeDTO> GetAllLikes(string postId) {
            List<PostLike> likes = [.. _dbContext.PostLike.AsNoTracking().Where(p => p.PostId == postId)];
            List<PostLikeDTO> postlikesDTO = _mapper.Map<List<PostLikeDTO>>(likes);
            return postlikesDTO;
        }

        public bool LikePost(PostLikeRequestDTO postLikeRequestDTO) {
            PostLike? like = _dbContext.PostLike.AsNoTracking().FirstOrDefault(ll => ll.UserId == postLikeRequestDTO.UserId && ll.PostId == postLikeRequestDTO.PostId);
            if (like != null) {
                throw new Exception("Already liked");
            }
            PostLike newlike = _mapper.Map<PostLike>(postLikeRequestDTO);
            _dbContext.PostLike.Add(newlike);
            _dbContext.SaveChanges();
            return true;
        }

        public bool DisLikePost(PostLikeRequestDTO postLikeRequestDTO) {
            PostLike like = _dbContext.PostLike.AsNoTracking().FirstOrDefault(ll => ll.UserId == postLikeRequestDTO.UserId && ll.PostId == postLikeRequestDTO.PostId) ?? throw new Exception("Not liked");
            _dbContext.PostLike.Remove(like);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
