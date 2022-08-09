using System.ComponentModel.DataAnnotations;

namespace Services.Models.DTOs.EduMaterialType
{
   public class EduMaterialTypeUpdateDto
   {
      [Required]
      [StringLength(30, MinimumLength = 3)]
      public string Name { get; set; }
      [Required]
      [StringLength(144, MinimumLength = 3)]
      public string Definition { get; set; }
   }
}
