﻿using FirstShop.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Data.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntities
    {
        private readonly AppDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            this._dbSet = _context.Set<TEntity>();
        }


        public async Task<long> AddEntity(TEntity entity)
        {
            entity.DataCreated = DateTime.Now;
            await _dbSet.AddAsync(entity);
            return entity.id;
        }

        public void DeleteEntity(TEntity entity)
        {
            entity.IsDeleted = true;
            EditEntity(entity);
        }

        public async ValueTask DisposeAsync()
        {
            if (_context != null)
            {
                await _context.DisposeAsync();
            }
        }

        public void EditEntity(TEntity entity)
        {
            entity.DateModified = DateTime.Now;
            _dbSet.Update(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsEnumerable<TEntity>();
        }

        public IAsyncEnumerable<TEntity> GetAllAsync()
        {
            return _dbSet.AsAsyncEnumerable<TEntity>();
        }

        public  TEntity GetEntityById(long? id)
        {
            return _dbSet.SingleOrDefault<TEntity>(e => e.id == id);
        }

        public async Task<TEntity> GetEntityByIdAsync(long? Id)
        {
            return await _dbSet.SingleOrDefaultAsync<TEntity>(e => e.id == Id);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}