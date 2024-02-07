

using AllForApproved.Contexts;

using AllForApproved.ProductEntities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AllForApproved.ProductRepo;

public class ClientsRepo : GenericProductRepo<ClientsEntity>
{
    public ClientsRepo(ProductCatalog context) : base(context)
    {
    }

   
}
