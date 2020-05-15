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

        //Retrieve a list of the products
        public ActionResult GetProducts()
        {
            IList<Products> list = _service.GetProducts();
            return View("GetProducts", list);
        }

        //Retrieve the details of a single product
        public ActionResult GetProduct(int id)
        {
            Products list = _service.GetProduct(id);
            return View("GetProduct", list);
        }
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
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

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Products/Edit/5
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

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
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
