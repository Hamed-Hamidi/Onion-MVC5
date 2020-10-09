using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Onion.Data.Common;
using Onion.Repository.ApplicationContext;

namespace Onion.Repository.DataTransfer
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private OnionContext _context;

        private DbSet<TEntity> _dbSet;

        public Repository(OnionContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            IQueryable<TEntity> queryable = _dbSet;

            if (filter != null)
            {
                queryable = queryable.Where(filter);
            }

            return queryable;
        }

        public TEntity GetById(int entityId)
        {
            return _dbSet.SingleOrDefault(s => s.Id == entityId);
        }

        public void Insert(TEntity tEntity)
        {
            _dbSet.Add(tEntity);
        }

        public void Update(TEntity tEntity)
        {
            _context.Entry(tEntity).State = EntityState.Modified;
        }

        public void Delete(TEntity tEntity)
        {
            _context.Entry(tEntity).State = EntityState.Deleted;
        }

        public bool Any(Expression<Func<TEntity, bool>> condition)
        {
            return _dbSet.Any(condition);
        }

        public bool IsExist(Expression<Func<TEntity, bool>> Where)
        {
            return _dbSet.Any(Where);
        }


        #region Dispose

        public void Dispose()
        {

        }

        #endregion
    }
}
