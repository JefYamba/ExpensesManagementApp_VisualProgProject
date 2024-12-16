using EFCoreTuto.Data;
using EFCoreTuto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreTuto.Repositories
{
    public class CustomerRepository
    {
        EFCoreTutoContext _dbContext =  new EFCoreTutoContext();
        public List<Customer> GetAll()
        {
            var customers = _dbContext.Customers.OrderBy(c => c.Id);
            return customers.ToList();
        }

        public void Add(Customer customer) {
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
        }
    }
}
