using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spot.Data;
using Spot.Services.IService;
using Spot.Services.Service;
using Spot.Services.Models;
using Spot.Data.DAO;
using Spot.Data.IDAO;
using Spot.Data.Models;

namespace SystemsGroup.Controllers
{
    public class CustomersController : Controller
    {
        private ICustomerService _service;

        public CustomersController()
        {
            _service = new CustomerService();
        }

        public ActionResult GetCustomers()
        {
            IList<Customer> list = _service.GetCustomers();
            return View("GetCustomers", list);
        }

        public ActionResult GetCustomer(int id)
        {
            Customer customer = _service.GetCustomer(id);
            return View("GetCustomer", customer);
        }

    

        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
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

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customers/Edit/5
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

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customers/Delete/5
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
