using Instagram.Services.UserAPI.Models.Dto;

namespace Instagram.Services.UserAPI.Service.IService {
    public interface IAuthService {
        Task<RegistrationResponseDTO> Register(RegistrationRequestDTO registrationRequestDto);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDto);
    }
}
