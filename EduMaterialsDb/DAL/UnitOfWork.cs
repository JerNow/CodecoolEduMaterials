using EduMaterialsDb.Context;
using EduMaterialsDb.DAL.Repository;
using EduMaterialsDb.Models.Entities;

namespace EduMaterialsDb.DAL
{
   public class UnitOfWork : IUnitOfWork
   {
      private readonly EduMaterialsDbContext _eduMaterialsDbContext;
      public IGenericRepository<Author> Authors { get; }
      public IGenericRepository<EduMaterial> EduMaterials { get; }
      public IGenericRepository<EduMaterialType> EduMaterialTypes { get; }
      public IGenericRepository<EduMaterialReview> EduMaterialReviews { get; }

      public UnitOfWork(EduMaterialsDbContext eduMaterialsDbContext)
      {
         _eduMaterialsDbContext = eduMaterialsDbContext;
         Authors = new GenericRepository<Author>(_eduMaterialsDbContext);
         EduMaterials = new GenericRepository<EduMaterial>(_eduMaterialsDbContext);
         EduMaterialTypes = new GenericRepository<EduMaterialType>(_eduMaterialsDbContext);
         EduMaterialReviews = new GenericRepository<EduMaterialReview>(_eduMaterialsDbContext);
      }

      public async Task<int> CompleUnitOfWorkAsync()
         => await _eduMaterialsDbContext.SaveChangesAsync();
   }
}
