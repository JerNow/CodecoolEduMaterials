using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Models.DTOs.User;

namespace Services.Services.Interfaces
{
   public interface IMyAuthorizationService
   {
      public Task<IdentityUser> DoesUserExistAsync(UserLoginRequest userLoginRequest);
      public Task<bool> DoesUserExistAsync(UserRegistrationDto userRegistrationDto);
      public Task<string> RegisterNewUser(UserRegistrationDto userRegistrationDto);
      public Task<string> LoginUser(UserLoginRequest userLoginRequest, IdentityUser user);
      public Task<bool> AddAdminRole(UserRegistrationDto userRegistrationDto);
   }
}
