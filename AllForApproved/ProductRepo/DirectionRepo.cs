

using AllForApproved.Contexts;

using AllForApproved.ProductEntities;

namespace AllForApproved.ProductRepo;

public class DirectionRepo : GenericProductRepo<DirectionsEntity>
{
    public DirectionRepo(ProductCatalog context) : base(context)
    {
    }
}
