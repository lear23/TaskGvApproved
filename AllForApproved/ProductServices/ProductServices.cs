

using AllForApproved.ProductEntities;
using AllForApproved.ProductRepo;

namespace AllForApproved.ProductServices;

public class ProductServices
{
    private readonly ProductsRepo _productRepo;
    private readonly CategoryService _categoryService;

    public ProductServices(ProductsRepo productRepo, CategoryService categoryService)
    {
        _productRepo = productRepo;
        _categoryService = categoryService;
    }

    public ProductsEntity CreateProduct(string modelName, string color, string categoryName)
    {
        var categoryEntity = _categoryService.CreateCategory(categoryName);
        var productEntity = new ProductsEntity
        {
            ModelName = modelName,
            Color = color,
            CategoryId = categoryEntity.Id,
        };
        productEntity = _productRepo.Create(productEntity);
        return productEntity;
            
    }


    public ProductsEntity GetProductsById(int Id)
    {
        var productEntity = _productRepo.Get(x => x.Id == Id);
        return productEntity;
    }

    public IEnumerable<ProductsEntity> GetAllProducts()
    {
        var products = _productRepo.GetAll();
        return products;
    }

    public ProductsEntity UpdateProductsEntity (ProductsEntity productEntity)
    {
        var UpdateProductEntity = _productRepo.Update(x => x.Id == productEntity.Id, productEntity);
        return UpdateProductEntity;
    }

    public void DeleteProduct(int id)
    {
       _productRepo.Delete(x => x.Id == id);
    }


}
