﻿using AppCore.Entities;
using AppCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AppRepository<T> : IAsyncAppRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext Context;

        public AppRepository(AppDbContext context)
        {
            Context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Context.Set<T>().FindAsync(id);
        }
        
        public async Task<int> AddAsync(T entity)
        {
            Context.Set<T>().Add(entity);
            return await Context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return await Context.SaveChangesAsync();
        }

        public async void DeleteAsync(T entity)
        {
            Context.Set<T>().Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> ListAllAsync()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetListByExpression(Expression<Func<T, bool>> expression)
        {
            return await Context.Set<T>().Where(expression).ToListAsync();
        }
    }
}