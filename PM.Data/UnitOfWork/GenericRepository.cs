using PM.Domain.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace PM.Data.UnitOfWork
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly IDatabaseContext _dbContext;

        public GenericRepository(IDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region IGenericRepository<TEntity> implementation

        public IQueryable<TEntity> AsQueryable()
        {
            return _dbContext.Set<TEntity>().AsQueryable();
        }

        public List<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {             
            List<TEntity> result = _dbContext.Set<TEntity>().Where(predicate).ToList();
            return result;
        }

        public TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Single(predicate);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().SingleOrDefault(predicate);
        }

        public TEntity First(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().First(predicate);
        }

        public TEntity Add(TEntity obj)
        {
            var auditableObj = obj as IAuditable;
            if (auditableObj != null
                && (auditableObj.CreatedAt == null || auditableObj.CreatedAt.Equals(DateTime.MinValue)))
            {
                auditableObj.CreatedAt = DateTime.Now;
            }

            return _dbContext.Set<TEntity>().Add(obj);
        }

        public TEntity Delete(TEntity obj)
        {
            return _dbContext.Set<TEntity>().Remove(obj);
        }

        public void AddRange(List<TEntity> obj)
        {
            var auditableObj = obj as IAuditable;
            if (auditableObj != null
                && (auditableObj.CreatedAt == null || auditableObj.CreatedAt.Equals(DateTime.MinValue)))
            {
                auditableObj.CreatedAt = DateTime.Now;
            }

            _dbContext.Set<TEntity>().AddRange(obj);
        }

        public List<TEntity> GetAll()
        {
            List<TEntity> result = _dbContext.Set<TEntity>().ToList();
            return result;
        }

        public TEntity GetById(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public EntityState Update(TEntity obj)
        {
            var auditableObj = obj as IAuditable;
            if (auditableObj != null
                && (auditableObj.UpdatedAt == null || auditableObj.UpdatedAt.Equals(DateTime.MinValue)))
            {
                auditableObj.UpdatedAt = DateTime.Now;
            }

            return _dbContext.Entry(obj).State = EntityState.Modified;
        }

        public void UpdateRange(List<TEntity> objs)
        {
            foreach (var obj in objs)
            {
                Update(obj);
            }
        }

        public void Attach(TEntity obj)
        {
            _dbContext.Set<TEntity>().Attach(obj);
        }

        public void Detach(TEntity obj)
        {
            _dbContext.Entry(obj).State = EntityState.Detached;
        }

        public void AddOrUpdate(Expression<Func<TEntity, object>> identifierExpression, params TEntity[] entities)
        {
            _dbContext.Set<TEntity>().AddOrUpdate(identifierExpression, entities);
        }

        public void Unchanged(TEntity obj)
        {
            _dbContext.Entry(obj).State = EntityState.Unchanged;
        }

        public void Added(TEntity obj)
        {
            _dbContext.Entry(obj).State = EntityState.Added;
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Any(predicate);
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Count(predicate);
        }

        public void SetPropertyState(TEntity obj, string propertyName, bool isModified)
        {
            _dbContext.Set<TEntity>().Attach(obj);
            _dbContext.Entry(obj).Property(propertyName).IsModified = isModified;
        }

        public void SetPropertyState(TEntity obj, string[] propertiesName, bool isModified)
        {
            foreach (var propertyName in propertiesName)
            {
                this.SetPropertyState(obj, propertyName, isModified);
            }
        }

        public List<TEntity> DeleteRange(List<TEntity> objs)
        {
            List<TEntity> result = _dbContext.Set<TEntity>().RemoveRange(objs).ToList();
            return result;
        }
        

        #endregion


    }
}