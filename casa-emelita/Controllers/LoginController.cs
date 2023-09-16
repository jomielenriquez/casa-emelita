using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace casa_emelita.Controllers
{
    public class LoginController : Controller
    {
        [HttpPost]
        public ActionResult Index()
        {
            return View();
        }
    }
}