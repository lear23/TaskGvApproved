

using AllForApproved.Contexts;
using AllForApproved.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AllForApproved.Repositories
{
    public class CustomerRepo : GenericRepo<CustomerEntity>
    {

        private readonly DataContext _context;
        public CustomerRepo(DataContext context) : base(context)
        {
            _context = context;
        }

        public override CustomerEntity Get(Expression<Func<CustomerEntity, bool>> expression)
        {
            var entity = _context.Customers
                .Include(i => i.Contact)
                .Include(i => i.Address)
                .Include(i => i.Country)
                .FirstOrDefault(expression);

            return entity!;
        }

        public override IEnumerable<CustomerEntity> GetAll()
        {
            return _context.Customers
                .Include(i => i.Contact)
                .Include(i => i.Address)
                .Include(i => i.Country)
                .ToList();
        }
    }
}
