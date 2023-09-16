using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using casa_emelita.Models;
using casa_emelita.Repository;

namespace casa_emelita.Controllers
{
    public class LoginController : Controller
    {
        LoginRepository loginRepository;
        public LoginController()
        {
            this.loginRepository = new LoginRepository();
        }
        [System.Web.Http.HttpPost]
        public JsonResult CheckCredentials([FromBody] LoginModel data)
        {
            string result = this.loginRepository.IsRegistered(data);
            LoginReturnModel loginReturnModel = new LoginReturnModel();
            loginReturnModel.status = "error";
            loginReturnModel.GUID = Guid.NewGuid().ToString();
            if(result != null)
            {
                loginReturnModel.status = "success";
                loginReturnModel.GUID = result;
                Session["AdminID"] = result;
            }
            return Json(loginReturnModel, JsonRequestBehavior.AllowGet);
        }
    }
}