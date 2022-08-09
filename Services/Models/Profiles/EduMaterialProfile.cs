using AutoMapper;
using EduMaterialsDb.Models.Entities;
using Services.Models.DTOs.EduMaterial;

namespace Services.Models.Profiles
{
   public class EduMaterialProfile : Profile
   {
      public EduMaterialProfile()
      {
         CreateMap<EduMaterial, EduMaterialReadDto>();
         CreateMap<EduMaterialCreateDto, EduMaterial>();
      }
   }
}
