using Instagram.Services.UserAPI.Models.Dto;
using Instagram.Services.UserAPI.Service.IService;

namespace Instagram.Services.UserAPI.Service {
    public class UserService : IUserService {
        public Task<LoginResponseDTO> GetProfile(LoginRequestDTO loginRequestDto) {
            throw new NotImplementedException();
        }

        public Task<LoginResponseDTO> RemoveProfilePicture(LoginRequestDTO loginRequestDto) {
            throw new NotImplementedException();
        }

        public Task<RegistrationResponseDTO> UpdateProfile(RegistrationRequestDTO registrationRequestDto) {
            throw new NotImplementedException();
        }

        public Task<LoginResponseDTO> UpdateProfilePicture(LoginRequestDTO loginRequestDto) {
            throw new NotImplementedException();
        }
    }
}
