using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OneSolutionV3.Infrastructure
{
    public interface IRepository<TEntity, TPrimaryKey> 
        where TEntity : class
    {
        TEntity Save(TEntity entity, System.Data.Entity.EntityState state);
        TEntity FindById(TPrimaryKey id);
        IEnumerable<TEntity> FindAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression);
        void Update(TEntity entity, string[] propertyToUpdate);
        void Delete(TEntity entity);
        void ExecuteSQLCommand(string command, params object[] parameters);
    }
}
