using AuthDb.Context;
using EduMaterialsDb.Context;
using EduMaterialsDb.DAL;
using Microsoft.EntityFrameworkCore;

namespace API
{
   public static class ServicesConfiguration
   {
      public static void AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
      {
         services.AddDbContext<AuthDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("AuthDb")));
         services.AddDbContext<EduMaterialsDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("EduMaterialsDb")));
      }

      public static void AddCustomServices(this IServiceCollection services)
      {
         services.AddScoped<IUnitOfWork, UnitOfWork>();
      }
   }
}
