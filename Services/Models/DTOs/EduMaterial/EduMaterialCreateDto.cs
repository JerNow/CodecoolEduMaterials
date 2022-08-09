using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.DTOs.EduMaterial
{
   public class EduMaterialCreateDto
   {
      [Required]
      [StringLength(30, MinimumLength = 3)]
      public string Title { get; set; }
      [Required]
      public int AuthorId { get; set; }
      [Required]
      [StringLength(144, MinimumLength = 3)]
      public string Description { get; set; }
      [Required]
      [StringLength(64, MinimumLength = 3)]
      public string Location { get; set; }
      [Required]
      public int EduMaterialTypeId { get; set; }
      [Required]
      public DateOnly PublishDay { get; set; }
   }
}
