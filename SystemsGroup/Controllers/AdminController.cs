using Spot.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SystemsGroup.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Cryptography.X509Certificates;

namespace SystemsGroup.Controllers
{
    public class AdminController : Controller
    {
        private SystemsGroup.Models.ApplicationDbContext _context;
        public AdminController()
        {
            _context = new SystemsGroup.Models.ApplicationDbContext();
        }

        [HttpGet]
        public ActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddRole(FormCollection collection)
        {
            try
            {
                Microsoft.AspNet.Identity.EntityFramework.IdentityRole role =
                    new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = collection["RoleName"];
                _context.Roles.Add(role);
                _context.SaveChanges();
                return RedirectToAction("GetRoles");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult GetRoles()
        {
            return View(_context.Roles.ToList());
        }
    }
}