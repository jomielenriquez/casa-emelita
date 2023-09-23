using casa_emelita.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace casa_emelita.Repository
{
    public class AdminRepository
    {
        public AdminRepository(Guid AdminID) {
            currentUser = GetCurrentUser(AdminID);
        }

        public TBL_ADMIN currentUser;
        public TBL_ADMIN GetCurrentUser(Guid AdminID)
        {
            CASAEMELITAEntities entities = new CASAEMELITAEntities();
            TBL_ADMIN entity = (from tblAdmin in entities.TBL_ADMIN.Where(admin => admin.ADMINID == AdminID) select tblAdmin).FirstOrDefault();
            return entity;
        }
    }
}