using System.ComponentModel.DataAnnotations;

namespace Services.Models.DTOs.User
{
   public class UserRegistrationDto
   {
      [Required]
      public string Username { get; set; }
      [Required]
      [EmailAddress]
      public string Email { get; set; }
      [Required]
      public string Password { get; set; }
   }
}
