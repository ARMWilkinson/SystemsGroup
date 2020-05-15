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

        //Allows the user to add a product to the cart
        public ActionResult AddToCart(int id)
        {
            //Create the cart item object
            CartProduct cartItem = new CartProduct();

            //Get the products object
            _productService = new ProductsService();
            Products products = _productService.GetProduct(id);

            //Assign the values of the product to the cart item and give it a quantity of 1
            cartItem.Quantity = 1;
            cartItem.Id = products.Id;
            cartItem.Name = products.Name;
            cartItem.PartNumber = products.PartNumber;
            cartItem.Price = products.Price;

            //Add the product to the cart
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

        //Displays the cart
        public ActionResult DisplayCart()
        {
            var cart = (List<CartProduct>)Session["cart"];
            return View("DisplayCart", cart);
        }

        //Removes an item from the cart
        public ActionResult RemoveFromCart(int id)
        {
            var cart = (List<CartProduct>)Session["cart"];
            CartProduct cartItem = cart.Find(obj => obj.Id == id);
            cart.Remove(cartItem);
            Session["cart"] = cart;
            return RedirectToAction("DisplayCart");
        }

        //Increases the quantity of an item in the cart by 1
        public ActionResult IncreaseQuantity(int id)
        {
            var cart = (List<CartProduct>)Session["cart"];
            CartProduct cartItem = cart.Find(obj => obj.Id == id);
            cart.Remove(cartItem);
            cartItem.Quantity = cartItem.Quantity + 1;
            cart.Add(cartItem);
            Session["cart"] = cart;
            return RedirectToAction("DisplayCart");
        }

        //Decreases the quantity of an item in the cart by 1
        public ActionResult DecreaseQuantity(int id)
        {
            var cart = (List<CartProduct>)Session["cart"];
            CartProduct cartItem = cart.Find(obj => obj.Id == id);
            cart.Remove(cartItem);
            cartItem.Quantity = cartItem.Quantity - 1;
            cart.Add(cartItem);
            Session["cart"] = cart;
            return RedirectToAction("DisplayCart");
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
