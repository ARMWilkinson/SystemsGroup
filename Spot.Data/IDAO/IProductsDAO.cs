using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spot.Data.IDAO
{
    public interface IProductsDAO
    {
        IList<Products> GetProducts();

        Products GetProduct(int id);
    }
}
