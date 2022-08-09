using System.ComponentModel.DataAnnotations;

namespace Services.Models.DTOs.EduMaterial
{
   public class EduMaterialUpdateDto
   {
      [Required]
      public string Title { get; set; }
      [Required]
      public int AuthorId { get; set; }
      [Required]
      public string Description { get; set; }
      [Required]
      public string Location { get; set; }
      [Required]
      public int EduMaterialTypeId { get; set; }
      [Required]
      public DateOnly PublishDay { get; set; }
   }
}
