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

        public void UpdateProduct(Products product)
        {
            Products _product = GetProduct(product.Id);
            _product.Name = product.Name;
            _product.Description = product.Description;
            _product.Price = product.Price;
            _product.PartNumber = product.PartNumber;
            _context.SaveChanges();
        }

        public void DeleteProduct(Products product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public void AddProduct(Products product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

    }
}
