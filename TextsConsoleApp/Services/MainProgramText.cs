

using AllForApproved.Entities;
using TextInMemoryDatabase.RepositoriesText;

namespace TextsConsoleApp.Services;

public class MainProgramText(AddressRepo addressRepo)
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

    //public void ListAllAddresser()
    //{
    //    Console.Clear();
    //    var address = _addressRepo.Get();
    //}


}
