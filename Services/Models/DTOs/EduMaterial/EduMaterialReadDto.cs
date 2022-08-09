using Services.Models.DTOs.Author;
using Services.Models.DTOs.EduMaterialReview;
using Services.Models.DTOs.EduMaterialType;

namespace Services.Models.DTOs.EduMaterial
{
   public class EduMaterialReadDto
   {
      public int EduMaterialId { get; set; }
      public string Title { get; set; }
      public AuthorReadDto Author { get; set; }
      public string Description { get; set; }
      public string Location { get; set; }
      public EduMaterialTypeReadDto EduMaterialType { get; set; }
      public DateOnly PublishDay { get; set; }
      public ICollection<EduMaterialReviewReadForListDto>? EduMaterialReviews { get; set; }
   }
}
