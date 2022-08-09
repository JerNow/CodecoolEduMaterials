using EduMaterialsDb.Models.Entities;
using Services.Models.DTOs.EduMaterial;
using System.Linq.Expressions;

namespace Services.Services.Interfaces
{
   public interface IEduMaterialService
   {
      public Task<List<EduMaterialReadDto>> GetAllAsync();
      public Task<EduMaterialReadDto> GetSingleAsync(Expression<Func<EduMaterial, bool>> condition);
      public Task<EduMaterialReadDto> CreateNewAsync(EduMaterialCreateDto eduMaterialCreateDto);
      public Task DeleteAsync(Expression<Func<EduMaterial, bool>> condition);
      public Task PutAsync(Expression<Func<EduMaterial, bool>> condition);
   }
}
