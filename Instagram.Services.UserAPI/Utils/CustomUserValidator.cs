using Instagram.Services.UserAPI.Models;
using Microsoft.AspNetCore.Identity;
using System.Text.RegularExpressions;

namespace Instagram.Services.UserAPI.Utils {
    public class CustomUserValidator: IUserValidator<User> {
        public Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user) {
            var errors = new List<IdentityError>();

            // Custom validation logic for UserName
            if (string.IsNullOrWhiteSpace(user.UserName) || !Regex.IsMatch(user.UserName, "^[a-zA-Z0-9]*$")) {
                errors.Add(new IdentityError {
                    Code = "InvalidUserName",
                    Description = "Username can only contain letters or digits."
                });
            }

            // Custom validation logic for Email
            if (string.IsNullOrWhiteSpace(user.Email) || !Regex.IsMatch(user.Email, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$")) {
                errors.Add(new IdentityError {
                    Code = "InvalidEmail",
                    Description = "Invalid email format."
                });
            }

            if (errors.Count > 0) {
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            }

            return Task.FromResult(IdentityResult.Success);
        }

    }
}
