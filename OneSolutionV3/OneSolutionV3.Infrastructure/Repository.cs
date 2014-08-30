using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using OneSolutionV3.Domain.Models;

namespace OneSolutionV3.Infrastructure
{
    public abstract class Repository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
        where TEntity : class
    {
        
        protected OneSolutionContext _context;
        protected readonly DbSet<TEntity> _dbSet;
        private readonly IDatabaseFactory _databaseFactory;

        protected Repository(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
            _context = databaseFactory.GetOneSolutionContext();
            _dbSet = _context.Set<TEntity>();
        }

        public TEntity Save(TEntity entity, EntityState state)
        {
            _context.Entry(entity).State = state;
            return entity;
        }

        public virtual TEntity FindById(TPrimaryKey id)
        {
            return _dbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> FindAll()
        {
            return _dbSet;
        }

        public virtual IEnumerable<TEntity> Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.Where(expression);
        }

        public virtual void Update(TEntity entity, string[] propertyToUpdate)
        {
            _dbSet.Attach(entity);
            foreach (string property in propertyToUpdate)
                _context.Entry(entity).Property(property).IsModified = true;
        }

        public virtual void Delete(TEntity entity)
        {
            _dbSet.Attach(entity);
            _dbSet.Remove(entity);
        }

        public virtual void ExecuteSQLCommand(string command, params object[] parameters)
        {
            _context.Database.ExecuteSqlCommand(command, parameters);
        }

    }
}
