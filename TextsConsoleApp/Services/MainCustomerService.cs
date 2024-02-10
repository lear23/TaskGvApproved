using AllForApproved.Entities;
using TextInMemoryDatabase.ServicesText;

namespace TextsConsoleApp.Services
{
    public class MainCustomerService
    {
        private readonly CustomerServiceText _customerService;

        public MainCustomerService(CustomerServiceText customerService)
        {
            _customerService = customerService;
        }


        public void CreateCustomer()
        {
            Console.Clear();
            Console.WriteLine("----CREATE CUSTOMER----");

            Console.Write("First Name: ");
            var firstName = Console.ReadLine()!;

            Console.Write("Last Name: ");
            var lastName = Console.ReadLine()!;

            
            var contact = new ContactEntity();
            Console.WriteLine("Enter contact information:");
            Console.Write("Email: ");
            contact.Email = Console.ReadLine()!;
            Console.Write("Phone Number: ");
            contact.PhoneNumber = Console.ReadLine()!;

            
            var address = new AddressEntity();
            Console.WriteLine("Enter address information:");
            Console.Write("Street Address: ");
            address.StreetAddress = Console.ReadLine()!;
            Console.Write("Postal Code: ");
            address.PostalCode = Console.ReadLine()!;

          
            var country = new CountryEntity();
            Console.WriteLine("Enter country information:");
            Console.Write("Country: ");
            country.Country = Console.ReadLine()!;
            Console.Write("City: ");
            country.City = Console.ReadLine()!;

            var customer = _customerService.CreateCustomer(firstName, lastName, contact, address, country);

            Console.WriteLine($"Customer Id: {customer.Id}");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void ListAllCustomers()
        {
            Console.Clear();
            Console.WriteLine("---List of Customers:---");

            var customers = _customerService.GetAllCustomers();

            foreach (var customer in customers)
            {
                Console.WriteLine($"Customer Id: {customer.Id}");
                Console.WriteLine($"First Name: {customer.FirstName}");
                Console.WriteLine($"Last Name: {customer.LastName}");

              
                Console.WriteLine("Contact Information:");
                Console.WriteLine($"Email: {customer.Contact.Email}");
                Console.WriteLine($"Phone Number: {customer.Contact.PhoneNumber}");

                Console.WriteLine("Address Information:");
                Console.WriteLine($"Street Address: {customer.Address.StreetAddress}");
                Console.WriteLine($"Postal Code: {customer.Address.PostalCode}");

                Console.WriteLine("Country Information:");
                Console.WriteLine($"Country: {customer.Country.Country}");
                Console.WriteLine($"City: {customer.Country.City}");

                Console.WriteLine(); 
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }


        //public void ListAllCustomers()
        //{
        //    Console.Clear();
        //    Console.WriteLine("---List of Customers:---");

        //    var customers = _customerService.GetAllCustomers();

        //    foreach (var customer in customers)
        //    {
        //        Console.WriteLine($"Customer Id: {customer.Id}, First Name: {customer.FirstName}, Last Name: {customer.LastName}");
        //        // Puedes mostrar otros datos del cliente aquí si lo deseas
        //    }

        //    Console.WriteLine("Press any key to continue...");
        //    Console.ReadKey();
        //    Console.Clear();
        //}
    }
}





//using AllForApproved.Entities;
//using TextInMemoryDatabase.ServicesText;

//namespace TextsConsoleApp.Services
//{
//    public class MainCustomerService
//    {
//        private readonly CustomerServiceText _customerService;

//        public MainCustomerService(CustomerServiceText customerService)
//        {
//            _customerService = customerService;
//        }

//        public void CreateCustomer()
//        {
//            Console.Clear();
//            Console.WriteLine("----CREATE CUSTOMER----");

//            Console.Write("First Name: ");
//            var firstName = Console.ReadLine()!;

//            Console.Write("Last Name: ");
//            var lastName = Console.ReadLine()!;


//            var customer = _customerService.CreateCustomer(firstName, lastName, ContactEntity contact);

//            Console.WriteLine($"Customer Id: {customer.Id}");

//            Console.WriteLine("Press any key to continue...");
//            Console.ReadKey();
//        }

//        public void ListAllCustomers()
//        {
//            Console.Clear();
//            Console.WriteLine("---List of Customers:---");

//            var customers = _customerService.GetAllCustomers();

//            foreach (var customer in customers)
//            {
//                Console.WriteLine($"Customer Id: {customer.Id}, First Name: {customer.FirstName}, Last Name: {customer.LastName}");

//            }

//            Console.WriteLine("Press any key to continue...");
//            Console.ReadKey();
//            Console.Clear();
//        }
//    }
//}
