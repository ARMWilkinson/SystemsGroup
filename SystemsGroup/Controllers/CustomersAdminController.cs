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

        //Code for Updating a customer which vailidates the session user is either an Admin or the customer themselves via customer id
        [HttpGet]
        public ActionResult UpdateCustomer(int Id)
        {
            if ((Session["LoggedUserID"] != null && Session["LoggedUserID"].ToString() == Id.ToString()) || (Session["isAdmin"] != null && bool.Parse(Session["isAdmin"].ToString()) == true))
            {
                Customer customer = _customersService.GetCustomer(Id);
                return View(customer);
            } 
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult UpdateCustomer(int Id, Customer customer)
        {
            try
            {
                if ((Session["LoggedUserID"] != null && Session["LoggedUserID"].ToString() == Id.ToString()) || (Session["isAdmin"] != null && bool.Parse(Session["isAdmin"].ToString()) == true))
                {
                    _customersService.UpdateCustomer(customer);
                    return RedirectToAction("GetCustomers", "Customers");
                } 
                else
                {
                    return View("Index");
                }
            }
            catch
            {
                return View("Index");
            }
        }

        //Code for Deleting a customer which vailidates the session user is either an Admin or the customer themselves via customer id
        [HttpGet]
        public ActionResult DeleteCustomer(int Id)
        {
            if ((Session["LoggedUserID"] != null && Session["LoggedUserID"].ToString() == Id.ToString()) || (Session["isAdmin"] != null && bool.Parse(Session["isAdmin"].ToString()) == true))
            {
                return View(_customersService.GetCustomer(Id));
            } 
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult DeleteCustomer(int Id, Customer customer)
        {
            try
            {
                if ((Session["LoggedUserID"] != null && Session["LoggedUserID"].ToString() == Id.ToString()) || (Session["isAdmin"] != null && bool.Parse(Session["isAdmin"].ToString()) == true))
                {
                    Customer deleteCustomer = _customersService.GetCustomer(Id);
                    _customersService.DeleteCustomer(deleteCustomer);
                    return RedirectToAction("GetCustomers", "Customers");
                } 
                else
                {
                    return View();
                }
            }
            catch
            {
                return View("GetCustomers", "Customers");
            }
        }
    }
}
