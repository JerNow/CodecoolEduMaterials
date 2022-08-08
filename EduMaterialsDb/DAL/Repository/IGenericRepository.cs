using System.Linq.Expressions;

namespace EduMaterialsDb.DAL.Repository
{
   public interface IGenericRepository<T> where T : class
   {
      #region ASYNC
      Task AddAsync(T entity);
      Task DeleteAsync(T entity);
      Task EditAsync(T entity);
      Task<T> GetSingleAsync(Expression<Func<T, bool>> condition);
      Task<T> GetSingleWithIncludeAsync(Expression<Func<T, bool>> condition, Expression<Func<T, object>> criteria);
      Task<List<T>> GetAllAsync();
      Task<List<T>> GetAllWithIncludeAsync(Expression<Func<T, object>> criteria);
      #endregion

      #region SYNC
      IQueryable<T> QueryWithInclude(Expression<Func<T, object>> criteria);
      IQueryable<T> QueryAll();
      #endregion
   }
}
