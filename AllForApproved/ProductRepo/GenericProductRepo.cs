using AllForApproved.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AllForApproved.ProductRepo
{
    public class GenericProductRepo<TEntity> where TEntity : class
    {
        private readonly ProductCatalog _context;

        public GenericProductRepo(ProductCatalog context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public virtual TEntity Create(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> expression)
        {
            return _context.Set<TEntity>().FirstOrDefault(expression)!;
        }

        public virtual TEntity Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }

        public virtual void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> expression)
        {
            var entity = _context.Set<TEntity>().FirstOrDefault(expression);
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}


//using AllForApproved.Contexts;
//using System.Linq.Expressions;

//namespace AllForApproved.ProductRepo
//{
//    public class GenericProductRepo<TEntity> where TEntity : class
//    {
//        private readonly ProductCatalog _context;

//        public GenericProductRepo(ProductCatalog context)
//        {
//            _context = context;
//        }

//        public virtual TEntity Create(TEntity entity)
//        {
//            _context.Set<TEntity>().Add(entity);
//            _context.SaveChanges();
//            return entity;
//        }
//        public virtual IEnumerable<TEntity> GetAll()
//        {
//            return _context.Set<TEntity>().ToList();

//        }

//        public virtual TEntity Get(Expression<Func<TEntity, bool>> expression)
//        {
//            var entity = _context.Set<TEntity>().FirstOrDefault(expression);
//            return entity!;
//        }
//        public virtual TEntity Update(Expression<Func<TEntity, bool>> expression, TEntity entity)
//        {
//            var entityUpdate = _context.Set<TEntity>().FirstOrDefault(expression);
//            _context.Entry(entityUpdate!).CurrentValues.SetValues(entity);
//            _context.SaveChanges();
//            return entityUpdate!;
//        }

//        public virtual void Delete(Expression<Func<TEntity, bool>> expression)
//        {
//            var entity = _context.Set<TEntity>().FirstOrDefault(expression);
//            _context.Remove(entity!);
//        }

//    }
//}
