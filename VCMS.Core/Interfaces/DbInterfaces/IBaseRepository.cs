namespace VCMS.Core.Interfaces.DbInterfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        T Update(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        Task<T> FindAsync(Expression<Func<T, bool>> predicate, string[] includes = null);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate, string[] includes = null);
        Task<IEnumerable<T>> PaginateAsync(Expression<Func<T, bool>> predicate, int skip, int take,
            Expression<Func<T, object>> orderby = null, string orderByDirection = OrderBy.Ascending);
        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    }
}
