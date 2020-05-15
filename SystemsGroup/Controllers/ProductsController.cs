using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spot.Data;
using Spot.Data.DAO;
using Spot.Data.IDAO;
using Spot.Services;
using Spot.Services.IService;
using Spot.Services.Service;

namespace SystemsGroup.Controllers
{
    public class ProductsController : Controller
    {
        private IProductsService _service;

        public ProductsController()
        {
            _service = new ProductsService();
        }

        //Obtain a list of all products
        public ActionResult GetProducts()
        {
            IList<Products> list = _service.GetProducts();
            return View("GetProducts", list);
        }

        //Get the details of a single product
        public ActionResult GetProduct(int id)
        {
            Products list = _service.GetProduct(id);
            return View("GetProduct", list);
        }
    }
}
