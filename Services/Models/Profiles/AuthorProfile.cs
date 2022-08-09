using AutoMapper;
using EduMaterialsDb.Models.Entities;
using Services.Models.DTOs.Author;

namespace Services.Models.Profiles
{
   public class AuthorProfile : Profile
   {
      public AuthorProfile()
      {
         CreateMap<Author, AuthorReadDto>();
         CreateMap<AuthorCreateDto, Author>();
      }
   }
}
