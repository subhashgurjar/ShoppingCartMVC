using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShoppingCartMVC.DAL;
using ShoppingCartMVC.Models;

namespace ShoppingCartMVC.Controllers
{
    public class CartItemController : Controller
    {
        public string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartId";
        private ShoppingCartContext db = new ShoppingCartContext();



        public ActionResult CheckOut()
        {
            return View();
        }



        public ActionResult Done(Checkout checkout)
        {
            ShoppingCartId = GetCartId();
            checkout.Total = db.CartItem.Where(c => c.CartId == ShoppingCartId).Sum(n => n.Quantity * n.Item.Price);
            checkout.Items = db.CartItem.Where(c => c.CartId == ShoppingCartId).ToList();
            checkout.OrderDate = DateTime.Now;

            db.Checkouts.Add(checkout);
            db.SaveChanges();

            return View(checkout);
        }
        public ActionResult Index()
        {
            ShoppingCartId = GetCartId();
            if (User.Identity.Name == "admin")
            {
                return View(db.CartItem.ToList());
            }
            else
            {
                return View(db.CartItem?.Where(x => x.CartId == ShoppingCartId).ToList());
            }
        }

        public ActionResult Increase(int id)
        {
            ShoppingCartId = GetCartId();

            var cartItem = db.CartItem.SingleOrDefault(
            c => c.CartId == ShoppingCartId
            && c.ItemId == id);

            cartItem.Quantity++;
            db.SaveChanges();
            return RedirectToAction("Index");


        }

        public ActionResult AddToCart(int id)
        {
            ShoppingCartId = GetCartId();

             var cartItem = db.CartItem.SingleOrDefault(
             c => c.CartId == ShoppingCartId
             && c.ItemId == id);
            if (cartItem == null)
            {
                              
                cartItem = new CartItem
                {
                    CartItemId = Guid.NewGuid().ToString(),
                    ItemId = id,
                    CartId = ShoppingCartId,
                    Item = db.Items.SingleOrDefault(
                    p => p.ItemId == id),
                    Quantity = 1,
                    
                };

                db.CartItem.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++;
            }
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public string GetCartId()
        {          
                return System.Web.HttpContext.Current.User.Identity.Name.ToString();
        }

        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var item = db.CartItem.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            db.CartItem.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }

       
    
}