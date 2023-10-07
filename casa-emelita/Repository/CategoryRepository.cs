using casa_emelita.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace casa_emelita.Repository
{
    public class CategoryRepository
    {
        public List<TBL_CATEGORY> GetAllCategories()
        {
            CASAEMELITAEntities entities = new CASAEMELITAEntities();
            return (List<TBL_CATEGORY>)(from cat in entities.TBL_CATEGORY.OrderBy(cat => cat.CATEGORYNAME) select cat).ToList();
        }
    }
}