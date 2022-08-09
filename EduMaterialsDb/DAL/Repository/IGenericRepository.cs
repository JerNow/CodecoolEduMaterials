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
      Task<T> GetSingleWithIncludeAndIncludeAsync(Expression<Func<T, bool>> condition, Expression<Func<T, object>> criteriaIncludeFirst, Expression<Func<T, object>> criteriaIncludeSecond);
      Task<T> GetSingleWithIncludeAndIncludeAndIncludeAsync(Expression<Func<T, bool>> condition, Expression<Func<T, object>> criteriaIncludeFirst, Expression<Func<T, object>> criteriaIncludeSecond, Expression<Func<T, object>> criteriaIncludeThird);
      Task<List<T>> GetAllAsync();
      Task<List<T>> GetAllWithIncludeAsync(Expression<Func<T, object>> criteria);
      Task<List<T>> GetAllWithIncludeAndIncludeAsync(Expression<Func<T, object>> criteriaIncludeFirst, Expression<Func<T, object>> criteriaIncludeSecond);
      Task<List<T>> GetAllWithIncludeAndIncludeAndIncludeAsync(Expression<Func<T, object>> criteriaIncludeFirst, Expression<Func<T, object>> criteriaIncludeSecond, Expression<Func<T, object>> criteriaIncludeThird);
      Task<List<T>> GetAllWithConditionAndWithIncludeAsync(Expression<Func<T, bool>> condition, Expression<Func<T, object>> criteria);
      #endregion

      #region SYNC
      IQueryable<T> QueryWithInclude(Expression<Func<T, object>> criteria);
      IQueryable<T> QueryAll();
      #endregion
   }
}
