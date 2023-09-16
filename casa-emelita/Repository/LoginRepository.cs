using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using casa_emelita.Models;

namespace casa_emelita.Repository
{
    public class LoginRepository
    {
        public string IsRegistered(LoginModel model)
        {
            CASAEMELITAEntities entities = new CASAEMELITAEntities();
            TBL_ADMIN user = (TBL_ADMIN)(from users in entities.TBL_ADMIN
                       .Where(admin => admin.USERNAME == model.username && admin.PASSWORD == model.password) select users).FirstOrDefault();

            if(user != null )
            {
                return user.ADMINID.ToString();
            }
            return null;
        }
    }
}