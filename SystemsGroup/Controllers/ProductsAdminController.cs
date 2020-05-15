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

        //Code for Editing an item
        public ActionResult UpdateProduct(int Id)
        {
            if (Session["isAdmin"] != null && bool.Parse(Session["isAdmin"].ToString()) == true)
            {
                Products product = _productsService.GetProduct(Id);
                return View(product);
            } else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult UpdateProduct(int Id, Products product)
        {
            try
            {
                if (Session["isAdmin"] != null && bool.Parse(Session["isAdmin"].ToString()) == true)
                {
                    _productsService.UpdateProduct(product);
                    return RedirectToAction("GetProducts", "Products");
                } else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult DeleteProduct(int Id)
        {
            if (Session["isAdmin"] != null && bool.Parse(Session["isAdmin"].ToString()) == true)
            {
                return View(_productsService.GetProduct(Id));
            } else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult DeleteProduct(int Id, Products product)
        {
            try
            {
                if (Session["isAdmin"] != null && bool.Parse(Session["isAdmin"].ToString()) == true)
                {
                    Products deleteProduct = _productsService.GetProduct(Id);
                    _productsService.DeleteProduct(deleteProduct);
                    return RedirectToAction("GetProducts", "Products");
                } else
                {
                    return View();
                }
            }
            catch
            {
                return View("GetProducts", "Products");
            }
        }

        [HttpGet]
        public ActionResult AddProduct(int Id)
        {
            if (Session["isAdmin"] != null && bool.Parse(Session["isAdmin"].ToString()) == true)
            {
                return View(_productsService.GetProduct(Id));
            } else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddProduct(int Id, Products product)
        {
            try
            {
                if (Session["isAdmin"] != null && bool.Parse(Session["isAdmin"].ToString()) == true)
                {
                    _productsService.AddProduct(product);
                    return RedirectToAction("GetProducts", "Products");
                } else
                {
                    return View();
                }
            }
            catch
            {
                return View("GetProducts", "Products");
            }
        }
    }
}
