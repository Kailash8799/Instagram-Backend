using Instagram.Service.FollowAPI.Models.Dto;

namespace Instagram.Service.FollowAPI.Service.IService {
    public interface IFollowService {
        List<FollowResponseDTO> GetFollowersByUserId(string userId);
        List<FollowResponseDTO> GetFollowingByUserId(string userId);
        void FollowUser(FollowRequestDTO followRequestDTO);
        void UnFollowUser(FollowRequestDTO followRequestDTO);
    }
}
