

using AllForApproved.Contexts;
using AllForApproved.Entities;

namespace AllForApproved.Repositories
{
    public class AddressRepo : GenericRepo<AddressEntity>
    {
        public AddressRepo(DataContext context) : base(context)
        {
        }
    }
}
