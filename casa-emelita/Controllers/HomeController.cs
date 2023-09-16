﻿using casa_emelita.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace casa_emelita.Controllers
{
    public class HomeController : Controller
    {
        AppModel model;
        public HomeController() { 
            this.model = new AppModel();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Home()
        {
            Session["AdminID"] = Guid.NewGuid();
            ViewBag.Message = "Home";

            return View();
        }
        public ActionResult HomeAdmin()
        {
            if (this.model.AdminID == Guid.Empty)
            {
                return RedirectToAction("../Home/Home");
            }
            ViewBag.Message = "Home";

            return View();
        }
        public ActionResult AboutCasa()
        {
            return View();
        }

        public ActionResult Menu()
        {
            return View();
        }
        
        public ActionResult ServicesofCasa()
        {
            return View();
        }
       
        public ActionResult GalleryofCasa()
        {
            return View();
        }
        public ActionResult ContactCasa()
        {
            return View();
        }
    }
}