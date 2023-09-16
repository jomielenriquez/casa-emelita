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
                if(new Guid(HttpContext.Current.Session["AdminID"].ToString()) == Guid.Empty) {  return Guid.Empty; }
                return new Guid(HttpContext.Current.Session["AdminID"].ToString());
            }
            set
            {
                HttpContext.Current.Session["AdminID"] = value.ToString();
            } 
        }
    }
}