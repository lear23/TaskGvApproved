

using AllForApproved.Contexts;
using System.Linq.Expressions;

namespace AllForApproved.ProductRepo
{
    public class GenericProductRepo<TEntity> where TEntity : class
    {
        private readonly ProductCatalog _context;

        public GenericProductRepo(ProductCatalog context)
        {
            _context = context;
        }

        public virtual TEntity Create(TEntity entity)
        {
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
            var entity = _context.Set<TEntity>().FirstOrDefault(expression);
            return entity!;
        }
        public virtual TEntity Update(Expression<Func<TEntity, bool>> expression, TEntity entity)
        {
            var entityUpdate = _context.Set<TEntity>().FirstOrDefault(expression);
            _context.Entry(entityUpdate!).CurrentValues.SetValues(entity);
            _context.SaveChanges();
            return entityUpdate!;
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> expression)
        {
            var entity = _context.Set<TEntity>().FirstOrDefault(expression);
            _context.Remove(entity!);
        }

    }
}
