

using AllForApproved.Contexts;

using AllForApproved.ProductEntities;

namespace AllForApproved.ProductRepo;

public class ProductsRepo : GenericProductRepo<ProductsEntity>
{
    public ProductsRepo(ProductCatalog context) : base(context)
    {
    }
}
