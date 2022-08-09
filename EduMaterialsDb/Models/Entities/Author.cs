using System.ComponentModel.DataAnnotations;

namespace EduMaterialsDb.Models.Entities
{
   public class Author
   {
      [Key]
      public int AuthorId { get; set; }
      [Required]
      [StringLength(30, MinimumLength = 3)]
      public string Name { get; set; }
      [Required]
      [StringLength(144)]
      public string Description { get; set; }
      public ICollection<EduMaterial>? EduMaterials { get; set; }
      public int EduMaterialsCounter { get { return EduMaterials.Count(); } }

      public Author() => EduMaterials = new List<EduMaterial>();
   }
}
