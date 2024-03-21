using casa_emelita.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace casa_emelita.Repository
{
    public class PackageInclusionRepository
    {
        public List<TBL_SERVICE> GetPackageInclusionsJSONList()
        {
            CASAEMELITAEntities entities = new CASAEMELITAEntities();
            List<TBL_SERVICE> menu = (List<TBL_SERVICE>)(from table_service in entities.TBL_SERVICE select table_service).ToList();

            return menu;
        }
        public TBL_SERVICE GetPackgeInclusionByID(Guid ServiceID)
        {
            CASAEMELITAEntities entities = new CASAEMELITAEntities();
            TBL_SERVICE menu = (TBL_SERVICE)(from table_service in entities.TBL_SERVICE.Where(data => data.SERVICEID == ServiceID) select table_service).FirstOrDefault();

            return menu;
        }
    }
}