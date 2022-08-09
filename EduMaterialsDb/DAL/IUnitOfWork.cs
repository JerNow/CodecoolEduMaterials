using EduMaterialsDb.DAL.Repository;
using EduMaterialsDb.Models.Entities;

namespace EduMaterialsDb.DAL
{
   public interface IUnitOfWork
   {
      IGenericRepository<Author> Authors { get; }
      IGenericRepository<EduMaterialReview> EduMaterialReviews { get; }
      IGenericRepository<EduMaterial> EduMaterials { get; }
      IGenericRepository<EduMaterialType> EduMaterialTypes { get; }

      Task<int> CompleteUnitOfWorkAsync();
   }
}
