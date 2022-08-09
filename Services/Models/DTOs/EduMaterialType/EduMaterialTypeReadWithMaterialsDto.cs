using Services.Models.DTOs.EduMaterial;

namespace Services.Models.DTOs.EduMaterialType
{
   public class EduMaterialTypeReadWithMaterialsDto
   {
      public int EduMaterialTypeId { get; set; }
      public string Name { get; set; }
      public string Definition { get; set; }
      public ICollection<EduMaterialReadDto>? EduMaterials { get; set; }
   }
}
