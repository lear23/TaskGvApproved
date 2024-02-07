

using AllForApproved.ProductServices;
using AllForApproved.Services;

namespace ConsoleApp.Services;

public class ProductCatalogService
{
    private readonly ClientService _clientService;

    public ProductCatalogService(ClientService clientService)
    {
        _clientService = clientService;
    }


    public void CreateProduct_UI()
    {
        Console.Clear();

        Console.WriteLine("----CREATE PRODUCT----");

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


        var result = _clientService.CreateClient(firstName, lastName,readerName, streetName, postalCode, city);
        if (result != null)
        {
            Console.Clear();
            Console.WriteLine("User Was Created");

            Console.ReadKey();
        }
    }

}
