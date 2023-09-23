using casa_emelita.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace casa_emelita.Repository
{
    public class MenuRepository
    {
        public List<TBL_MENU> GetMenuList()
        {
            CASAEMELITAEntities entities = new CASAEMELITAEntities();
            List<TBL_MENU> menu = (List<TBL_MENU>)(from table_menu in entities.TBL_MENU select table_menu).ToList();
            if (menu.Count() == 0)
            {
                menu = new List<TBL_MENU>() { };
            }
            return (List<TBL_MENU>)menu;
        }
        public List<TBL_MENUJSON> GetMenuJSONList()
        {
            CASAEMELITAEntities entities = new CASAEMELITAEntities();
            List<TBL_MENU> menu = (List<TBL_MENU>)(from table_menu in entities.TBL_MENU select table_menu).ToList();
            if (menu.Count() == 0)
            {
                menu = new List<TBL_MENU>() { };
            }
            List<TBL_MENUJSON> json = new List<TBL_MENUJSON>();
            foreach(TBL_MENU row in menu)
            {
                json.Add(new TBL_MENUJSON()
                {
                    MENUID = row.MENUID,
                    MENUNAME = row.MENUNAME,
                    MENUCODE = row.MENUCODE,
                    MENUIMAGE = row.MENUIMAGE,
                    MENUCATEGORY = row.TBL_CATEGORY.CATEGORYNAME,
                    MENUDESCRIPTION = row.MENUDESCRIPTION,
                    PRICE = row.PRICE,
                    CREATEDBY = row.CREATEDBY,
                    CREATEDDATE = row.CREATEDDATE,
                    UPDATEDBY = row.UPDATEDBY,
                    UPDATEDDATE = row.UPDATEDDATE,
                    MENUCATEGORYGUID = row.TBL_CATEGORY.CATEGORYID
                });
            }
            return (List<TBL_MENUJSON>)json;
        }
        public TBL_MENU GetMenuByID(Guid MenuID)
        {
            CASAEMELITAEntities entities = new CASAEMELITAEntities();
            TBL_MENU menu = (TBL_MENU)(from table_menu in entities.TBL_MENU.Where(data => data.MENUID == MenuID) select table_menu).FirstOrDefault();

            return menu;
        }
    }
    public partial class TBL_MENUJSON
    {
        public System.Guid MENUID { get; set; }
        public string MENUNAME { get; set; }
        public string MENUCODE { get; set; }
        public string MENUIMAGE { get; set; }
        public string MENUCATEGORY { get; set; }
        public Guid MENUCATEGORYGUID { get; set; }
        public string MENUDESCRIPTION { get; set; }
        public decimal PRICE { get; set; }
        public System.DateTime CREATEDDATE { get; set; }
        public string CREATEDBY { get; set; }
        public Nullable<System.DateTime> UPDATEDDATE { get; set; }
        public string UPDATEDBY { get; set; }
    }
}