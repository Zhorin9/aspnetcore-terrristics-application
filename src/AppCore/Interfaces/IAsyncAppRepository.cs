using AppCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AppCore.Interfaces
{
    public interface IAsyncAppRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Get entity based on id
        /// </summary>
        Task<T> GetByIdAsync(int id);

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
        void DeleteAsync(T entity);

        /// <summary>
        /// Get list of data by expression
        /// </summary>
        Task<IEnumerable<T>> GetListByExpression(Expression<Func<T, bool>> expression);
    }
}
