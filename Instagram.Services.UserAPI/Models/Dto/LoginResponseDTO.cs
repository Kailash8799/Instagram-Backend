namespace Instagram.Services.UserAPI.Models.Dto {
    public class LoginResponseDTO {
        public UserDTO? User { get; set; }
        public string Token { get; set; } = "";
    }
}
