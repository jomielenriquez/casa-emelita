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
    
    public partial class TBL_CATEGORY
    {
        public TBL_CATEGORY()
        {
            this.TBL_MENU = new HashSet<TBL_MENU>();
        }
    
        public System.Guid CATEGORYID { get; set; }
        public string CATEGORYNAME { get; set; }
        public string CATEGORYDESCRIPTION { get; set; }
        public System.DateTime CREATEDDATE { get; set; }
        public string CREATEDBY { get; set; }
        public Nullable<System.DateTime> UPDATEDDATE { get; set; }
        public string UPDATEDBY { get; set; }
    
        public virtual ICollection<TBL_MENU> TBL_MENU { get; set; }
    }
}
