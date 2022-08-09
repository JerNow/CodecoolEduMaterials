using AutoMapper;
using EduMaterialsDb.DAL;
using Services.Models.DTOs.Author;
using Services.Services.Interfaces;

namespace Services.Services.Controllers
{
   public class AuthorService : IAuthorService
   {
      private readonly IUnitOfWork _unitOfWork;
      private readonly IMapper _mapper;

      public AuthorService(IUnitOfWork unitOfWork, IMapper mapper)
      {
         _unitOfWork = unitOfWork;
         _mapper = mapper;
      }

      public async Task<List<AuthorReadDto>> GetAll()
      {
         var allAuthors = await _unitOfWork.Authors.GetAllAsync();
         return _mapper.Map<List<AuthorReadDto>>(allAuthors);
      }
   }
}
