using System.ComponentModel.DataAnnotations;

namespace EduMaterialsDb.Models.Entities
{
   public class EduMaterialType
   {
      [Key]
      public int EduMaterialTypeId { get; set; }
      [Required]
      [StringLength(30, MinimumLength = 3)]
      public string Name { get; set; }
      [Required]
      [StringLength(144, MinimumLength = 3)]
      public string Definition { get; set; }
   }
}
