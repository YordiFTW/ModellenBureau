using System.Collections.Generic;
using System.Linq;
using ModellenBureau4.Api.Data;
using ModellenBureau4.Data;
using ModellenBureau4.Shared;

namespace ModellenBureau4.Api.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public CustomerRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _appDbContext.Customers;
        }

        public Customer GetCustomerById(int customerId)
        {
            return _appDbContext.Customers.FirstOrDefault(c => c.Id == customerId);
        }

        public Customer AddCustomer(Customer customer)
        {
            var addedEntity = _appDbContext.Customers.Add(customer);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public Customer UpdateCustomer(Customer customer)
        {
            var foundCustomer = _appDbContext.Customers.FirstOrDefault(e => e.Id == customer.Id);

            if (foundCustomer != null)
            {
                foundCustomer.BirthDate = customer.BirthDate;
                foundCustomer.City = customer.City;
                foundCustomer.Email = customer.Email;
                foundCustomer.FirstName = customer.FirstName;
                foundCustomer.LastName = customer.LastName;
                foundCustomer.Gender = customer.Gender;
                foundCustomer.PhoneNumber = customer.PhoneNumber;
                foundCustomer.Street = customer.Street;
                foundCustomer.Zip = customer.Zip;

                _appDbContext.SaveChanges();

                return foundCustomer;
            }

            return null;
        }

        public void DeleteCustomer(int customerId)
        {
            var foundCustomer = _appDbContext.Customers.FirstOrDefault(e => e.Id == customerId);
            if (foundCustomer == null) return;

            _appDbContext.Customers.Remove(foundCustomer);
            _appDbContext.SaveChanges();
        }
    }
}
