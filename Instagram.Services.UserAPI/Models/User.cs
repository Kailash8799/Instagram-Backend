using Microsoft.AspNetCore.Identity;

namespace Instagram.Services.UserAPI.Models {
    public class User : IdentityUser {

        // Id comes from IdentityUser

        // UserName comes from IdentityUser
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        // both field comes from IdentityUser class 

        //[Required(ErrorMessage = "Password is required field")]
        //public string Password { get; set; }
        //public bool EmailVerified { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public string Bio { get; set; } = "";
        public string ProfilePictureUrl { get; set; } = "";

        public string PhoneNumber { get; set; } = "";
        public string Gender { get; set; } = "";

        public DateOnly DateOfBirth { get; set; }

        public string Website { get; set; } = "";
        public bool IsPrivate { get; set; } = false;
    }
}
