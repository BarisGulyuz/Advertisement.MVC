﻿using AdvertisementApp.Entities.Concrete;
using AdvertisementApp_DataAccess.Abstract;
using AdvertisementApp_DataAccess.Contexts;
using AdvertisementApp_DataAccess.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp_DataAccess.Concrete
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AdvertisementAppDbContext _context;

        public GenericRepository(AdvertisementAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().Where(filter).ToListAsync();
        }


        public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> selector, OrderByType orderByType = OrderByType.DESC)
        {
            return orderByType == OrderByType.ASC ? await _context.Set<T>().OrderBy(selector).ToListAsync() :
                await _context.Set<T>().OrderByDescending(selector).ToListAsync();
        }
        public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> filter, Expression<Func<T, TKey>> selector, OrderByType orderByType = OrderByType.DESC)
        {
            return orderByType == OrderByType.ASC ? await _context.Set<T>().Where(filter).OrderBy(selector).ToListAsync() :
                await _context.Set<T>().Where(filter).OrderByDescending(selector).ToListAsync();
        }

        public async Task<T> FindAsync(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter, bool asNoTracking = false)
        {
            return !asNoTracking ? await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter) :
                await _context.Set<T>().SingleOrDefaultAsync(filter);
        }

        public IQueryable<T> GetQuery()
        {
            return _context.Set<T>().AsQueryable();
        }
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Update(T entity, T unchanged)
        {
            _context.Entry(unchanged).CurrentValues.SetValues(entity);
        }
    }
}
