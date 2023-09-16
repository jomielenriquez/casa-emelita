using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace casa_emelita.Models
{
    public class LoginModel
    {
        public string username { get; set; }
        public string password { get; set; }
    }
    public class LoginReturnModel
    {
        public string status { get; set; }
        public string GUID { get; set; }
    }
}