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
        public MenuNewRecord menuNewRecord { get; set; }
        public List<TBL_CATEGORY> Category { get; set; }
    }
    public class MenuNewRecord
    {
        public HttpPostedFileBase file { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Guid Category { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }
}