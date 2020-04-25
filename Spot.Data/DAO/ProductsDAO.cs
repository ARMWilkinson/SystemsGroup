using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spot.Data.IDAO;

namespace Spot.Data.DAO
{
    public class ProductsDAO : IProductsDAO
    {
        private SpotContext _context;

        public ProductsDAO()
        {
            _context = new SpotContext();
        }

        public IList<Products> GetProducts()
        {
            return _context.Products.ToList();
        }

        public Products GetProduct(int id)
        {
            return _context.Products.Find(id);
        }

    }
}
