//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace casa_emelita.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_MENU
    {
        public System.Guid MENUID { get; set; }
        public string MENUNAME { get; set; }
        public string MENUCODE { get; set; }
        public string MENUIMAGE { get; set; }
        public System.Guid MENUCATEGORY { get; set; }
        public string MENUDESCRIPTION { get; set; }
        public decimal PRICE { get; set; }
        public System.DateTime CREATEDDATE { get; set; }
        public string CREATEDBY { get; set; }
        public Nullable<System.DateTime> UPDATEDDATE { get; set; }
        public string UPDATEDBY { get; set; }
    
        public virtual TBL_CATEGORY TBL_CATEGORY { get; set; }
    }
}
