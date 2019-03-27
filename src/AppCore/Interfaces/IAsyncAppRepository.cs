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
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Get listed data for specified entity
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> ListAllAsync();

        /// <summary>
        /// Add data
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void AddAsync(T entity);

        /// <summary>
        /// Update data
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void UpdateAsync(T entity);

        /// <summary>
        /// Delete data
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void DeleteAsync(T entity);

        /// <summary>
        /// Get list of data by expression
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetListByExpression(Expression<Func<T, bool>> expression);
    }
}
