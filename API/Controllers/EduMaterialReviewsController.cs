using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.Models.DTOs.EduMaterialReview;
using Services.Services.Interfaces;

namespace API.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class EduMaterialReviewsController : ControllerBase
   {
      private readonly IEduMaterialReviewService _eduMaterialReviewService;

      public EduMaterialReviewsController(IEduMaterialReviewService eduMaterialReviewService)
      {
         _eduMaterialReviewService = eduMaterialReviewService;
      }

      [HttpGet]
      public async Task<IActionResult> GetAllEduMaterialReviews()
         => Ok(await _eduMaterialReviewService.GetAllAsync());

      [HttpGet("{id}", Name = "GetSingleEduMaterialReview")]
      public async Task<IActionResult> GetSingleEduMaterialReview(int id)
         => Ok(await _eduMaterialReviewService.GetSingleAsync(emr => emr.EduMaterialReviewId == id));

      [HttpPost]
      public async Task<IActionResult> CreateNewEduMaterial(EduMaterialReviewCreateDto eduMaterialReviewCreateDto)
      {
         var newEduMaterialReview = await _eduMaterialReviewService.CreateNewAsync(eduMaterialReviewCreateDto);
         return CreatedAtRoute(nameof(GetSingleEduMaterialReview), new { id = newEduMaterialReview.EduMaterialId }, newEduMaterialReview);
      }

      [HttpDelete("{id}")]
      public async Task<IActionResult> DeleteEduMaterialReview(int id)
      {
         await _eduMaterialReviewService.DeleteAsync(emr => emr.EduMaterialReviewId == id);
         return NoContent();
      }

      [HttpPut("{id}")]
      public async Task<IActionResult> PutEduMaterial(int id, EduMaterialReviewUpdateDto eduMaterialUpdateDto)
      {
         await _eduMaterialReviewService.PutAsync(em => em.EduMaterialId == id, eduMaterialUpdateDto);
         return NoContent();
      }

      [HttpPatch("{id}")]
      public async Task<IActionResult> PatchEduMaterial(int id, JsonPatchDocument eduMaterialPatch)
      {
         await _eduMaterialReviewService.PatchAsync(em => em.EduMaterialId == id, eduMaterialPatch);
         return NoContent();
      }
   }
}
