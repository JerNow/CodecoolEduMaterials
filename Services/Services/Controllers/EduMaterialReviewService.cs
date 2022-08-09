using AutoMapper;
using EduMaterialsDb.DAL;
using EduMaterialsDb.Models.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Services.Models.DTOs.EduMaterialReview;
using Services.Services.Interfaces;
using System.Linq.Expressions;

namespace Services.Services.Controllers
{
   public class EduMaterialReviewService : IEduMaterialReviewService
   {
      private readonly IUnitOfWork _unitOfWork;
      private readonly IMapper _mapper;

      public EduMaterialReviewService(IUnitOfWork unitOfWork, IMapper mapper)
      {
         _unitOfWork = unitOfWork;
         _mapper = mapper;
      }
      public async Task<EduMaterialReviewReadDto> CreateNewAsync(EduMaterialReviewCreateDto eduMaterialReviewCreateDto)
      {
         var newEduMaterialReview = _mapper.Map<EduMaterialReview>(eduMaterialReviewCreateDto);
         await _unitOfWork.EduMaterialReviews.AddAsync(newEduMaterialReview);
         await _unitOfWork.CompleteUnitOfWorkAsync();
         return _mapper.Map<EduMaterialReviewReadDto>(newEduMaterialReview);
      }

      public async Task DeleteAsync(Expression<Func<EduMaterialReview, bool>> condition)
      {
         var eduMaterialReviewToDelete = await _unitOfWork.EduMaterialReviews.GetSingleAsync(condition);
         if (eduMaterialReviewToDelete is null)
            throw new ArgumentNullException($"Educational material Review not found");

         await _unitOfWork.EduMaterialReviews.DeleteAsync(eduMaterialReviewToDelete);
         await _unitOfWork.CompleteUnitOfWorkAsync();
      }

      public async Task<List<EduMaterialReviewReadDto>> GetAllAsync()
      {
         var allEduMaterialReviews = await _unitOfWork.EduMaterialReviews.GetAllWithIncludeAsync(emr => emr.EduMaterial);
         return _mapper.Map<List<EduMaterialReviewReadDto>>(allEduMaterialReviews);
      }

      public async Task<EduMaterialReviewReadDto> GetSingleAsync(Expression<Func<EduMaterialReview, bool>> condition)
      {
         var eduMaterialReview = await _unitOfWork.EduMaterialReviews.GetSingleWithIncludeAsync(condition, emr => emr.EduMaterial);
         return _mapper.Map<EduMaterialReviewReadDto>(eduMaterialReview);
      }

      public async Task PatchAsync(Expression<Func<EduMaterialReview, bool>> condition, JsonPatchDocument eduMaterialReviewPatch)
      {
         var eduMaterialReviewToUpdate = await _unitOfWork.EduMaterialReviews.GetSingleAsync(condition);
         if (eduMaterialReviewToUpdate is null)
            throw new ArgumentNullException($"Educational material Review not found");

         eduMaterialReviewPatch.ApplyTo(eduMaterialReviewToUpdate);
         await _unitOfWork.CompleteUnitOfWorkAsync();
      }

      public async Task PutAsync(Expression<Func<EduMaterialReview, bool>> condition, EduMaterialReviewUpdateDto eduMaterialReviewUpdateDto)
      {
         var eduMaterialReviewToUpdate = await _unitOfWork.EduMaterialReviews.GetSingleAsync(condition);
         if (eduMaterialReviewToUpdate is null)
            throw new ArgumentNullException($"Educational material Review not found");

         _mapper.Map(eduMaterialReviewUpdateDto, eduMaterialReviewToUpdate);

         await _unitOfWork.EduMaterialReviews.EditAsync(eduMaterialReviewToUpdate);
      }
   }
}
