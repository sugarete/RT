using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RT.Models;


namespace RT.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ChatDBContext())
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                }
                return RedirectToAction("Login", "Account");
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            using (var db = new ChatDBContext())
            {
                var usr = db.Users.Where(u => u.Username == user.Username && u.Password == user.Password).FirstOrDefault();
                if (usr != null)
                {
                    Session["UserID"] = usr.Id;
                    Session["Username"] = usr.Username;
                    return RedirectToAction("Hash", "Acs");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is incorrect");
                }
            }
            return View();
        }

        [Route("Account/Logout")]
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Account");
        }
    }
}