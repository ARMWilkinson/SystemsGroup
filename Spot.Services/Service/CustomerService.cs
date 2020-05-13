using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spot.Data;
using Spot.Services.IService;
using Spot.Data.DAO;
using Spot.Services;
using Spot.Data.IDAO;

namespace Spot.Services.Service
{
    public class CustomerService : ICustomerService
    {
        private CustomerDAO _dao;

        public CustomerService()
        {
            _dao = new CustomerDAO();
        }

        public IList<Customer> GetCustomers()
        {
            return _dao.GetCustomers();
        }

        public Customer GetCustomer(int id)
        {
            return _dao.GetCustomer(id);
        }
        public void UpdateCustomer(Customer customer)
        {
            _dao.UpdateCustomer(customer);
        }
        public void DeleteCustomer(Customer customer)
        {
            _dao.DeleteCustomer(customer);
        }
    }
}
