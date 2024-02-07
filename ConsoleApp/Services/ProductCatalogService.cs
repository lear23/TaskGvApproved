

using AllForApproved.ProductServices;
using AllForApproved.Services;

namespace ConsoleApp.Services;

public class ProductCatalogService
{
    private readonly ClientService _clientService;
    private readonly ProductServices _products;

    public ProductCatalogService(ClientService clientService, ProductServices products)
    {
        _clientService = clientService;
        _products = products;
    }


    public void CreateProduct_UI()
    {
        Console.Clear();

        Console.WriteLine("----CREATE PRODUCT----");

       
        Console.Write("Model Name: ");
        var modelName = Console.ReadLine()!;
        Console.Write("Color: ");
        var color = Console.ReadLine()!;
        Console.Write("Category: ");
        var categoryName = Console.ReadLine()!;


        Console.WriteLine("---Client Data--");


        Console.Write("First Name: ");
        var firstName = Console.ReadLine()!;

        Console.Write("Last Name: ");
        var lastName = Console.ReadLine()!;

        Console.Write("User Name: ");
        var readerName = Console.ReadLine()!;

        Console.Write("StreetName: ");
        var streetName = Console.ReadLine()!;
        Console.Write("Postal Code: ");
        var postalCode = Console.ReadLine()!;

        Console.Write("City: ");
        var city = Console.ReadLine()!;

        var product = _products.CreateProduct( modelName, color, categoryName);
        var result = _clientService.CreateClient(firstName, lastName,readerName, streetName, postalCode, city);
        if (product != null && result != null)
        {
            Console.Clear();
            Console.WriteLine("User and Product Were Created Successfully");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Error occurred while creating User or Product");
            Console.ReadKey();
        }
    }

    public void GetProduct_UI()
    {
        Console.Clear();
        var products = _products.GetAllProducts();
        foreach (var product in products)
        {

            if (product != null)
            {
                var modelName = product.ModelName ?? "N/A";
                var color = product.Color ?? "N/A";
                var categoryName = product.Category?.CategoryName ?? "N/A";

                Console.WriteLine($"{modelName} - {color} - {categoryName}");
            }
            else
            {
                Console.WriteLine("Produkten är null");
            }
        }

        Console.ReadKey();
    }

}
