using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IAsyncAppRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Get entity based on id
        /// </summary>
        Task<T> GetAsync(int id);

        /// <summary>
        /// Get listed data for specified entity
        /// </summary>
        Task<IEnumerable<T>> ListAllAsync();

        /// <summary>
        /// Add data
        /// </summary>
        Task<int> AddAsync(T entity);

        /// <summary>
        /// Update data
        /// </summary>
        Task<int> UpdateAsync(T entity);

        /// <summary>
        /// Delete data
        /// </summary>
        Task DeleteAsync(T entity);

        /// <summary>
        /// Get list of data by expression
        /// </summary>
        Task<IEnumerable<T>> GetListByExpression(Expression<Func<T, bool>> expression);
    }
}
