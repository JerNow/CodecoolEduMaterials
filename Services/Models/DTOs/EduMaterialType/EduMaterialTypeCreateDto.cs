using System.ComponentModel.DataAnnotations;

namespace Services.Models.DTOs.EduMaterialType
{
   public class EduMaterialTypeCreateDto
   {
      [Required]
      public string Name { get; set; }
      [Required]
      public string Definition { get; set; }
   }
}
