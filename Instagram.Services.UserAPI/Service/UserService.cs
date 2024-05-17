using Instagram.Services.UserAPI.Data;
using Instagram.Services.UserAPI.Models.Dto;
using Instagram.Services.UserAPI.Service.IService;
using AutoMapper;
using Instagram.Services.UserAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Instagram.Services.UserAPI.Service {
    public class UserService : IUserService {
           
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        public UserService(AppDbContext dbContext, IMapper mapper) {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public UserDTO? GetProfile(string id) {
            try {
                var user = _dbContext.User.AsNoTracking().FirstOrDefault(u => u.Id == id);
                if (user == null) {
                    return null;
                }
                UserDTO updateuserDTO = _mapper.Map<UserDTO>(user);
                return updateuserDTO;
            } catch (Exception) {
                return null;
            }
        }
        public async Task<string> UpdateProfilePicture(UserDTO userPatchDTO) {
            try {
                var user = await _dbContext.User.FirstOrDefaultAsync(u => u.Id == userPatchDTO.Id);
                if (user == null) {
                    return "";
                }
                _mapper.Map(userPatchDTO, user);
                user.UpdatedAt = DateTime.Now;
                _dbContext.User.Update(user);
                await _dbContext.SaveChangesAsync();
                return user.ProfilePictureUrl;
            }catch (Exception ex) {
                Console.WriteLine(ex);
                return "";
            }
        }
    }
}
