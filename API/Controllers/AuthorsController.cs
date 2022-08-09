using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Services.Interfaces;

namespace API.Controllers
{
   [Authorize]
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

      [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
      [HttpGet("{AuthorName}/MaterialsWithReviewsAboveAverage")]
      public async Task<IActionResult> GetReviewsAboveAverage(string authorName)
      {
         return Ok(await _authorService.GetReviewsAboveAverageFromAuthor(a => a.Name == authorName));
      }
   }
}
