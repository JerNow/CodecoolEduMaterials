using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Services.Interfaces;

namespace API.Controllers
{
   [Authorize]
   [Route("api/[controller]")]
   [ApiController]
   public class EduMaterialTypesController : ControllerBase
   {
      private readonly IEduMaterialTypeService _eduMaterialTypeService;

      public EduMaterialTypesController(IEduMaterialTypeService eduMaterialTypeService)
          => _eduMaterialTypeService = eduMaterialTypeService;

      [HttpGet]
      public async Task<IActionResult> GetAllEduMaterialTypes()
         => Ok(await _eduMaterialTypeService.GetAllAsync());

      [HttpGet("{id}")]
      public async Task<IActionResult> GetSingleEduMaterialType(int id)
         => Ok(await _eduMaterialTypeService.GetSingleAsync(em => em.EduMaterialTypeId == id));

      [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
      [HttpGet("{typeName}")]
      public async Task<IActionResult> GetAllMaterialsMaterialsFromType(string typeName)
          => Ok(await _eduMaterialTypeService.GetAllMaterialsFromTypeAsync(em => em.EduMaterialType.Name == typeName));
   }
}
