//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfMoto.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bills
    {
        public int IdBill { get; set; }
        public int IdService { get; set; }
        public int IdAnnouncement { get; set; }
        public int IdUser { get; set; }
        public decimal FinalValue { get; set; }
        public System.DateTime DateTo { get; set; }
    
        public virtual Announcements Announcements { get; set; }
        public virtual Services Services { get; set; }
    }
}
