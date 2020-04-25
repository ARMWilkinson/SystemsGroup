using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SystemsGroup.Models;
using Spot.Data;
using Spot.Services.Models;

namespace SystemsGroup.Controllers
{
    public class CartController : Controller
    {
        public List<CartProduct> cart;
        private Spot.Services.IService.IProductsService _productService;

        // GET: Cart
        public ActionResult AddToCart(int id)
        {
            CartProduct cartItem = new CartProduct();
            Products product = _productService.GetProduct(id);
            cartItem.Quantity = 1;
            cartItem.Id = product.Id;
            cartItem.Name = product.Name;
            cartItem.Description = product.Description;
            cartItem.Price = product.Price;
            cartItem.PartNumber = product.PartNumber;
            List<Products> li = new List<Products>();
            if (Session["cart"] == null)
            {
                li.Add(cartItem);
                Session["cart"] = li;
                ViewBag.cart = li.Count();
                Session["count"] = 1;
            }
            else
            {
                var cart = (List<CartProduct>)Session["cart"];
                li.Add(cartItem);
                Session["cart"] = li;
                ViewBag.cart = li.Count();
                Session["cart"] = cart;
            }
            return RedirectToAction("DisplayCart");
        }

        
        public ActionResult DisplayCart()
        {
            var cart = (List<CartProduct>)Session["cart"];
            return View("DisplayCart");
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
