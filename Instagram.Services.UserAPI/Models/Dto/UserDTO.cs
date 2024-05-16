﻿namespace Instagram.Services.UserAPI.Models.Dto {
    public class UserDTO {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Website { get; set; }
        public bool IsPrivate { get; set; } = false;
    }
}
