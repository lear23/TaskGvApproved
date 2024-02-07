

using AllForApproved.Contexts;
using AllForApproved.ProductEntities;

namespace AllForApproved.ProductRepo;

public class CategoryRepo : GenericProductRepo<CategoriesEntity>
{
    public CategoryRepo(ProductCatalog context) : base(context)
    {
    }
}
