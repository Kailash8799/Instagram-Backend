using Instagram.Services.UserAPI.Models.Dto;

namespace Instagram.Services.UserAPI.Service.IService {
    public interface IUserService {
        Task<LoginResponseDTO> GetProfile(LoginRequestDTO loginRequestDto);
        Task<RegistrationResponseDTO> UpdateProfile(RegistrationRequestDTO registrationRequestDto);
        Task<LoginResponseDTO> UpdateProfilePicture(LoginRequestDTO loginRequestDto);
        Task<LoginResponseDTO> RemoveProfilePicture(LoginRequestDTO loginRequestDto);
    }
}
