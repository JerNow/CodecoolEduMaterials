using AutoMapper;
using EduMaterialsDb.DAL;
using EduMaterialsDb.Models.Entities;
using Services.Models.DTOs.EduMaterial;
using Services.Services.Interfaces;
using System.Linq.Expressions;

namespace Services.Services.Controllers
{
   public class EduMaterialService : IEduMaterialService
   {
      private readonly IUnitOfWork _unitOfWork;
      private readonly IMapper _mapper;

      public EduMaterialService(IUnitOfWork unitOfWork, IMapper mapper)
      {
         _unitOfWork = unitOfWork;
         _mapper = mapper;
      }

      public async Task<List<EduMaterialReadDto>> GetAllAsync()
      {
         var allEduMaterials = await _unitOfWork.EduMaterials.GetAllWithIncludeAndIncludeAndIncludeAsync(em => em.EduMaterialType, em => em.EduMaterialReviews, em => em.Author);
         return _mapper.Map<List<EduMaterialReadDto>>(allEduMaterials);
      }
      public async Task<EduMaterialReadDto> GetSingleAsync(Expression<Func<EduMaterial, bool>> condition)
      {
         var eduMaterial = await _unitOfWork.EduMaterials.GetSingleWithIncludeAndIncludeAndIncludeAsync(condition ,em => em.EduMaterialType, em => em.EduMaterialReviews, em => em.Author);
         return _mapper.Map<EduMaterialReadDto>(eduMaterial);
      }

      public async Task<EduMaterialReadDto> CreateNewAsync(EduMaterialCreateDto eduMaterialCreateDto)
      {
         var newEduMaterial = _mapper.Map<EduMaterial>(eduMaterialCreateDto);
         _unitOfWork.EduMaterials.AddAsync(newEduMaterial);
         await _unitOfWork.CompleUnitOfWorkAsync();
         return _mapper.Map<EduMaterialReadDto>(newEduMaterial);
      }

   }
}
