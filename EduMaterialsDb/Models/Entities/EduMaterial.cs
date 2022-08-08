using System.ComponentModel.DataAnnotations;

namespace EduMaterialsDb.Models.Entities
{
   public class EduMaterial
   {
      [Key]
      public int EduMaterialId { get; set; }
      [Required]
      public string Title { get; set; }
      [Required]
      public int AuthorId { get; set; }
      public Author Author { get; set; }
      [Required]
      public string Description { get; set; }
      [Required]
      public string Location { get; set; }
      [Required]
      public int EduMaterialTypeId { get; set; }
      public EduMaterialType EduMaterialType { get; set; }
      public ICollection<EduMaterialReview>? EduMaterialReviews { get; set; }
      [Required]
      public DateOnly PublishDay { get; set; }

      public EduMaterial() => EduMaterialReviews = new List<EduMaterialReview>();
   }
}
