using System.ComponentModel.DataAnnotations;

namespace Services.Models.DTOs.Author
{
   public class AuthorUpdateDto
   {
      [Required]
      [StringLength(30, MinimumLength = 3)]
      public string Name { get; set; }
      [Required]
      [StringLength(144)]
      public string Description { get; set; }
   }
}
