using Instagram.Services.AuthenticationAPI.Models.Dto;

namespace Instagram.Services.AuthenticationAPI.Service.IService {
    public interface IJwtTokenGenerator {
        string GenerateToken(UserDTO applicationUser);
    }
}
