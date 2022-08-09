using Services.Models.DTOs.EduMaterial;

namespace Services.Models.DTOs.EduMaterialReview
{
   public class EduMaterialReviewReadDto
   {
      public int EduMaterialReviewId { get; set; }
      public string Review { get; set; }
      public int ReviewScore { get; set; }
      public int EduMaterialId { get; set; }
      public EduMaterialReadForReviewDto EduMaterial { get; set; }
   }
}
