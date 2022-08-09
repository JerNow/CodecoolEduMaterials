using System.ComponentModel.DataAnnotations;

namespace Services.Models.DTOs.Author
{
   public class AuthorUpdateDto
   {
      [Required]
      public string Name { get; set; }
      [Required]
      public string Description { get; set; }
   }
}
