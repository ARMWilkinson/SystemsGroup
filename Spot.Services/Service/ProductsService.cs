using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spot.Data;
using Spot.Data.DAO;
using Spot.Data.IDAO;
using Spot.Services;
using Spot.Services.IService;

namespace Spot.Services.Service
{
    public class ProductsService : IProductsService
    {
        private ProductsDAO _dao;
        
        public ProductsService()
        {
            _dao = new ProductsDAO();
        }

        public IList<Products> GetProducts()
        {
            return _dao.GetProducts();
        }

        public Products GetProduct(int id)
        {
            return _dao.GetProduct(id);
        }

        public void UpdateProduct(Products product)
        {
            _dao.UpdateProduct(product);
        }

        public void DeleteProduct(Products product)
        {
            _dao.DeleteProduct(product);
        }
    }
}
