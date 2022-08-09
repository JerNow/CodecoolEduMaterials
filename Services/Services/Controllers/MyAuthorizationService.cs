﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.Models.DTOs.User;
using Services.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Services.Services.Controllers
{
   public class MyAuthorizationService : IMyAuthorizationService
   {
      private readonly IConfiguration _configuration;
      private readonly UserManager<IdentityUser> _userManager;
      private readonly RoleManager<IdentityRole> _roleManager;

      public MyAuthorizationService(IConfiguration configuration, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
      {
         _configuration = configuration;
         _userManager = userManager;
         _roleManager = roleManager;
      }

      public async Task<string> RegisterNewUser(UserRegistrationDto userRegistrationDto)
      {
         var newUser = new IdentityUser() { Email = userRegistrationDto.Email, UserName = userRegistrationDto.Username };
         var isCreated = await _userManager.CreateAsync(newUser, userRegistrationDto.Password);
         if (isCreated.Succeeded)
         {
            var jwtToken = await GenerateJwtToken(newUser);

            return jwtToken;
         }
         throw new Exception("Can't create user");
      }

      public async Task<string> LoginUser(UserLoginRequest userLoginRequest, IdentityUser user)
      {
         var isCorrect = await _userManager.CheckPasswordAsync(user, userLoginRequest.Password);

         if (!isCorrect)
         {
            return string.Empty;
         }

         var jwtToken = await GenerateJwtToken(user);

         return jwtToken;
      }

      public async Task<IdentityUser> DoesUserExistAsync(UserLoginRequest userLoginRequest)
      {
         var existingUser = await _userManager.FindByEmailAsync(userLoginRequest.Email);

         if (existingUser != null)
         {
            return existingUser;
         }
         return null;
      }
      public async Task<bool> DoesUserExistAsync(UserRegistrationDto userRegistrationDto)
      {
         var existingUser = await _userManager.FindByEmailAsync(userRegistrationDto.Email);

         if (existingUser != null)
         {
            return true;
         }
         return false;
      }

      public async Task<bool> AddAdminRole(UserRegistrationDto userRegistrationDto)
      {
         var user = await _userManager.FindByEmailAsync(userRegistrationDto.Email);
         var result = await _userManager.AddToRoleAsync(user, "Admin");

         if (result.Succeeded)
            return true;
         return false;
      }

      private async Task<string> GenerateJwtToken(IdentityUser user)
      {
         var jwtTokenHandler = new JwtSecurityTokenHandler();

         var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

         var claims = await GetValidClaims(user);

         var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
         var token = new JwtSecurityToken(
             _configuration["Jwt:Issuer"],
             _configuration["Jwt:Audience"],
             claims,
             expires: DateTime.UtcNow.AddMinutes(10),
             signingCredentials: signIn);

         return new JwtSecurityTokenHandler().WriteToken(token);
      }

      private async Task<List<Claim>> GetValidClaims(IdentityUser user)
      {
         IdentityOptions _options = new IdentityOptions();
         var claims = new List<Claim>
         {
               new Claim("Id", user.Id),
               new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
               new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
               new Claim("UserId", user.Id.ToString()),
               new Claim("UserName", user.UserName),
         };

         var userClaims = await _userManager.GetClaimsAsync(user);
         var userRoles = await _userManager.GetRolesAsync(user);
         claims.AddRange(userClaims);
         foreach (var userRole in userRoles)
         {
            claims.Add(new Claim(ClaimTypes.Role, userRole));
            var role = await _roleManager.FindByNameAsync(userRole);
            if (role != null)
            {
               var roleClaims = await _roleManager.GetClaimsAsync(role);
               foreach (Claim roleClaim in roleClaims)
               {
                  claims.Add(roleClaim);
               }
            }
         }
         return claims;
      }
   }
}
