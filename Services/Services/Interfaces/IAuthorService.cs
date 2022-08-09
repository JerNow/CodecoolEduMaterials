using Services.Models.DTOs.Author;

namespace Services.Services.Interfaces
{
   public interface IAuthorService
   {
      public Task<List<AuthorReadDto>> GetAll();
   }
}
