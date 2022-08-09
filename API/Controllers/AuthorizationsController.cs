using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Models.DTOs.User;
using Services.Services.Interfaces;

namespace API.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class AuthorizationsController : ControllerBase
   {
      private readonly IMyAuthorizationService _authorizationService;

      public AuthorizationsController(IMyAuthorizationService authorizationService)
      {
         _authorizationService = authorizationService;
      }

      [HttpPost]
      [Route("Register")]
      public async Task<IActionResult> Register(UserRegistrationDto userRegistrationDto)
      {
         var checkResult = await _authorizationService.DoesUserExistAsync(userRegistrationDto);
         if (checkResult == true)
            return BadRequest("User with that email already exist");
         var registerResult = await _authorizationService.RegisterNewUser(userRegistrationDto);
         if (registerResult == string.Empty)
            return BadRequest("Creation process failed, try again with different credentials");
         return Ok(registerResult);
      }

      [HttpPost]
      [Route("Login")]
      public async Task<IActionResult> Login(UserLoginRequest userLoginRequest)
      {
         var userFromDb = await _authorizationService.DoesUserExistAsync(userLoginRequest);
         if (userFromDb == null)
            return BadRequest("User with that email doesnt exist");

         var result = await _authorizationService.LoginUser(userLoginRequest, userFromDb);
         if (result == string.Empty)
            return BadRequest("Invalid creditentials");
         return Ok(result);
      }

      [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
      [HttpPost]
      [Route("RegisterAdmin")]
      public async Task<IActionResult> RegisterAdmin(UserRegistrationDto userRegistrationDto)
      {
         var checkResult = await _authorizationService.DoesUserExistAsync(userRegistrationDto);
         if (checkResult == true)
            return BadRequest("User with that email already exist");
         var registerResult = await _authorizationService.RegisterNewUser(userRegistrationDto);
         var roleAdditionresult = await _authorizationService.AddAdminRole(userRegistrationDto);
         if(roleAdditionresult)
            return Ok(registerResult);
         throw new Exception("Can't add Admin role");
      }
   }
}
