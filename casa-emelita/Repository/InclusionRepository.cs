using casa_emelita.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace casa_emelita.Repository
{
    public class InclusionRepository
    {
        public Guid GetInclusionID(Guid PackageID, Guid MenuID)
        {
            CASAEMELITAEntities entities = new CASAEMELITAEntities();
            return (entities.TBL_INCLUSION
                                    .Where(inclusions => inclusions.PACKAGEINCLUSION == PackageID && inclusions.MENUID == MenuID)
                                    .Select(column => column.INCLUSIONID)).FirstOrDefault();
        }
    }
}