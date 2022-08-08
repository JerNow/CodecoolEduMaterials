using EduMaterialsDb.Models.Entities;
using EduMaterialsDb.Utils;
using Microsoft.EntityFrameworkCore;

namespace EduMaterialsDb.Context
{
   public class EduMaterialsDbContext : DbContext
   {
      public DbSet<Author> Authors { get; set; }
      public DbSet<EduMaterial> EduMaterials { get; set; }
      public DbSet<EduMaterialReview> EduMaterialReviews { get; set; }
      public DbSet<EduMaterialType> EduMaterialTypes { get; set; }

      public EduMaterialsDbContext(DbContextOptions<EduMaterialsDbContext> options) : base(options)
      {
      }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.Entity<EduMaterial>(builder =>
         {
            builder.Property(em => em.PublishDay)
               .HasConversion<DateOnlyConverter, DateOnlyComparer>();
         });
      }
   }
}
