using EduMaterialsDb.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EduMaterialsDb.DAL.Repository
{
   public class GenericRepository<T> : IGenericRepository<T> where T : class
   {
      private EduMaterialsDbContext _eduMaterialsDbContext;
      private DbSet<T> _dbSet;

      public GenericRepository(EduMaterialsDbContext eduMaterialsDbContext)
      {
         _eduMaterialsDbContext = eduMaterialsDbContext;
         _dbSet = _eduMaterialsDbContext.Set<T>();
      }

      #region ASYNC
      public async Task AddAsync(T entity)
      {
         await _dbSet.AddAsync(entity);
         await _eduMaterialsDbContext.SaveChangesAsync();
      }

      public async Task DeleteAsync(T entity)
      {
         _dbSet.Remove(entity);
         await _eduMaterialsDbContext.SaveChangesAsync();
      }

      public async Task EditAsync(T entity)
      {
         _dbSet.Attach(entity);
         _eduMaterialsDbContext.Entry(entity).State = EntityState.Modified;
         await _eduMaterialsDbContext.SaveChangesAsync();
      }

      public async Task<List<T>> GetAllAsync()
         => await _dbSet.ToListAsync();

      public async Task<List<T>> GetAllWithIncludeAsync(Expression<Func<T, object>> criteria)
         => await _dbSet.Include(criteria).ToListAsync();

      public async Task<T> GetSingleAsync(Expression<Func<T, bool>> condition)
         => await _dbSet.Where(condition).FirstOrDefaultAsync();

      public async Task<T> GetSingleWithIncludeAsync(Expression<Func<T, bool>> condition, Expression<Func<T, object>> criteria)
         => await _dbSet.Where(condition).Include(criteria).FirstOrDefaultAsync();
      #endregion

      #region SYNC
      public IQueryable<T> QueryAll()
         => _dbSet;

      public IQueryable<T> QueryWithInclude(Expression<Func<T, object>> criteria)
         => _dbSet.Include(criteria);
      #endregion
   }
}
