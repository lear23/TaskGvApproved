

using AllForApproved.Entities;
using AllForApproved.Repositories;

namespace AllForApproved.Services;

public class CustomerService
{
    private readonly CustomerRepo _customerRepo;
    private readonly AddressService _addressService;
    private readonly CountryService _countryService;
    private readonly ContactService _contactService;

    public CustomerService(CustomerRepo customerRepo, AddressService addressService, CountryService countryService, ContactService contactService)
    {
        _customerRepo = customerRepo;
        _addressService = addressService;
        _countryService = countryService;
        _contactService = contactService;
    }


    public CustomerEntity CreateCustomer(string firstName,  string lastName, string streetName, string postalCode, string email, string phoneNumber,string userName, string city, string country)
    {
        var contactEntity = _contactService.CreateContact(email, phoneNumber, userName);
        var countryEntity =_countryService.CreateCountry(city, country);
        var addressEntity = _addressService.CreateAddress(streetName, postalCode);

        var customerEntity = new CustomerEntity
        {
            FirstName = firstName,
            LastName = lastName,
            AddressId = addressEntity.Id,
            CountryId = countryEntity.Id,
            ContactId = contactEntity.Id       
            
        };
        customerEntity = _customerRepo.Create(customerEntity);
        return customerEntity;     


    }

    public CustomerEntity GetCustomerId(int id)
    {
        var customerEntity = _customerRepo.Get(x => x.Id == id);
        return customerEntity;
    }

    public IEnumerable<CustomerEntity> GetAllCustomer()
    {
        var customers = _customerRepo.GetAll();
        return customers;
    }

    public CustomerEntity UpdateCustomer(CustomerEntity customerEntity)
    {
        var UpdateCustomer = _customerRepo.Update(x => x.Id == customerEntity.Id, customerEntity);
        return UpdateCustomer;
    }


    //public void DeleteCustomer(int id)
    //{
    //    _customerRepo.Delete(x => x.Id == id);
    //}
    public bool? DeleteCustomer(int id)
    {
        try
        {
            _customerRepo.Delete(x => x.Id == id);
            return true;
        }
        catch (Exception ex)
        {

            Console.WriteLine($"An error occurred while deleting customer: {ex.Message}");
            return false;
        }
    }

}
