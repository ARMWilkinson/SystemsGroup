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
            if (Session["isAdmin"] != null && bool.Parse(Session["isAdmin"].ToString()) == true)
            {
                IList<Customer> list = _service.GetCustomers();
                return View("GetCustomers", list);
            } else
            {
                return View("../Home/Index");
            }
        }

        public ActionResult GetCustomer(int id)
        {
            if ((Session["LoggedUserID"] != null && Session["LoggedUserID"].ToString() == id.ToString()) || (Session["isAdmin"] != null && bool.Parse(Session["isAdmin"].ToString()) == true))
            {
                Customer customer = _service.GetCustomer(id);
                return View("GetCustomer", customer);
            } else
            {
                return View("../Home/Index");
            }
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            if (Session["LoggedUserID"] != null && Session["LoggedUserID"].ToString() == id.ToString())
            {
                return View();
            } else
            {
                return View("../Home/Index");
            }
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            if (Session["isAdmin"] != null && bool.Parse(Session["isAdmin"].ToString()) == true)
            {
                return View();
            } else
            {
                return View("../Home/Index");
            }
        }

        // POST: Customers/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (Session["isAdmin"] != null && bool.Parse(Session["isAdmin"].ToString()) == true)
                {
                    return RedirectToAction("Index");
                } else
                {
                    return View("../Home/Index");
                }
            }
            catch
            {
                return View("../Home/Index");
            }
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["isAdmin"] != null && bool.Parse(Session["isAdmin"].ToString()) == true)
            {
                return View();
            } else
            {
                return View("../Home/Index");
            }
        }

        // POST: Customers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                if (Session["isAdmin"] != null && bool.Parse(Session["isAdmin"].ToString()) == true)
                {
                    return RedirectToAction("Index");
                } else
                {
                    return View("../Home/Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["isAdmin"] != null && bool.Parse(Session["isAdmin"].ToString()) == true)
            {
                return View();
            } else
            {
                return View("../Home/Index");
            }
        }

        // POST: Customers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                if (Session["isAdmin"] != null && bool.Parse(Session["isAdmin"].ToString()) == true)
                {
                    return RedirectToAction("Index");
                } else
                {
                    return View("../Home/Index");
                }
            }
            catch
            {
                return View("../Home/Index");
            }
        }
    }
}
