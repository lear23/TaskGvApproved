using System;
using System.Collections.Generic;

namespace ConsoleApp.ProductEntities;

public partial class CategoriesEntity
{
    public int Id { get; set; }

    public string? CategoryName { get; set; }

    public virtual ICollection<ProductsEntity> ProductsEntities { get; set; } = new List<ProductsEntity>();
}
