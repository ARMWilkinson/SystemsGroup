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
        //Get a list of customers that is only accesible if the session user is an admin
        public ActionResult GetCustomers()
        {
            if (Session["isAdmin"] != null && bool.Parse(Session["isAdmin"].ToString()) == true)
            {
                IList<Customer> list = _service.GetCustomers();
                return View("GetCustomers", list);
            } 
            else
            {
                return View("../Home/Index");
            }
        }
        //Get a singular customer's details session dictates that a user can only view their details based on id but admin can view all
        public ActionResult GetCustomer(int id)
        {
            if ((Session["LoggedUserID"] != null && Session["LoggedUserID"].ToString() == id.ToString()) || (Session["isAdmin"] != null && bool.Parse(Session["isAdmin"].ToString()) == true))
            {
                Customer customer = _service.GetCustomer(id);
                return View("GetCustomer", customer);
            } 
            else
            {
                return View("../Home/Index");
            }
        }
    }
}
