using EduMaterialsDb.Models.Entities;
using Services.Models.DTOs.Author;
using Services.Models.DTOs.EduMaterial;
using System.Linq.Expressions;

namespace Services.Services.Interfaces
{
   public interface IAuthorService
   {
      public Task<List<AuthorReadDto>> GetAll();
      public Task<List<EduMaterialReadForReviewDto>> GetReviewsAboveAverageFromAuthor(Expression<Func<Author, bool>> condition);
   }
}
