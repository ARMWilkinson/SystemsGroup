using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spot.Services;
using Spot.Services.IService;
using Spot.Services.Service;
using Spot.Data;

namespace SystemsGroup.Controllers
{
    public class CustomersAdminController : Controller
    {
        private ICustomerService _customersService;

        public CustomersAdminController()
        {
            _customersService = new CustomerService();
        }
        [HttpGet]
        public ActionResult UpdateCustomer(int Id)
        {
            Customer customer = _customersService.GetCustomer(Id);
            return View(customer);
        }
        [HttpPost]
        public ActionResult UpdateCustomer(int Id, Customer customer)
        {
            try
            {
                _customersService.UpdateCustomer(customer);

                return RedirectToAction("GetCustomers", "Customers");
            }
            catch
            {
                return View("Index");
            }
        }

        [HttpGet]
        public ActionResult DeleteCustomer(int Id)
        {
            return View(_customersService.GetCustomer(Id));
        }

        [HttpPost]
        public ActionResult DeleteCustomer(int Id, Customer customer)
        {
            try
            {
                Customer deleteCustomer = _customersService.GetCustomer(Id);
                _customersService.DeleteCustomer(deleteCustomer);
                return RedirectToAction("GetCustomers", "Customers");
            }
            catch
            {
                return View("GetCustomers", "Customers");
            }
        }
    }
}
