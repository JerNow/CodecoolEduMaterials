using System.ComponentModel.DataAnnotations;

namespace Services.Models.DTOs.User
{
   public class UserLoginRequest
   {
      [Required]
      [EmailAddress]
      public string Email { get; set; }
      [Required]
      public string Password { get; set; }
   }
}
