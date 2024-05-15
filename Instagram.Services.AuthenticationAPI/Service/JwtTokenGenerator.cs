using Instagram.Services.AuthenticationAPI.Models.Dto;
using Instagram.Services.AuthenticationAPI.Service.IService;

namespace Instagram.Services.AuthenticationAPI.Service {
    public class JwtTokenGenerator : IJwtTokenGenerator {
        public string GenerateToken(UserDTO applicationUser) {
            return "Token";
        }
    }
}
