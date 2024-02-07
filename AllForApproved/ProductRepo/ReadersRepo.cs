

using AllForApproved.Contexts;

using AllForApproved.ProductEntities;

namespace AllForApproved.ProductRepo;

public class ReadersRepo : GenericProductRepo<ReadersEntity>
{
    public ReadersRepo(ProductCatalog context) : base(context)
    {
    }
}
