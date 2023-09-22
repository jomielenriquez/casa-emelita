using casa_emelita.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace casa_emelita.Repository
{
    public class PackageRepository
    {
        public List<TBL_PACKAGE> GetAllPackage()
        {
            CASAEMELITAEntities entities = new CASAEMELITAEntities();
            List<TBL_PACKAGE> package = (List<TBL_PACKAGE>)(from tbl_package in entities.TBL_PACKAGE select tbl_package).ToList();
            if (package.Count() == 0)
            {
                package = new List<TBL_PACKAGE>() { };
            }
            return (List<TBL_PACKAGE>)package;
        }
    }
}