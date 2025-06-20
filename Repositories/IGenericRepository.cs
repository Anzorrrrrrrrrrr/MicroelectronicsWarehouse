﻿using System.Linq.Expressions;

namespace MicroelectronicsWarehouse.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task DeleteAsync(int id);

        void Remove(T entity);
        void Update(T entity);


        IQueryable<T> GetAll();

    }
}
