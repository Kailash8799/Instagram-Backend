using Instagram.Services.UserAPI.Models.Dto;
using Microsoft.AspNetCore.JsonPatch;

namespace Instagram.Services.UserAPI.Service.IService {
    public interface IUserService {
        UserDTO? GetProfile(string id);
        Task<string> UpdateProfile(UserDTO userPatchDTO);
    }
}
