using EduMaterialsDb.Models.Entities;
using Services.Models.DTOs.EduMaterial;
using Services.Models.DTOs.EduMaterialType;
using System.Linq.Expressions;

namespace Services.Services.Interfaces
{
   public interface IEduMaterialTypeService
   {
      public Task<List<EduMaterialTypeReadDto>> GetAllAsync();
      public Task<EduMaterialTypeReadDto> GetSingleAsync(Expression<Func<EduMaterialType, bool>> condition);
      public Task<List<EduMaterialReadForReviewDto>> GetAllMaterialsFromTypeAsync(Expression<Func<EduMaterial, bool>> condition);
   }
}
