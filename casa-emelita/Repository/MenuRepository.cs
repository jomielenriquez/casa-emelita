using casa_emelita.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}