

using AllForApproved.Contexts;
using AllForApproved.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AllForApproved.Repositories
{
    public class ContactRepo : GenericRepo<ContactEntity>
    {
        private readonly DataContext _context;
        public ContactRepo(DataContext context) : base(context)
        {
            _context = context;
        }

        public override ContactEntity Get(Expression<Func<ContactEntity, bool>> expression)
        {
            var entity = _context.Contacts
                .Include(i => i.User)                  
                .FirstOrDefault(expression);

            return entity!;
        }

        public override IEnumerable<ContactEntity> GetAll()
        {
            return _context.Contacts
                .Include(i => i.User)               
                .ToList();
        }
    }
}
