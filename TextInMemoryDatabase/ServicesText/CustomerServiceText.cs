
using AllForApproved.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TextInMemoryDatabase.ContextsText;

namespace TextInMemoryDatabase.ServicesText
{
    public class CustomerServiceText
    {
        private readonly DataContextsText _context;

        public CustomerServiceText(DataContextsText context)
        {
            _context = context;
        }

        public CustomerEntity CreateCustomer(string firstName, string lastName, ContactEntity contact, AddressEntity address, CountryEntity country)
        {
            var customer = new CustomerEntity
            {
                FirstName = firstName,
                LastName = lastName,
                Contact = contact,
                Address = address,
                Country = country
            };

            _context.Customer.Add(customer);
            _context.SaveChanges();

            return customer;
        }

        public List<CustomerEntity> GetAllCustomers()
        {
            return _context.Customer.ToList();
        }

        public CustomerEntity GetCustomerById(int id)
        {
            return _context.Customer.FirstOrDefault(c => c.Id == id);
        }

        public bool UpdateCustomer(int id, string firstName, string lastName, ContactEntity contact, AddressEntity address, CountryEntity country)
        {
            var existingCustomer = _context.Customer.FirstOrDefault(c => c.Id == id);

            if (existingCustomer != null)
            {
                existingCustomer.FirstName = firstName;
                existingCustomer.LastName = lastName;
                existingCustomer.Contact = contact;
                existingCustomer.Address = address;
                existingCustomer.Country = country;

                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool DeleteCustomer(int id)
        {
            var customerToRemove = _context.Customer.FirstOrDefault(c => c.Id == id);

            if (customerToRemove != null)
            {
                _context.Customer.Remove(customerToRemove);
                _context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}

