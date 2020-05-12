using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spot.Data.IDAO
{
    public interface ICustomerDAO
    {
        IList<Customer> GetCustomers();

        Customer GetCustomer(int id);
    }
}
