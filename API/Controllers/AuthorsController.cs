using EduMaterialsDb.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Services.Interfaces;

namespace API.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class AuthorsController : ControllerBase
   {
      private readonly IAuthorService _authorService;

      public AuthorsController(IAuthorService authorService)
      {
         _authorService = authorService;
      }

      [HttpGet]
      public async Task<IActionResult> GetAllAuthorsAsync()
      {
         return Ok(await _authorService.GetAll());
      }
   }
}
