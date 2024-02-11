

using AllForApproved.EntitiesTest;
using TextInMemoryDatabase.RepositoriesText;

namespace TextsConsoleApp.Services;

public class MainProgramTest(AddressRepo addressRepo)
{
    private readonly AddressRepo _addressRepo = addressRepo;

    public void CreateAdress()
    {
        var addressEntity = new AddressEntity();

        Console.Clear();
        Console.WriteLine("Street Name: ");
        addressEntity.StreetAddress = Console.ReadLine()!;

        Console.WriteLine("PostalCode: ");
        addressEntity.PostalCode = Console.ReadLine()!;

        var result = _addressRepo.Create(addressEntity);

        Console.WriteLine($"Adddress Id: {result.Id}");

        Console.ReadKey();

    }

    public void ListAllAddresser()
    {
        Console.Clear();
        var addresses = _addressRepo.Get();
        
        Console.Write("---List of Addresses :---");
        foreach (var address in addresses)
          {
              Console.WriteLine($"Address Id: {address.Id}, Street: {address.StreetAddress}, Postal Code: {address.PostalCode}");
          }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }


}
