using Instagram.Services.UserAPI.Models;
using Instagram.Services.UserAPI.Models.Dto;
using Instagram.Services.UserAPI.Service.IService;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Instagram.Services.UserAPI.Service {
    public class JwtTokenGenerator : IJwtTokenGenerator {
        private readonly JwtOptions _jwtOptions;
        public JwtTokenGenerator(IOptions<JwtOptions> jwtOptions) {
            _jwtOptions = jwtOptions.Value;
        }
        public string GenerateToken(UserDTO applicationUser) {

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtOptions.Secret);

            var claimList = new List<Claim> {
                new(JwtRegisteredClaimNames.Sub,applicationUser.Id.ToString()),
                new(JwtRegisteredClaimNames.Email,applicationUser.Email.ToString()),
                new(JwtRegisteredClaimNames.Name,applicationUser.UserName.ToString()),
            };

            var tokenDescriptor = new SecurityTokenDescriptor {
                Audience = _jwtOptions.Audience,
                Issuer = _jwtOptions.Issuer,
                Subject = new ClaimsIdentity(claimList),
                Expires = DateTime.UtcNow.AddDays(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
