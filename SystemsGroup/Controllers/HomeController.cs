using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spot.Data;

namespace SystemsGroup.Controllers
{
    public class HomeController : Controller
    {
        private SpotContext _context;

        public HomeController()
        {
            _context = new SpotContext();
        }
        public ActionResult Index()
        {
            IList<Products> productsList = _context.Products.ToList();
            return View(productsList);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}