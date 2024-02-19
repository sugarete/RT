using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RT.Models;
using RT.Filters;
using RT.Models.ViewModels;

namespace RT.Controllers
{
    [OnAuth]
    public class AcsController : Controller
    {
        // GET: Acs
        public ActionResult Index()
        {
            return View();  
        }

        public ActionResult Hash()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Hash(AcsVM hashVM)
        {
            if (ModelState.IsValid)
            {
                hashVM.Action = "Hash";
                TempData["hashVM"] = hashVM;
                return RedirectToAction("AttackSetting");
            } 
            else
            {
                return View();
            }
        }

        public ActionResult AttackSetting()
        {
            AcsVM hashVM = (AcsVM)TempData["hashVM"];
            TempData["hashVM"] = hashVM;
            return View(hashVM);
        }
        public ActionResult AddAttack()
        {
            AcsVM hashVm = (AcsVM)TempData["hashVM"];
            TempData["hashVM"] = hashVm;
            return Index();
        }

        [HttpPost]
        public ActionResult AddAttack(AtkVM atkVM)
        {
            AcsVM hashVM = (AcsVM)TempData["hashVM"];
            AtkVM atk = new AtkVM();
            atk.Id = hashVM.AtkVMs.Count + 1;
            atk.ATK_Name = atkVM.ATK_Name;
            atk.Min_Length = atkVM.Min_Length;
            atk.Max_Length = atkVM.Max_Length;
            atk.Charset = atkVM.Charset;
            hashVM.AtkVMs.Add(atk);
            TempData["hashVM"] = hashVM;
            return RedirectToAction("AttackSetting");
        }

        public ActionResult Recover()
        {
            AcsVM hashVM = (AcsVM)TempData["hashVM"];

            return View();
        }
    }
}