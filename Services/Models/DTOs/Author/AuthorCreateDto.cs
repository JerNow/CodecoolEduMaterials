using System.ComponentModel.DataAnnotations;

namespace Services.Models.DTOs.Author
{
   public class AuthorCreateDto
   {
      [Required]
      public string Name { get; set; }
      [Required]
      public string Description { get; set; }
   }
}
