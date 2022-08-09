using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.Models.DTOs.EduMaterial;
using Services.Services.Interfaces;

namespace API.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class EduMaterialsController : ControllerBase
   {
      private readonly IEduMaterialService _eduMaterialService;

      public EduMaterialsController(IEduMaterialService eduMaterialService)
      {
         _eduMaterialService = eduMaterialService;
      }

      [HttpGet]
      public async Task<IActionResult> GetAllEduMaterials() 
         => Ok(await _eduMaterialService.GetAllAsync());      
      
      [HttpGet("{id}", Name = "GetSingleEduMaterial")]
      public async Task<IActionResult> GetSingleEduMaterial(int id) 
         => Ok(await _eduMaterialService.GetSingleAsync(em => em.EduMaterialId == id));
      
      [HttpPost]
      public async Task<IActionResult> CreateNewEduMaterial(EduMaterialCreateDto eduMaterialCreateDto)
      {
         var newEduMaterial = await _eduMaterialService.CreateNewAsync(eduMaterialCreateDto);
         return CreatedAtRoute(nameof(GetSingleEduMaterial), new { id = newEduMaterial.EduMaterialId }, newEduMaterial);
      }

      [HttpDelete("{id}")]
      public async Task<IActionResult> DeleteEduMaterial(int id)
      {
         await _eduMaterialService.DeleteAsync(em => em.EduMaterialId == id);
         return NoContent();
      }

      [HttpPut("{id}")]
      public async Task<IActionResult> PutEduMaterial(int id, EduMaterialUpdateDto eduMaterialUpdateDto)
      {
         await _eduMaterialService.PutAsync(em => em.EduMaterialId == id, eduMaterialUpdateDto);
         return NoContent();
      }
      
      [HttpPatch("{id}")]
      public async Task<IActionResult> PatchEduMaterial(int id, JsonPatchDocument eduMaterialPatch)
      {
         await _eduMaterialService.PatchAsync(em => em.EduMaterialId == id, eduMaterialPatch);
         return NoContent();
      }
   }
}
