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
    
    public partial class TBL_PACKAGE
    {
        public System.Guid PACKAGEID { get; set; }
        public string PACKAGECODE { get; set; }
        public string PACKAGENAME { get; set; }
        public System.Guid EVENTTYPE { get; set; }
        public System.Guid INCLUSIONS { get; set; }
        public Nullable<int> ACCOMODATION { get; set; }
        public decimal PRICE { get; set; }
        public System.DateTime CREATEDDATE { get; set; }
        public string CREATEDBY { get; set; }
        public Nullable<System.DateTime> UPDATEDDATE { get; set; }
        public string UPDATEDBY { get; set; }
    
        public virtual TBL_EVENTTYPE TBL_EVENTTYPE { get; set; }
    }
}
