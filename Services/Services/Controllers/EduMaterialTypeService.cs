using AutoMapper;
using EduMaterialsDb.DAL;
using EduMaterialsDb.Models.Entities;
using Services.Models.DTOs.EduMaterial;
using Services.Models.DTOs.EduMaterialType;
using Services.Services.Interfaces;
using System.Linq.Expressions;

namespace Services.Services.Controllers
{
   public class EduMaterialTypeService : IEduMaterialTypeService
   {
      private readonly IUnitOfWork _unitOfWork;
      private readonly IMapper _mapper;

      public EduMaterialTypeService(IUnitOfWork unitOfWork, IMapper mapper)
      {
         _unitOfWork = unitOfWork;
         _mapper = mapper;
      }

      public async Task<List<EduMaterialTypeReadDto>> GetAllAsync()
      {
         var allEduMaterialTypes = await _unitOfWork.EduMaterialTypes.GetAllAsync();
         return _mapper.Map<List<EduMaterialTypeReadDto>>(allEduMaterialTypes);
      }

      public async Task<List<EduMaterialReadForReviewDto>> GetAllMaterialsFromTypeAsync(Expression<Func<EduMaterial, bool>> condition)
      {
         var eduMaterials = await _unitOfWork.EduMaterials.GetAllWithConditionAndWithIncludeAsync(condition, em => em.Author);
         if(eduMaterials is null)
            throw new ArgumentNullException($"Educational Material Type not found");

         return _mapper.Map<List<EduMaterialReadForReviewDto>>(eduMaterials);
      }

      public async Task<EduMaterialTypeReadDto> GetSingleAsync(Expression<Func<EduMaterialType, bool>> condition)
      {
         var eduMaterialType = await _unitOfWork.EduMaterialTypes.GetSingleAsync(condition);
         return _mapper.Map<EduMaterialTypeReadDto>(eduMaterialType);
      }
   }
}
