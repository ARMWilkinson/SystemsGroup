using Spot.Data.IDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spot.Data.DAO
{
    public class CustomerDAO : ICustomerDAO
    {
        private SpotContext _context;

        public CustomerDAO()
        {
            _context = new SpotContext();
        }

        public IList<Customer> GetCustomers()
        {
            return _context.Customer.ToList();
        }

        public Customer GetCustomer(int id)
        {
            return _context.Customer.Find(id);
        }
        public void UpdateCustomer(Customer customer)
        {
                Customer _customer = GetCustomer(customer.Id);
                _customer.FirstName = customer.FirstName;
                _customer.LastName = customer.LastName;
                _customer.EmailAddress = customer.EmailAddress;
                _customer.Password = customer.Password;
                _customer.PhoneNumber = customer.PhoneNumber;

                _context.SaveChanges();
        }
        public void DeleteCustomer(Customer customer)
        {
            _context.Customer.Remove(customer);
            _context.SaveChanges();
        }
    }
}
