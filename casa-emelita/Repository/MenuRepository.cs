using casa_emelita.Models;
using System;
using System.Collections.Generic;
using System.Data.Common.CommandTrees.ExpressionBuilder;
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
            List<TBL_MENU> menu = (List<TBL_MENU>)(from table_menu in entities.TBL_MENU.OrderBy(m => m.MENUNAME) select table_menu).ToList();
            if (menu.Count() == 0)
            {
                menu = new List<TBL_MENU>() { };
            }
            return (List<TBL_MENU>)menu;
        }
        public List<TBL_MENU> GetMenuList(Guid? SelectedCategory)
        {
            CASAEMELITAEntities entities = new CASAEMELITAEntities();
            List<TBL_MENU> menu = (List<TBL_MENU>)(from table_menu in entities.TBL_MENU
                                                   .OrderBy(m => m.MENUNAME)
                                                   .Where(m => m.MENUCATEGORY == SelectedCategory) select table_menu).ToList();
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
        public List<TBL_MENUJSON> GetIncludedPackages(Guid PackageInclusionID)
        {
            CASAEMELITAEntities entities = new CASAEMELITAEntities();
            List<TBL_INCLUSION> inclusions = (List<TBL_INCLUSION>)(from tbl_inclusions in entities.TBL_INCLUSION.Where(inclusion => inclusion.PACKAGEINCLUSION == PackageInclusionID) select tbl_inclusions).ToList();
            List<TBL_MENUJSON> menu = new List<TBL_MENUJSON>();

            foreach (TBL_INCLUSION inclusionsrow in inclusions)
            {
                var row = inclusionsrow.TBL_MENU;
                menu.Add(new TBL_MENUJSON()
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

            return (List<TBL_MENUJSON>)menu;
        }
        public List<TBL_MENUJSON> GetMenuJSONListWithoutIncludedPackage(Guid PackageInclusionID)
        {
            CASAEMELITAEntities entities = new CASAEMELITAEntities();
            List<Guid> inclusions = entities.TBL_INCLUSION
                                             .Where(inclusion => inclusion.PACKAGEINCLUSION == PackageInclusionID)
                                             .Select(data => data.MENUID)
                                             .ToList();

            List<TBL_MENU> menu = (List<TBL_MENU>)(from table_menu in entities.TBL_MENU.Where(menus => !inclusions.Contains(menus.MENUID)) select table_menu).ToList();
            if (menu.Count() == 0)
            {
                menu = new List<TBL_MENU>() { };
            }
            List<TBL_MENUJSON> json = new List<TBL_MENUJSON>();
            foreach (TBL_MENU row in menu)
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