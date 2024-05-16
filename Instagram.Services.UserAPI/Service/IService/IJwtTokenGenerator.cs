using Instagram.Services.UserAPI.Models.Dto;

namespace Instagram.Services.UserAPI.Service.IService {
    public interface IJwtTokenGenerator {
        string GenerateToken(UserDTO applicationUser);
    }
}
