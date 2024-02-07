

using AllForApproved.ProductEntities;
using AllForApproved.ProductRepo;

namespace AllForApproved.ProductServices;

public class CategoryService
{
    private readonly CategoryRepo _categoryRepo;

    public CategoryService(CategoryRepo categoryRepo)
    {
        _categoryRepo = categoryRepo;
    }

    public CategoriesEntity CreateCategory(string categoryName)
    {
        var categoryEntity = _categoryRepo.Get(x => x.CategoryName == categoryName);

        if (categoryEntity == null)
        {
            categoryEntity = _categoryRepo.Create(new CategoriesEntity { CategoryName = categoryName});

        }
        return categoryEntity;       
       
    }

    public CategoriesEntity GetCategories(string categoryName)
    {
        var categoryEntity = _categoryRepo.Get(x => x.CategoryName == categoryName);
        return categoryEntity;
    }
    public CategoriesEntity GetCategoriesById(int Id)
    {
        var categoryEntity = _categoryRepo.Get(x => x.Id == Id);
        return categoryEntity;
    }

    public IEnumerable<CategoriesEntity> GetAllCategories()
    {
        var categories = _categoryRepo.GetAll();
        return categories;
    } 

    public CategoriesEntity UpdateCategory(CategoriesEntity categoryEntity)
    {
        var UpdateCategoryEntity = _categoryRepo.Update(x => x.Id == categoryEntity.Id, categoryEntity);
        return UpdateCategoryEntity;
    }

    public void DeleteCategory(int id)
    {
        _categoryRepo.Delete(x => x.Id == id);
    }

}
