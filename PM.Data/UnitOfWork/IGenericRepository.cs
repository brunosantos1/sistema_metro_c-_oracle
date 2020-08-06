using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace PM.Data.UnitOfWork
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        /// Allow filtering the table on the database through lambda expressions.
        /// </summary>
        /// <returns>An IQueryable object.</returns>
        IQueryable<TEntity> AsQueryable();

        /// <summary>
        /// Get all data on the table.
        /// </summary>
        /// <returns>A list of the domain entity.</returns>
        List<TEntity> GetAll();
        
        /// <summary>
        /// Find an entity through an lambda expression.
        /// </summary>
        /// <param name="predicate">Lambda expression.</param>
        /// <returns>A list of the domain entity.</returns>
        List<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        TEntity Single(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        bool Any(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        TEntity First(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity GetById(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        void Attach(TEntity obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        void Detach(TEntity obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        void Unchanged(TEntity obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        void Added(TEntity obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        TEntity Add(TEntity obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        EntityState Update(TEntity obj);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objs"></param>
        void UpdateRange(List<TEntity> objs);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        TEntity Delete(TEntity obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objs"></param>
        List<TEntity> DeleteRange(List<TEntity> objs);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="identifierExpression"></param>
        /// <param name="isSapSync"></param>
        /// <param name="entities"></param>
        void AddOrUpdate(Expression<Func<TEntity, object>> identifierExpression, params TEntity[] entities);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="propertyName"></param>
        /// <param name="isModified"></param>
        void SetPropertyState(TEntity obj, string propertyName, bool isModified);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="propertyName"></param>
        /// <param name="isModified"></param>
        void SetPropertyState(TEntity obj, string[] propertyName, bool isModified);

        void AddRange(List<TEntity> obj);

        int Count(Expression<Func<TEntity, bool>> predicate);

    }
}
