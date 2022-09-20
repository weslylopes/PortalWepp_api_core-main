using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SylerBackend.Domain.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        TEntity GetByIdAsync(Expression<Func<TEntity, bool>> preticate);
        IQueryable<TEntity> GetByFilterAsync(Expression<Func<TEntity, bool>> preticate);
        IQueryable<TEntity> GetByFilterAsNoTrackingAsync(Expression<Func<TEntity, bool>> preticate);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<IList<TEntity>> CreateAsync(IList<TEntity> entity);
        Task<TEntity> Update(TEntity entity);
        Task<IList<TEntity>> Update(IList<TEntity> entity);
        void Remove(Expression<Func<TEntity, bool>> preticate);
        Task RemoveAll(Expression<Func<TEntity, bool>> preticate);
        //TEntity MergeEntity(TEntity source, TEntity destination);
    }
}
