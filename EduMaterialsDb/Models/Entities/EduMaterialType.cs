using System.ComponentModel.DataAnnotations;

namespace EduMaterialsDb.Models.Entities
{
   public class EduMaterialType
   {
      [Key]
      public int EduMaterialTypeId { get; set; }
      [Required]
      public string Name { get; set; }
      [Required]
      public string Definition { get; set; }
   }
}
