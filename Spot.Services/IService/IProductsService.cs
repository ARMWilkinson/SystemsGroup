using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spot.Data;

namespace Spot.Services.IService
{
    public interface IProductsService
    {
        IList<Products> GetProducts();

        Products GetProduct(int id);

        void UpdateProduct(Products product);

        void DeleteProduct(Products product);

        void AddProduct(Products product);
    }
}
