using EduMaterialsDb.Models.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Services.Models.DTOs.EduMaterialReview;
using System.Linq.Expressions;

namespace Services.Services.Interfaces
{
   public interface IEduMaterialReviewService
   {
      public Task<List<EduMaterialReviewReadDto>> GetAllAsync();
      public Task<EduMaterialReviewReadDto> GetSingleAsync(Expression<Func<EduMaterialReview, bool>> condition);
      public Task<EduMaterialReviewReadDto> CreateNewAsync(EduMaterialReviewCreateDto eduMaterialCreateDto);
      public Task DeleteAsync(Expression<Func<EduMaterialReview, bool>> condition);
      public Task PutAsync(Expression<Func<EduMaterialReview, bool>> condition, EduMaterialReviewUpdateDto eduMaterialUpdateDto);
      public Task PatchAsync(Expression<Func<EduMaterialReview, bool>> condition, JsonPatchDocument eduMaterialPatch);
   }
}
