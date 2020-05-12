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
    }
}
