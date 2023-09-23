﻿using casa_emelita.Models;
using casa_emelita.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Xml.Linq;

namespace casa_emelita.Controllers
{
    public class HomeController : Controller
    {
        AppModel model;
        MenuRepository menuRepository;
        CategoryRepository categoryRepository;
        PackageRepository packageRepository;
        EventTypeRepository eventTypeRepository;
        AdminRepository adminRepository;
        Data data;
        static PageMessage message = new PageMessage();
        public HomeController() { 
            this.model = new AppModel();
            this.menuRepository = new MenuRepository();
            this.categoryRepository = new CategoryRepository();
            this.data = new Data();
            this.packageRepository = new PackageRepository();
            this.eventTypeRepository = new EventTypeRepository();
            this.adminRepository = new AdminRepository(this.model.AdminID);
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
            this.model.Package_List = this.packageRepository.GetAllPackage();
            this.model.Category = this.categoryRepository.GetAllCategories();
            this.model.EventType_List = this.eventTypeRepository.GetAllEventType();
            ViewBag.Message = "PackageAdmin";

            return View(this.model);
        }
        public ActionResult Settings()
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
            ViewBag.Message = "Settings";

            return View(this.model);
        }

        [System.Web.Http.HttpPost]
        public ActionResult SaveUpdateMenu(MenuNewRecord menuNewRecord)
        {
            if(menuNewRecord.MenuID == null)
            {
                UploadStatus ImageStatus = SaveImage(menuNewRecord.file);

                if (!ImageStatus.IsSuccess)
                {
                    ImageStatus.fileName = "empty";
                }

                TBL_MENU menu = new TBL_MENU();
                menu.MENUIMAGE = ImageStatus.fileName;
                menu.PRICE = menuNewRecord.Price;
                menu.MENUCODE = menuNewRecord.Code;
                menu.MENUNAME = menuNewRecord.Name;
                menu.MENUCATEGORY = menuNewRecord.Category;
                menu.MENUDESCRIPTION = menuNewRecord.Description;

                this.data.Save(menu, new List<string> { "MENUID" }, "MENUID");
                message.Message = "Successfully Saved!!!";
            }
            else
            {
                TBL_MENU tableMenu = menuRepository.GetMenuByID(new Guid(menuNewRecord.MenuID));
                UploadStatus ImageStatus = new UploadStatus();
                if (menuNewRecord.file != null)
                {
                    ImageStatus = SaveImage(menuNewRecord.file);
                }
                else
                {
                    ImageStatus.fileName = tableMenu.MENUIMAGE;
                }
                TBL_MENU menu = new TBL_MENU() { 
                    MENUID = new Guid(),
                    MENUIMAGE = ImageStatus.fileName,
                    PRICE = menuNewRecord.Price,
                    MENUCODE = menuNewRecord.Code,
                    MENUNAME = menuNewRecord.Name,
                    MENUCATEGORY = menuNewRecord.Category,
                    MENUDESCRIPTION = menuNewRecord.Description,
                };

                TBL_MENU menuFilter = new TBL_MENU()
                {
                    MENUID = new Guid(menuNewRecord.MenuID)
                };

                this.data.Update(menu, menuFilter, model.AdminID);

                if (menuNewRecord.file != null)
                {
                    bool isDeleted = DeleteFile(tableMenu.MENUIMAGE);
                }
                message.Message = "Successfully Updated!!!";
            }

            return RedirectToAction("../Home/MenuAdmin");
        }
        [System.Web.Http.HttpPost]
        public ActionResult SaveUpdatePackage(TBL_PACKAGE packageNewRecord)
        {
            if (packageNewRecord.PACKAGEID == new Guid())
            {
                TBL_PACKAGE package = new TBL_PACKAGE() { 
                    PACKAGECODE = packageNewRecord.PACKAGECODE,
                    PACKAGENAME = packageNewRecord.PACKAGENAME,
                    EVENTTYPE = packageNewRecord.EVENTTYPE,
                    INCLUSIONSDESCRIPTION = packageNewRecord.INCLUSIONSDESCRIPTION,
                    ACCOMODATION = packageNewRecord.ACCOMODATION,
                    PRICE = packageNewRecord.PRICE
                };

                this.data.Save(package, new List<string> { "PACKAGEID" }, "PACKAGEID");
                message.Message = "Successfully Saved!!!";
            }
            else
            {
                TBL_PACKAGE package = new TBL_PACKAGE()
                {
                    PACKAGECODE = packageNewRecord.PACKAGECODE,
                    PACKAGENAME = packageNewRecord.PACKAGENAME,
                    EVENTTYPE = packageNewRecord.EVENTTYPE,
                    INCLUSIONSDESCRIPTION = packageNewRecord.INCLUSIONSDESCRIPTION,
                    ACCOMODATION = packageNewRecord.ACCOMODATION,
                    PRICE = packageNewRecord.PRICE
                };

                TBL_PACKAGE packagefilter = new TBL_PACKAGE()
                {
                    PACKAGEID = packageNewRecord.PACKAGEID
                };

                this.data.Update(package, packagefilter, model.AdminID);

                message.Message = "Successfully Updated!!!";
            }
            return RedirectToAction("../Home/PackageAdmin");
        }
        [System.Web.Http.HttpPost]
        public ActionResult DeletePackage(string PackageIDToDelete)
        {
            this.data.Delete(new TBL_PACKAGE(), new List<string>() { PackageIDToDelete }, "PACKAGEID");
            message.Message = "Successfully Deleted!!!";
            return RedirectToAction("../Home/PackageAdmin");
        }
        [System.Web.Http.HttpPost]
        public JsonResult AddMenuInCategory(string PackageID, string MenuID)
        {

            return Json("test", JsonRequestBehavior.AllowGet);
        }
        [System.Web.Http.HttpPost]
        public ActionResult ChangePassword(ChangePassModel changePassModel)
        {
            TBL_ADMIN currentUser = adminRepository.currentUser;

            if(currentUser == null)
            {
                return RedirectToAction("../Home/Home");
            }
            if(currentUser.PASSWORD != changePassModel.CurrentPassword)
            {
                message.Message = "Invalid Password";
                return RedirectToAction("../Home/Settings");
            }
            if(changePassModel.NewPassword != changePassModel.ConfirmPassword)
            {
                message.Message = "Not Matched Password";
                return RedirectToAction("../Home/Settings");
            }

            TBL_ADMIN admin = new TBL_ADMIN() { 
                PASSWORD = changePassModel.NewPassword,
            };

            TBL_ADMIN filterAdmin = new TBL_ADMIN() {
                ADMINID = currentUser.ADMINID
            };

            this.data.Update(admin, filterAdmin, model.AdminID);
            message.Message = "Password successfully changed.";
            return RedirectToAction("../Home/Settings");
        }
        public ActionResult Logout()
        {
            Session["AdminID"] = "";
            return RedirectToAction("../Home/Home");
        }
        [System.Web.Http.HttpGet]
        public JsonResult GetMenu(string PackageID, string MenuID)
        {
            List<TBL_MENUJSON> data = this.menuRepository.GetMenuJSONList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [System.Web.Http.HttpGet]
        public JsonResult GetPackages()
        {
            List<TBL_PACKAGE_JSON> data = this.packageRepository.GetAllPackageJSON();
            return Json(data, JsonRequestBehavior.AllowGet);
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