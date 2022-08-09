using AutoMapper;
using EduMaterialsDb.Models.Entities;
using Services.Models.DTOs.EduMaterialType;

namespace Services.Models.Profiles
{
   public class EduMaterialTypeProfile : Profile
   {
      public EduMaterialTypeProfile()
      {
         CreateMap<EduMaterialType, EduMaterialTypeReadDto>();
      }
   }
}
