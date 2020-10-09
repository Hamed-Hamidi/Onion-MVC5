using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Onion.Data.Common;

namespace Onion.Repository.DataTransfer
{
    public interface IRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter);
        TEntity GetById(int entityId);
        void Insert(TEntity tEntity);
        void Update(TEntity tEntity);
        void Delete(TEntity tEntity);
        bool Any(Expression<Func<TEntity, bool>> condition);
        bool IsExist(Expression<Func<TEntity, bool>> Where);
    }
}