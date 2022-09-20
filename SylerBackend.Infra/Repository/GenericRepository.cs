using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SylerBackend.Domain.Repositories;
using SylerBackend.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SylerBackend.Infra.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : class
    {
        private readonly StylerContext _dbContext;

        public GenericRepository(StylerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        public TEntity GetByIdAsync(Expression<Func<TEntity, bool>> preticate)
        {
            return  _dbContext.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefault(preticate);
        }

        public IQueryable<TEntity> GetByFilterAsync(Expression<Func<TEntity, bool>> preticate)
        {
            return _dbContext.Set<TEntity>()
                .Where(preticate);
        }

        public IQueryable<TEntity> GetByFilterAsNoTrackingAsync(Expression<Func<TEntity, bool>> preticate)
        {
            return _dbContext.Set<TEntity>()
                .AsNoTracking().Where(preticate);
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IList<TEntity>> CreateAsync(IList<TEntity> entity)
        {
            await _dbContext.Set<TEntity>().AddRangeAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            //_dbContext.Entry(entity).State = EntityState.Detached;
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
            //_dbContext.Entry(entity).Reload();
            return entity;
        }

        public async Task<IList<TEntity>> Update(IList<TEntity> entity)
        {
            _dbContext.Set<TEntity>().UpdateRange(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public void Remove(Expression<Func<TEntity, bool>> preticate)
        {
            var entity = GetByIdAsync(preticate);
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChangesAsync();
        }

        public async Task RemoveAll(Expression<Func<TEntity, bool>> preticate)
        {
            var entity = GetByFilterAsync(preticate);
            _dbContext.Set<TEntity>().RemoveRange(entity);
            await _dbContext.SaveChangesAsync();
        }

        //public TEntity MergeEntity(TEntity source, TEntity destination)
        //{
        //    return Mapper.Map<TEntity, TEntity>(source, destination);
        //}

    }
}
