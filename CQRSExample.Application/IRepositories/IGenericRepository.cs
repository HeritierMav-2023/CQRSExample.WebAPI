using CQRSExample.Domain.Entities;
using System;
using System.Collections.Generic;


namespace CQRSExample.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns>The all dataset.</returns>
        Task<List<T>> GetAllAsync();

        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns>The object dataset.</returns>
        Task<T> GetbyIdAsync(int id);

        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);

        /// <summary>
        /// MediatR Notification
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="evt"></param>
        /// <returns></returns>
        Task<T> EventOccured(T entity, string evt);
    }
}
