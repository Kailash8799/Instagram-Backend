using Instagram.Services.AuthenticationAPI.Models.Dto;

namespace Instagram.Services.AuthenticationAPI.Service.IService {
    public interface IAuthService {
        Task<RegistrationResponseDTO> Register(RegistrationRequestDTO registrationRequestDto);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDto);
    }
}
