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

      public async Task<List<EduMaterialReadForReviewDto>> GetAllMaterialsFromTypeAsync(Expression<Func<EduMaterial, bool>> condition)
      {
         var eduMaterials = await _unitOfWork.EduMaterials.GetSingleWithIncludeAsync(condition, em => em.EduMaterialType);
         return _mapper.Map<List<EduMaterialReadForReviewDto>>(eduMaterials);
      }
   }
}
