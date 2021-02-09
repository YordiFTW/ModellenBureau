using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModellenBureau4.Shared;

namespace ModellenBureau4.Api.Models
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int customerId);
        Customer AddCustomer(Customer customer);
        Customer UpdateCustomer(Customer customer);
        void DeleteCustomer(int customerId);
    }
}
