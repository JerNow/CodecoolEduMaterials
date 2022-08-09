using AutoMapper;
using EduMaterialsDb.DAL;
using EduMaterialsDb.Models.Entities;
using Microsoft.AspNetCore.JsonPatch;
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
         await _unitOfWork.EduMaterials.AddAsync(newEduMaterial);
         await _unitOfWork.CompleteUnitOfWorkAsync();
         return _mapper.Map<EduMaterialReadDto>(newEduMaterial);
      }

      public async Task DeleteAsync(Expression<Func<EduMaterial, bool>> condition)
      {
         var eduMaterialToDelete = await _unitOfWork.EduMaterials.GetSingleAsync(condition);
         if (eduMaterialToDelete is null)
            throw new ArgumentNullException($"Educational material not found");

         await _unitOfWork.EduMaterials.DeleteAsync(eduMaterialToDelete);
         await _unitOfWork.CompleteUnitOfWorkAsync();
      }

      public async Task PutAsync(Expression<Func<EduMaterial, bool>> condition, EduMaterialUpdateDto eduMaterialUpdateDto)
      {
         var eduMaterialToUpdate = await _unitOfWork.EduMaterials.GetSingleAsync(condition);
         if (eduMaterialToUpdate is null)
            throw new ArgumentNullException($"Educational material not found");

         _mapper.Map(eduMaterialUpdateDto, eduMaterialToUpdate);

         await _unitOfWork.EduMaterials.EditAsync(eduMaterialToUpdate);
      }

      public async Task PatchAsync(Expression<Func<EduMaterial, bool>> condition, JsonPatchDocument eduMaterialPatch)
      {
         var eduMaterialToUpdate = await _unitOfWork.EduMaterials.GetSingleAsync(condition);
         if (eduMaterialToUpdate is null)
            throw new ArgumentNullException($"Educational material not found");

         eduMaterialPatch.ApplyTo(eduMaterialToUpdate);
         await _unitOfWork.CompleteUnitOfWorkAsync();
      }
   }
}
