

using AllForApproved.Contexts;
using AllForApproved.Entities;

namespace AllForApproved.Repositories
{
    public class CountryRepo : GenericRepo<CountryEntity>
    {
        public CountryRepo(DataContext context) : base(context)
        {
        }
    }
}
