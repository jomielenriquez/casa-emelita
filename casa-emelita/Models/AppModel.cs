using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace casa_emelita.Models
{
    public class AppModel
    {
        public Guid AdminID {
            get {
                try
                {
                    if(new Guid(HttpContext.Current.Session["AdminID"].ToString()) == Guid.Empty) {  return Guid.Empty; }
                }
                catch {
                    return Guid.Empty;
                }
                return new Guid(HttpContext.Current.Session["AdminID"].ToString());
            }
            set
            {
                HttpContext.Current.Session["AdminID"] = value.ToString();
            } 
        }
        public string ErrorMessage { get; set; }
        public List<TBL_MENU> Menu_List { get; set; }
        public string MenuIDToDelete { get; set; }
        public string PackageIDToDelete { get; set; }
        public MenuNewRecord menuNewRecord { get; set; }
        public List<TBL_CATEGORY> Category { get; set; }
        public List<TBL_PACKAGE> Package_List { get; set; }
        public TBL_PACKAGE packageNewRecord { get; set; }
        public List<TBL_EVENTTYPE> EventType_List { get; set; }
        public ChangePassModel changePassModel { get; set; }
        public Guid? SelectedCategory { get; set; }
        public Guid? SelectedEvent { get; set; }
        public TBL_ORDER Reservation { get; set; }
    }
    public class MenuNewRecord
    {
        public HttpPostedFileBase file { get; set; }
        public string MenuID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Guid Category { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
    }
    public class ChangePassModel
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}