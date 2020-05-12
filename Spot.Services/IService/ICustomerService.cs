using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spot.Data;

namespace Spot.Services.IService
{
    public interface ICustomerService
    {
        IList<Customer> GetCustomers();

        Customer GetCustomer(int id);
    }
}
