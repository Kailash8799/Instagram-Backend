using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Instagram.Services.AuthenticationAPI.Models {
    public class User : IdentityUser {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        //[Required]
        //[RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Username can only contain letters or digits.")]
        //public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        [Required(ErrorMessage = "Email is required field")]
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
