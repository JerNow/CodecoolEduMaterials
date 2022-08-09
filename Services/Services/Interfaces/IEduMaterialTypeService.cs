using EduMaterialsDb.Models.Entities;
using Services.Models.DTOs.EduMaterial;
using System.Linq.Expressions;

namespace Services.Services.Interfaces
{
   public interface IEduMaterialTypeService
   {
      public Task<List<EduMaterialReadForReviewDto>> GetAllMaterialsFromTypeAsync(Expression<Func<EduMaterial, bool>> condition);
   }
}
