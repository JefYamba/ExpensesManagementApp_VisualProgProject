using EFCoreTuto.Models;
using EFCoreTuto.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreTuto.Services
{
    
    public class CustomerService
    {
        private CustomerRepository _customerRepository = new CustomerRepository();
        public void RegisterCustomer(Customer customer)
        {
            _customerRepository.Add(customer);
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAll();
        }
    }
}
