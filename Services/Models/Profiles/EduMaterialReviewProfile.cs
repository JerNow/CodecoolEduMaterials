using AutoMapper;
using EduMaterialsDb.Models.Entities;
using Services.Models.DTOs.EduMaterialReview;

namespace Services.Models.Profiles
{
   public class EduMaterialReviewProfile : Profile
   {
      public EduMaterialReviewProfile()
      {
         CreateMap<EduMaterialReview, EduMaterialReviewReadForListDto>(); 
         CreateMap<EduMaterialReview, EduMaterialReviewReadDto>(); 
         CreateMap<EduMaterialReviewCreateDto, EduMaterialReview>();
         CreateMap<EduMaterialReviewUpdateDto, EduMaterialReview>();
      }
   }
}
