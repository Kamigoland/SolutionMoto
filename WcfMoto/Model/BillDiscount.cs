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
    
    public partial class BillDiscount
    {
        public int IdBillDiscount { get; set; }
        public int IdBill { get; set; }
        public int IdDiscount { get; set; }
    
        public virtual Bills Bills { get; set; }
        public virtual Discounts Discounts { get; set; }
    }
}
