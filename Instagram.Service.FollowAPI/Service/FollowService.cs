using AutoMapper;
using Instagram.Service.FollowAPI.Models;
using Instagram.Service.FollowAPI.Models.Dto;
using Instagram.Service.FollowAPI.Service.IService;
using Instagram.Services.FollowAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace Instagram.Service.FollowAPI.Service {
    public class FollowService : IFollowService {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public FollowService(AppDbContext appDbContext, IMapper mapper) {
            _dbContext = appDbContext;
            _mapper = mapper;
        }
        public List<FollowResponseDTO> GetFollowersByUserId(string userId) {
            List<Follow> followers = [.. _dbContext.Follow.AsNoTracking().Where(fl => fl.FolllowerId == userId)];
            List<FollowResponseDTO> followResponseDTOs = _mapper.Map<List<FollowResponseDTO>>(followers);
            return followResponseDTOs;
        }
        public List<FollowResponseDTO> GetFollowingByUserId(string userId) {
            List<Follow> followers = [.. _dbContext.Follow.AsNoTracking().Where(fl => fl.FollowingId == userId)];
            List<FollowResponseDTO> followResponseDTOs = _mapper.Map<List<FollowResponseDTO>>(followers);
            return followResponseDTOs;
        }
        public void FollowUser(FollowRequestDTO followRequestDTO) {
            Follow? followUser = _dbContext.Follow.AsNoTracking().FirstOrDefault(u => u.FolllowerId == followRequestDTO.FolllowerId && u.FollowingId == followRequestDTO.FollowingId);
            if (followUser != null) {
                throw new Exception("Already Followed");
            }
            Follow newFollower = _mapper.Map<Follow>(followRequestDTO);
            _dbContext.Follow.Add(newFollower);
            _dbContext.SaveChanges();
        }

        public void UnFollowUser(FollowRequestDTO followRequestDTO) {
            Follow followUser = _dbContext.Follow.AsNoTracking().FirstOrDefault(u => u.FolllowerId == followRequestDTO.FolllowerId && u.FollowingId == followRequestDTO.FollowingId) ?? throw new Exception("Not Followed");
            _dbContext.Follow.Remove(followUser);
            _dbContext.SaveChanges();
        }
    }
}
