using ShoppingCartMVC.DAL;
using ShoppingCartMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ShoppingCartMVC.Controllers
{
    public class AccountController : Controller
    {
        ShoppingCartContext db = new ShoppingCartContext();
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Account account)
        {
            bool isValid = db.Accounts.Any(x=>x.UserName==account.UserName && x.Password==account.Password );
            if (isValid)
            {
                FormsAuthentication.SetAuthCookie(account.UserName, false);
                return RedirectToAction("Index", "Item");
            }
            else
            {

            }
            ModelState.AddModelError("", "Invalid Username and Password ");
            return View();

        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(Account account)
        {
            db.Accounts.Add(account);
            db.SaveChanges();
            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}