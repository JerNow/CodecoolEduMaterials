using Services.Models.DTOs.Author;

namespace Services.Models.DTOs.EduMaterial
{
   public class EduMaterialReadForReviewDto
   {
      public int EduMaterialId { get; set; }
      public string Title { get; set; }
      public AuthorReadDto Author { get; set; }
   }
}
