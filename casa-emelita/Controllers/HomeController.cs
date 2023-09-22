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
        static PageMessage message = new PageMessage();
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
            if(message.Message != null)
            {
                ViewBag.SaveUploadMessage = message.Message;
                message.Message = "";
            }
            this.model.Menu_List = this.menuRepository.GetMenuList();
            this.model.Category = this.categoryRepository.GetAllCategories();
            ViewBag.Message = "MenuAdmin";

            return View(this.model);
        }

        public ActionResult PackageAdmin()
        {
            if (this.model.AdminID == Guid.Empty)
            {
                this.model.ErrorMessage = "Session Timeout";
                return RedirectToAction("../Home/Home");
            }
            if (message.Message != null)
            {
                ViewBag.SaveUploadMessage = message.Message;
                message.Message = "";
            }
            this.model.Menu_List = this.menuRepository.GetMenuList();
            this.model.Category = this.categoryRepository.GetAllCategories();
            ViewBag.Message = "MenuAdmin";

            return View(this.model);
        }

        [System.Web.Http.HttpPost]
        public ActionResult SaveUpdateMenu(AppModel uploadForm)
        {
            if(uploadForm.menuNewRecord.MenuID == null)
            {
                UploadStatus ImageStatus = SaveImage(uploadForm.menuNewRecord.file);

                if (!ImageStatus.IsSuccess)
                {
                    ImageStatus.fileName = "empty";
                }

                TBL_MENU menu = new TBL_MENU();
                menu.MENUIMAGE = ImageStatus.fileName;
                menu.PRICE = uploadForm.menuNewRecord.Price;
                menu.MENUCODE = uploadForm.menuNewRecord.Code;
                menu.MENUNAME = uploadForm.menuNewRecord.Name;
                menu.MENUCATEGORY = uploadForm.menuNewRecord.Category;
                menu.MENUDESCRIPTION = uploadForm.menuNewRecord.Description;

                this.data.Save(menu, new List<string> { "MENUID" }, "MENUID");
                message.Message = "Successfully Saved!!!";
            }
            else
            {
                TBL_MENU tableMenu = menuRepository.GetMenuByID(new Guid(uploadForm.menuNewRecord.MenuID));
                UploadStatus ImageStatus = new UploadStatus();
                if (uploadForm.menuNewRecord.file != null)
                {
                    ImageStatus = SaveImage(uploadForm.menuNewRecord.file);
                }
                else
                {
                    ImageStatus.fileName = tableMenu.MENUIMAGE;
                }
                TBL_MENU menu = new TBL_MENU() { 
                    MENUID = new Guid(),
                    MENUIMAGE = ImageStatus.fileName,
                    PRICE = uploadForm.menuNewRecord.Price,
                    MENUCODE = uploadForm.menuNewRecord.Code,
                    MENUNAME = uploadForm.menuNewRecord.Name,
                    MENUCATEGORY = uploadForm.menuNewRecord.Category,
                    MENUDESCRIPTION = uploadForm.menuNewRecord.Description,
                };

                TBL_MENU menuFilter = new TBL_MENU()
                {
                    MENUID = new Guid(uploadForm.menuNewRecord.MenuID)
                };

                this.data.Update(menu, menuFilter, model.AdminID);

                if (uploadForm.menuNewRecord.file != null)
                {
                    bool isDeleted = DeleteFile(tableMenu.MENUIMAGE);
                }
                message.Message = "Successfully Updated!!!";
            }

            return RedirectToAction("../Home/MenuAdmin");
        }

        public UploadStatus SaveImage(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                try
                {
                    string fileName = Path.GetFileName(file.FileName);
                    DateTime date = DateTime.Now;
                    fileName = date.ToString("MMddyyHmmss") + "." + fileName.Split('.')[fileName.Split('.').Count() - 1];
                    string path = Path.Combine(Server.MapPath("~/UploadedImage/"), fileName);
                    file.SaveAs(path);

                    return new UploadStatus() { 
                        fileName = fileName,
                        IsSuccess = true,
                    };
                }
                catch (Exception ex)
                {
                    return new UploadStatus()
                    {
                        fileName = null,
                        IsSuccess = false,
                        message = "Error: " + ex.Message
                    };
                }
            }
            else
            {
                return new UploadStatus()
                {
                    fileName = null,
                    IsSuccess = false,
                    message = "Error: No Image"
                };
            }
        }

        public ActionResult Delete(string MenuIDToDelete)
        {
            TBL_MENU tableMenu = menuRepository.GetMenuByID(new Guid(MenuIDToDelete));

            bool isDeleted = DeleteFile(tableMenu.MENUIMAGE);

            this.data.Delete(new TBL_MENU(), new List<string>() { MenuIDToDelete}, "MENUID");
            message.Message = "Successfully Deleted!!!";
            return RedirectToAction("../Home/MenuAdmin");
        }
        public bool DeleteFile(string filename)
        {
            if (System.IO.File.Exists(Path.Combine(Server.MapPath("~/UploadedImage/"), filename)))
            {
                System.IO.File.Delete(Path.Combine(Server.MapPath("~/UploadedImage/"), filename));
                return true;
            }
            return false;
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