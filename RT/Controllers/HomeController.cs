using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RT.Models;
using RT.Filters;

namespace RT.Controllers
{
    [OnAuth]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var chats = new List<ChatContext>();
            using (var db = new ChatDBContext())
            {
                chats = db.Chats.ToList();
            }
            return View(chats);
        }

        [HttpPost]
        public ActionResult Index(string message)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ChatDBContext())
                {
                    var chat = new ChatContext
                    {
                        FromUserName = Session["Username"].ToString(),
                        Message = message,
                        Date = DateTime.Now
                    };
                    db.Chats.Add(chat);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
        public ActionResult Chat()
        {
            return View();
        }
    }
}