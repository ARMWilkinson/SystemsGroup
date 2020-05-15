using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Spot.Data;
using Spot.Data.Models;

namespace SystemsGroup.Controllers
{
    public class RegistrationController : Controller
    {
        private SpotContext db = new SpotContext();
        

        //Register as a new customer through the databse and save. Take new user to login
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Customer obj)
        {
            if (ModelState.IsValid)
            {
                SpotContext db = new SpotContext ();
                db.Customer.Add(obj);
                db.SaveChanges();
            }
            return View("Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        //login function that uses the database to check email and password are correct. Checks whether the session user is admin or not and redirects to custom welcome page
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Customer customer)
        {
            if (ModelState.IsValid)
            {
                using (SpotContext dc = new SpotContext())
                {
                    var v = dc.Customer.Where(a => a.EmailAddress.Equals(customer.EmailAddress) && a.Password.Equals(customer.Password)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["LoggedUserID"] = v.Id.ToString();
                        Session["isAdmin"] = (v.isAdmin != null && v.isAdmin == true) ? true : false;
                        Session["LoggedUserFullname"] = v.EmailAddress.ToString();
                        return RedirectToAction("Welcome");
                    }
                }
            }
            return View(customer);
        }

        //Custom login View
        public ActionResult Welcome()
        {
            if (Session["LoggedUserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        //Logs out users and admin removing privileges to view pages they might have had if they were logged in
        public ActionResult Logout()
        {
            Session["loggedUserID"] = null;
            Session["loggedUserFullName"] = null;
            Session["isAdmin"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}
