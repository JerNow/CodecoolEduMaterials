using AutoMapper;
using EduMaterialsDb.DAL;
using EduMaterialsDb.Models.Entities;
using Services.Models.DTOs.Author;
using Services.Models.DTOs.EduMaterial;
using Services.Services.Interfaces;
using System.Linq.Expressions;

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

      public async Task<List<EduMaterialReadForReviewDto>> GetReviewsAboveAverageFromAuthor(Expression<Func<Author, bool>> condition)
      {
         throw new NotImplementedException();
         //var author = await _unitOfWork.Authors.GetSingleWithIncludeAsync(condition, a => a.EduMaterials.Select(em => em.EduMaterialReviews.Select(emr => emr.ReviewScore).ToList()).ToList());
         //var author = await _unitOfWork.Authors.GetSingleWithIncludeAndIncludeAndIncludeAsync(condition, a => a.EduMaterials, a => a.EduMaterials.Select(em => em.EduMaterialReviews).ToList(), a => a.EduMaterials.Select(em => em.EduMaterialReviews.Select(emr => emr.ReviewScore).ToList()).ToList());
         //if (author is null)
         //   throw new ArgumentNullException($"Author not found");

         //var aboveAverageMaterialList = new List<EduMaterialReadForReviewDto>();
         //foreach(EduMaterial eduMaterial in author.EduMaterials)
         //{
         //   AddOnlyAboveAverageMaterialToList(aboveAverageMaterialList, eduMaterial);//
         //}
         //return aboveAverageMaterialList;
      }

      private void AddOnlyAboveAverageMaterialToList(List<EduMaterialReadForReviewDto> aboveAverageMaterialList, EduMaterial eduMaterial)
      {
         int count = 0;
         int score = 0;
         foreach (EduMaterialReview eduMaterialReview in eduMaterial.EduMaterialReviews)
         {
            score += eduMaterialReview.ReviewScore;
            count++;
         }
         if (score / count > 5)
            aboveAverageMaterialList.Add(_mapper.Map<EduMaterialReadForReviewDto>(eduMaterial));
      }
   }
}
