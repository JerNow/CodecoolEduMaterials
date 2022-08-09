using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Services.Interfaces;

namespace API.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class EduMaterialTypesController : ControllerBase
   {
      private readonly IEduMaterialTypeService _eduMaterialTypeService;

      public EduMaterialTypesController(IEduMaterialTypeService eduMaterialTypeService)
          => _eduMaterialTypeService = eduMaterialTypeService;

      [HttpGet("{Type}")]
      public async Task<IActionResult> GetEpisodeAsync(string typeName)
          => Ok(await _eduMaterialTypeService.GetAllMaterialsFromTypeAsync(em => em.EduMaterialType.Name == typeName));
   }
}
