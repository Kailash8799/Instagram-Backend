﻿using Instagram.Services.UserAPI.Data;
using Instagram.Services.UserAPI.Models;
using Instagram.Services.UserAPI.Models.Dto;
using Instagram.Services.UserAPI.Service.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Instagram.Services.UserAPI.Service {
    public class AuthService : IAuthService {

        private readonly AppDbContext _db;
        private readonly UserManager<User> _userManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthService(AppDbContext db, UserManager<User> userManager, IJwtTokenGenerator jwtTokenGenerator) { 
            _db = db;
            _userManager= userManager;
            _jwtTokenGenerator = jwtTokenGenerator;
        }
        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDto) {
            try {
                var user = _db.User.FirstOrDefault(u=> u.UserName.ToLower() == loginRequestDto.UserName.ToLower() || u.Email == loginRequestDto.UserName);
                if(user == null) {
                    return new LoginResponseDTO() { User = null, Token = "" };
                }
                bool isValid = await _userManager.CheckPasswordAsync(user,loginRequestDto.Password);
                if(!isValid) {
                    return new LoginResponseDTO() { User = null, Token = "" };
                }
                var userDTO = new UserDTO() {
                    Id = user.Id,
                    UserName = loginRequestDto.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Gender = user.Gender,
                    Bio = user.Bio,
                    DateOfBirth = user.DateOfBirth,
                    IsPrivate = user.IsPrivate,
                    ProfilePictureUrl = user.ProfilePictureUrl,
                    Website = user.Website,
                };
                var token = _jwtTokenGenerator.GenerateToken(userDTO);
                return new LoginResponseDTO() { User = userDTO, Token = token };

            } catch(Exception) {
                return new LoginResponseDTO() { User = null, Token = "" };
            }
        }

        public async Task<RegistrationResponseDTO> Register(RegistrationRequestDTO registrationRequestDto) {
            try {
                var user = _db.User.FirstOrDefault(u => u.Email == registrationRequestDto.Email);
                if (user != null) {
                    return new RegistrationResponseDTO() { success = false, message = "User already exits with this email" };
                }

                User newuser = new() {
                    Email = registrationRequestDto.Email,
                    FirstName = registrationRequestDto.FirstName,
                    LastName = registrationRequestDto.LastName,
                    UserName = registrationRequestDto.UserName,
                };

                var response = await _userManager.CreateAsync(newuser,registrationRequestDto.Password);
                if (response != null && response.Succeeded) {
                    return new RegistrationResponseDTO() { success = true, message = "User created successfully"};
                }
                return new RegistrationResponseDTO() { success = false, message = response.Errors.FirstOrDefault().Description };
            } catch (Exception) {
                return new RegistrationResponseDTO() { success = false, message = "Internal server error" };
            }
        }
    }
}
