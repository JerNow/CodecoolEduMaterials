using System.ComponentModel.DataAnnotations;

namespace EduMaterialsDb.Models.Entities
{
   public class EduMaterialReview
   {
      [Key]
      public int EduMaterialReviewId { get; set; }
      [Required]
      [StringLength(144, MinimumLength = 3)]
      public string Review { get; set; }
      [Required]
      [Range(1,10, ErrorMessage = "Must be on the scale 1-10")]
      public int ReviewScore { get; set; }
      [Required]
      public int EduMaterialId { get; set; }
      public EduMaterial EduMaterial { get; set; }
   }
}
