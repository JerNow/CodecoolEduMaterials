using EduMaterialsDb.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class AuthorsController : ControllerBase
   {
      private readonly IUnitOfWork _unitOfWork;

      public AuthorsController(IUnitOfWork unitOfWork)
      {
         _unitOfWork = unitOfWork;
      }

      [HttpGet]
      public async Task<IActionResult> GetAllAuthorsAsync()
      {
         var authors = await _unitOfWork.Authors.GetAllAsync();
         return Ok(authors);
      }
   }
}
