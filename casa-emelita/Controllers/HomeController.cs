using casa_emelita.Models;
using casa_emelita.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace casa_emelita.Controllers
{
    public class HomeController : Controller
    {
        AppModel model;
        MenuRepository menuRepository;
        CategoryRepository categoryRepository;
        Data data;
        public HomeController() { 
            this.model = new AppModel();
            this.menuRepository = new MenuRepository();
            this.categoryRepository = new CategoryRepository();
            this.data = new Data();
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
                this.model.ErrorMessage = "Session Timeout";
                return RedirectToAction("../Home/Home");
            }
            ViewBag.Message = "HomeAdmin";

            return View();
        }
        public ActionResult MenuAdmin()
        {
            if (this.model.AdminID == Guid.Empty)
            {
                this.model.ErrorMessage = "Session Timeout";
                return RedirectToAction("../Home/Home");
            }
            this.model.Menu_List = this.menuRepository.GetMenuList();
            this.model.Category = this.categoryRepository.GetAllCategories();
            ViewBag.Message = "MenuAdmin";

            return View(this.model);
        }

        [System.Web.Http.HttpPost]
        public ActionResult UploadFile(AppModel uploadForm)
        {
            if (uploadForm.menuNewRecord.file != null && uploadForm.menuNewRecord.file.ContentLength > 0)
            {
                try
                {
                    string fileName = Path.GetFileName(uploadForm.menuNewRecord.file.FileName);
                    string path = Path.Combine(Server.MapPath("~/UploadedImage/"), fileName);
                    uploadForm.menuNewRecord.file.SaveAs(path);

                    ViewBag.Message = "File uploaded successfully!";

                    TBL_MENU menu = new TBL_MENU();
                    menu.MENUIMAGE = path;
                    menu.PRICE = uploadForm.menuNewRecord.Price;
                    menu.MENUCODE = uploadForm.menuNewRecord.Code;
                    menu.MENUNAME = uploadForm.menuNewRecord.Name;
                    menu.MENUCATEGORY = uploadForm.menuNewRecord.Category;
                    menu.MENUDESCRIPTION = uploadForm.menuNewRecord.Description;

                    this.data.Save(menu, new List<string> { "MENUID" }, "MENUID");
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "Error: " + ex.Message;
                }
            }
            else
            {
                ViewBag.Message = "Please select a file to upload.";
            }

            return RedirectToAction("../Home/MenuAdmin");
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