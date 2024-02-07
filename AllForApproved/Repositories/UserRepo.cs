

using AllForApproved.Contexts;
using AllForApproved.Entities;

namespace AllForApproved.Repositories
{
    public class UserRepo : GenericRepo<UserEntity>
    {
        public UserRepo(DataContext context) : base(context)
        {
        }
    }
}
