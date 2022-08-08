using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthDb.Context
{
   public class AuthDbContext : IdentityDbContext
   {
      public AuthDbContext(DbContextOptions<AuthDbContext> options)
         : base(options)
      {
      }
   }
}
