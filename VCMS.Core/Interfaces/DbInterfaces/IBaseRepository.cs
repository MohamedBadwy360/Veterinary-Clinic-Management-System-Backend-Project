namespace VCMS.Core.Interfaces.DbInterfaces
{
    /// <summary>
    /// Base repository interface for all repositories in the application to implement common methods 
    /// for CRUD operations and querying the database.
    /// </summary>
    /// <typeparam name="T">
    /// The entity type that the repository is responsible for.
    /// </typeparam>
    public interface IBaseRepository<T> where T : class
    {
        /// <summary>
        /// Get an entity of type <see cref="T"/> by its id asynchronously.
        /// </summary>
        /// <param name="id">
        /// The id of the entity to get.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains 
        /// <see cref="T"/> object which includes the entity with the given id.
        /// </returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Get all entities of type <see cref="T"/> asynchronously.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains
        /// <see cref="IEnumerable{T}"/> object which includes all entities of type <see cref="T"/>.
        /// </returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Get all entities of type <see cref="T"/> asynchronously with the specified navigation properties.
        /// </summary>
        /// <param name="includes">
        /// The navigation properties to include in the query.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains
        /// <see cref="IEnumerable{T}"/> object which includes all entities of type <see cref="T"/>
        /// with the specified navigation properties.
        /// </returns>
        Task<IEnumerable<T>> GetAllAsync(string[] includes);

        /// <summary>
        /// Get all entities of type <see cref="T"/> asynchronously with the specified navigation properties.
        /// </summary>
        /// <param name="includes">
        /// The navigation properties to include in the query.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains
        /// <see cref="IEnumerable{T}"/> object which includes all entities of type <see cref="T"/>
        /// with the specified navigation properties.
        /// </returns>
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Add an entity of type <see cref="T"/> asynchronously.
        /// </summary>
        /// <param name="entity">
        /// The entity to add.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains
        /// <see cref="T"/> object which includes the added entity.
        /// </returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Update an entity of type <see cref="T"/> asynchronously.
        /// </summary>
        /// <param name="entity">
        /// The entity to update.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains
        /// <see cref="T"/> object which includes the updated entity.
        /// </returns>
        T Update(T entity);

        /// <summary>
        /// Delete an entity of type <see cref="T"/> asynchronously.
        /// </summary>
        /// <param name="entity">
        /// The entity to delete.
        /// </param>
        void Delete(T entity);

        /// <summary>
        /// Delete a range of entities of type <see cref="T"/> asynchronously.
        /// </summary>
        /// <param name="entities">
        /// The entities to delete.
        /// </param>
        void DeleteRange(IEnumerable<T> entities);

        /// <summary>
        /// Find an entity of type <see cref="T"/> asynchronously with the specified predicate.
        /// </summary>
        /// <param name="predicate">
        /// The predicate to filter the entities.
        /// </param>
        /// <param name="includes">
        /// The navigation properties to include in the query.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains
        /// <see cref="T"/> object which includes the entity that matches the predicate.
        /// </returns>
        Task<T> FindAsync(Expression<Func<T, bool>> predicate, string[] includes = null);

        /// <summary>
        /// Find an entity of type <see cref="T"/> asynchronously with the specified predicate.
        /// </summary>
        /// <param name="predicate">
        /// The predicate to filter the entities.
        /// </param>
        /// <param name="includes">
        /// The navigation properties to include in the query.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains
        /// <see cref="T"/> object which includes the entity that matches the predicate.
        /// </returns>
        Task<T> FindAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Find all entities of type <see cref="T"/> asynchronously with the specified predicate.
        /// </summary>
        /// <param name="predicate">
        /// The predicate to filter the entities.
        /// </param>
        /// <param name="includes">
        /// The navigation properties to include in the query.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains
        /// <see cref="IEnumerable{T}"/> object which includes all entities that match the predicate.
        /// </returns>
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate, string[] includes = null);

        /// <summary>
        /// Find all entities of type <see cref="T"/> asynchronously with the specified predicate.
        /// </summary>
        /// <param name="predicate">
        /// The predicate to filter the entities.
        /// </param>
        /// <param name="includes">
        /// The navigation properties to include in the query.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains
        /// <see cref="IEnumerable{T}"/> object which includes all entities that match the predicate.
        /// </returns>
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate, 
            params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Find all entities of type <see cref="T"/> asynchronously with the specified predicate.
        /// </summary>
        /// <param name="predicate">
        /// The predicate to filter the entities.
        /// </param>
        /// <param name="skip">
        /// The number of entities to skip.
        /// </param>
        /// <param name="take">
        /// The number of entities to take.
        /// </param>
        /// <param name="orderby">
        /// The order by expression.
        /// </param>
        /// <param name="orderByDirection">
        /// The order by direction.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains
        /// <see cref="IEnumerable{T}"/> object which includes all entities that match the predicate.
        /// </returns>
        Task<IEnumerable<T>> PaginateAsync(Expression<Func<T, bool>> predicate, int skip, int take,
            Expression<Func<T, object>> orderby = null, string orderByDirection = OrderBy.Ascending);

        /// <summary>
        /// Count all entities of type <see cref="T"/> asynchronously.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains
        /// the number of entities of type <see cref="T"/>.
        /// </returns>
        Task<int> CountAsync();

        /// <summary>
        /// Count all entities of type <see cref="T"/> asynchronously with the specified predicate.
        /// </summary>
        /// <param name="predicate">
        /// The predicate to filter the entities.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains
        /// the number of entities of type <see cref="T"/> that match the predicate.
        /// </returns>
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Check if any entity of type <see cref="T"/> exists asynchronously with the specified predicate.
        /// </summary>
        /// <param name="predicate">
        /// The predicate to filter the entities.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains
        /// a boolean value indicating whether any entity of type <see cref="T"/> exists that matches the predicate.
        /// </returns>
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

    }
}
