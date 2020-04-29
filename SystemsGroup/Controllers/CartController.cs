using Spot.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spot.Data;
using Spot.Services;
using Spot.Data.DAO;
using Spot.Data.IDAO;
using Spot.Services.IService;
using Spot.Services.Service;
using System.Runtime.InteropServices;

namespace SystemsGroup.Controllers
{
    public class CartController : Controller
    {
        public List<CartProduct> cart;
        private Spot.Services.IService.IProductsService _productService;

        public ActionResult AddToCart(int id)
        {
            CartProduct cartItem = new CartProduct();
            _productService = new ProductsService();
            Products products = _productService.GetProduct(id);
            cartItem.Quantity = 1;
            cartItem.Id = products.Id;
            cartItem.Name = products.Name;
            cartItem.PartNumber = products.PartNumber;
            cartItem.Price = products.Price;
            if (Session["cart"] == null)
            {
                List<CartProduct> cart = new List<CartProduct>();
                cart.Add(cartItem);
                Session["cart"] = cart;
            }
            else
            {
                var cart = (List<CartProduct>)Session["cart"];
                cart.Add(cartItem);
                Session["cart"] = cart;
            }
            return RedirectToAction("DisplayCart");
        }

        public ActionResult DisplayCart()
        {
            var cart = (List<CartProduct>)Session["cart"];
            return View("DisplayCart", cart);
        }

        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        // GET: Cart/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cart/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cart/Create
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

        // GET: Cart/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cart/Edit/5
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

        // GET: Cart/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cart/Delete/5
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
