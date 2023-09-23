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
        public List<TBL_PACKAGE_JSON> GetAllPackageJSON()
        {
            CASAEMELITAEntities entities = new CASAEMELITAEntities();
            List<TBL_PACKAGE> package = (List<TBL_PACKAGE>)(from tbl_package in entities.TBL_PACKAGE select tbl_package).ToList();
            if (package.Count() == 0)
            {
                package = new List<TBL_PACKAGE>() { };
            }
            List<TBL_PACKAGE_JSON> package_json = new List<TBL_PACKAGE_JSON>();

            foreach (TBL_PACKAGE row in package)
            {
                package_json.Add(new TBL_PACKAGE_JSON()
                {
                    PACKAGEID = row.PACKAGEID,
                    PACKAGECODE = row.PACKAGECODE,
                    PACKAGENAME = row.PACKAGENAME,
                    EVENTTYPE = row.TBL_EVENTTYPE.EVENTNAME,
                    ACCOMODATION = row.ACCOMODATION,
                    PRICE = row.PRICE,
                    INCLUSIONSDESCRIPTION = row.INCLUSIONSDESCRIPTION,
                    EVENTTYPEGUID = row.TBL_EVENTTYPE.EVENTTYPEID
                });
            }

            return (List<TBL_PACKAGE_JSON>)package_json;
        }
    }
    public partial class TBL_PACKAGE_JSON
    {
        public System.Guid PACKAGEID { get; set; }
        public string PACKAGECODE { get; set; }
        public string PACKAGENAME { get; set; }
        public string EVENTTYPE { get; set; }
        public Guid EVENTTYPEGUID { get; set; }
        public Nullable<int> ACCOMODATION { get; set; }
        public decimal PRICE { get; set; }
        public string INCLUSIONSDESCRIPTION { get; set; }
    }
}