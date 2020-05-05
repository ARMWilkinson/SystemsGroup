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
        // GET: ProductsAdmin
        [HttpGet]
        public ActionResult UpdateProduct(int Id)
        {
            Products product = _productsService.GetProduct(Id);
            return View(product);
        }
        [HttpPost]
        public ActionResult UpdateProduct(int Id, Products product)
        {

            product = _productsService.GetProduct(Id);
            return RedirectToAction("GetProducts");
        }

        // GET: ProductsAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductsAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsAdmin/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductsAdmin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductsAdmin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
