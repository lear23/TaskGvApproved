

using AllForApproved.Services;

namespace ConsoleApp.Services;

public class MenuService
{

    private readonly CustomerService _customerService;


    public MenuService(CustomerService customerService)
    {
        _customerService = customerService;

    }

    public void CreateCustomer_UI()
    {
        Console.Clear();

        Console.WriteLine("----CREATE CUSTOMER----");

        Console.Write("First Name: ");
        var firstName = Console.ReadLine()!;

        Console.Write("Last Name: ");
        var lastName = Console.ReadLine()!;

        Console.Write("Street Name: ");
        var streetName = Console.ReadLine()!;

        Console.Write("Postal Code: ");
        var postalCode = Console.ReadLine()!;
        Console.Write("Email: ");
        var email = Console.ReadLine()!;

        Console.Write("Phone Number: ");
        var phoneNumber = Console.ReadLine()!;

        Console.Write("User Name: ");
        var userName = Console.ReadLine()!;

        Console.Write("City: ");
        var city = Console.ReadLine()!;

        Console.Write("Country: ");
        var country = Console.ReadLine()!;

        var result = _customerService.CreateCustomer(firstName, lastName, streetName, postalCode, email, phoneNumber, userName, city, country);
        if (result != null)
        {
            Console.Clear();
            Console.WriteLine("User Was Created");

            Console.ReadKey();
        }

    }
    public void GetCustomer_UI()
    {
        Console.Clear();
        var customers = _customerService.GetAllCustomer();
        foreach (var customer in customers)
        {
            var firstName = customer.FirstName ?? "N/A";
            var lastName = customer.LastName ?? "N/A";
            var streetAddress = customer.Address?.StreetAddress ?? "N/A";
            var postalCode = customer.Address?.PostalCode ?? "N/A";
            var email = customer.Contact?.Email ?? "N/A";
            var phoneNumber = customer.Contact?.PhoneNumber ?? "N/A";
            var userName = customer.Contact?.User?.UserName ?? "N/A";
            var city = customer.Country?.City ?? "N/A";
            var country = customer.Country?.Country ?? "N/A";

            Console.WriteLine($"{firstName} - {lastName} - {streetAddress} - {postalCode} - {email} - {phoneNumber} - {userName} - {city} - {country}");
        }

        Console.ReadKey();
    }

    //public void DeleteCustomer()
    //{
    //    Console.Clear();
    //    Console.WriteLine("----DELETE CUSTOMER----");
    //    Console.Write("Enter Customer ID to delete: ");
    //    int customerId;
    //    if (int.TryParse(Console.ReadLine(), out customerId))
    //    {
    //        _customerService.DeleteCustomer(customerId);
    //        Console.WriteLine("Customer deletion request processed.");
    //    }
    //    else
    //    {
    //        Console.WriteLine("Invalid input. Please enter a valid customer ID.");
    //    }

    //    Console.ReadKey();
    //}
    public bool? DeleteCustomer()
    {
        Console.Clear();
        Console.WriteLine("----DELETE CUSTOMER----");
        Console.Write("Enter Customer ID to delete: ");
        int customerId;
        if (int.TryParse(Console.ReadLine(), out customerId))
        {
            try
            {
                _customerService.DeleteCustomer(customerId);
                Console.WriteLine("Customer deleted successfully.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting customer: {ex.Message}");
                return false;
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid customer ID.");
            return null;
        }
    }



}
