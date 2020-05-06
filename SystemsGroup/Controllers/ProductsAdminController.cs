using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spot.Services;
using Spot.Data;
using Spot.Services.IService;
using Spot.Services.Service;

namespace SystemsGroup.Controllers
{
    public class ProductsAdminController : Controller
    {

        private IProductsService _productsService;

        public ProductsAdminController()
        {
            _productsService = new ProductsService();
        }
        [HttpGet]
        public ActionResult UpdateProduct(int Id)
        {
            Products product = _productsService.GetProduct(Id);
            return View(product);
        }
        [HttpPost]
        public ActionResult UpdateProduct(int Id, Products product)
        {
            try
            {
                _productsService.UpdateProduct(product);

                return RedirectToAction("GetProducts", "Products");
            }
            catch
            {
                return View("Index");
            }
        }

        [HttpGet]
        public ActionResult DeleteProduct(int Id)
        {
            return View(_productsService.GetProduct(Id));
        }

        [HttpPost]
        public ActionResult DeleteProduct(int Id, Products product)
        {
            try
            {
                Products deleteProduct = _productsService.GetProduct(Id);
                _productsService.DeleteProduct(deleteProduct);
                return RedirectToAction("GetProducts", "Products");
            }
            catch
            {
                return View("GetProducts", "Products");
            }
        }

        [HttpGet]
        public ActionResult AddProduct(int Id)
        {
            return View(_productsService.GetProduct(Id));
        }

        [HttpPost]
        public ActionResult AddProduct(int Id, Products product)
        {
            try
            {
                _productsService.AddProduct(product);
                return RedirectToAction("GetProducts", "Products");
            }
            catch
            {
                return View("GetProducts", "Products");
            }
        }
    }
}
