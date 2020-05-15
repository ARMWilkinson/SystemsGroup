using Microsoft.Ajax.Utilities;
using Spot.Data;
using Spot.Services.IService;
using System.Collections.Generic;
using System.Web.Mvc;
using SystemsGroup.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.UI.WebControls;
using Antlr.Runtime.Misc;
using System.Linq;

namespace SystemsGroup.Controllers
{

    public class AdminController : Controller
    {

        private SystemsGroup.Models.ApplicationDbContext _context;

        
        private  SpotContext db = new SpotContext();
        public AdminController()
        {
            _context = new SystemsGroup.Models.ApplicationDbContext();
        }
        [Authorize (Roles="Admin")]
        //public ActionResult GetCustomers()
        //{
        //    IList<Customer> list = _service.GetCustomers();
        //    return View("GetCustomers", list);
        //}

        public ActionResult GetRoles()
        {
            return View();
        }
        [HttpGet] ///create Role
        public ActionResult AddRole()
        {
            return View();
        }
        [HttpPost] 
            
        public ActionResult AddRole(FormCollection collection)
        {
            return View();
        }
        [HttpPost]
        //public ActionResult AddRole(FormCollection collection)
        //{
        //    return View();
        //}

        [HttpGet]
        public ActionResult ManageUserRoles()
        {
            return View();
        }

        [HttpPost] [ValidateAntiForgeryToken]
        public ActionResult ManageUserRoles(string UserName, string RoleName)
        {
            return View();
        }

        public ActionResult GetRolesforUser()
        {
            return View();
        }

        public ActionResult GetRolesForUser (string UserName)
        {
            return View();
        }
        public ActionResult GetUsers()
        {
            return View(_context.Users.ToList());
        }








        //{
        //    try
        //    {
        //        Microsoft.AspNet.Identity.EntityFramework.IdentityRole role =
        //            new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
        //        role.Name = collection["RoleName"];
        //        _service.Roles.Add(role);
        //        _context.SaveChanges();
        //        return RedirectToAction("GetRoles");


        //    }
        //    catch
        //    {
        //        return View();
        //    }
    


        
       

    }
}