﻿

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



}
